using UnityEngine;
using System.Collections.Generic;
using EngineAssemblyTycoon.Machines;

namespace EngineAssemblyTycoon.Core
{
    /// <summary>
    /// ProductionManager - Orchestrates the overall production flow
    /// Routes parts between machines, tracks production metrics
    /// </summary>
    public class ProductionManager : MonoBehaviour
    {
        #region Singleton
        private static ProductionManager _instance;
        public static ProductionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<ProductionManager>();
                }
                return _instance;
            }
        }
        #endregion

        #region Settings
        [Header("Production Configuration")]
        [SerializeField] private bool enableAutoRouting = true;
        [SerializeField] private float partMoveSpeed = 2f; // Units per second
        #endregion

        #region Private Fields
        private List<Machine> allMachines = new List<Machine>();
        private List<Part> activeParts = new List<Part>();
        
        // Metrics
        private int totalPartsProduced = 0;
        private int totalPartsScrapped = 0;
        private int totalPartsDelivered = 0;
        #endregion

        #region Properties
        public int TotalPartsProduced => totalPartsProduced;
        public int TotalPartsScrapped => totalPartsScrapped;
        public int TotalPartsDelivered => totalPartsDelivered;
        public int ActivePartsCount => activeParts.Count;
        public List<Machine> AllMachines => allMachines;
        #endregion

        #region Unity Lifecycle
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
        }

        private void Start()
        {
            // Find all machines in scene
            RefreshMachineList();
            
            UnityEngine.Debug.Log($"ProductionManager initialized. Found {allMachines.Count} machines.");
        }
        #endregion

        #region Machine Management
        /// <summary>
        /// Refresh the list of all machines (call when placing/removing machines)
        /// </summary>
        public void RefreshMachineList()
        {
            allMachines.Clear();
            allMachines.AddRange(Object.FindObjectsByType<Machine>(FindObjectsSortMode.None));
            
            // Subscribe to machine events
            foreach (Machine machine in allMachines)
            {
                machine.OnPartCompleted -= OnMachinePartCompleted;
                machine.OnPartFailed -= OnMachinePartFailed;
                
                machine.OnPartCompleted += OnMachinePartCompleted;
                machine.OnPartFailed += OnMachinePartFailed;
            }
            
            UnityEngine.Debug.Log($"Machine list refreshed: {allMachines.Count} machines");
        }

        /// <summary>
        /// Register a newly placed machine
        /// </summary>
        public void RegisterMachine(Machine machine)
        {
            if (!allMachines.Contains(machine))
            {
                allMachines.Add(machine);
                
                machine.OnPartCompleted += OnMachinePartCompleted;
                machine.OnPartFailed += OnMachinePartFailed;
                
                UnityEngine.Debug.Log($"Registered machine: {machine.MachineID}");
            }
        }

        /// <summary>
        /// Unregister a removed machine
        /// </summary>
        public void UnregisterMachine(Machine machine)
        {
            if (allMachines.Contains(machine))
            {
                machine.OnPartCompleted -= OnMachinePartCompleted;
                machine.OnPartFailed -= OnMachinePartFailed;
                
                allMachines.Remove(machine);
                UnityEngine.Debug.Log($"Unregistered machine: {machine.MachineID}");
            }
        }
        #endregion

        #region Part Tracking
        /// <summary>
        /// Register a part entering the production system
        /// </summary>
        public void RegisterPart(Part part)
        {
            if (!activeParts.Contains(part))
            {
                activeParts.Add(part);
                totalPartsProduced++;
                
                part.OnStatusChanged += OnPartStatusChanged;
                
                UnityEngine.Debug.Log($"Registered part: {part.PartID} (Active: {activeParts.Count})");
            }
        }

        /// <summary>
        /// Unregister a part leaving the production system
        /// </summary>
        public void UnregisterPart(Part part)
        {
            if (activeParts.Contains(part))
            {
                part.OnStatusChanged -= OnPartStatusChanged;
                activeParts.Remove(part);
                
                UnityEngine.Debug.Log($"Unregistered part: {part.PartID} (Active: {activeParts.Count})");
            }
        }
        #endregion

        #region Part Routing
        /// <summary>
        /// Route a completed part to the next station
        /// </summary>
        public void RoutePartToNextStation(Part part)
        {
            if (!enableAutoRouting)
            {
                UnityEngine.Debug.Log("Auto-routing disabled");
                return;
            }

            // Get the product's production steps
            if (part.ProductData == null || part.ProductData.ProductionSteps == null)
            {
                UnityEngine.Debug.LogWarning($"Part {part.PartID} has no production steps defined!");
                return;
            }

            // Determine which step we just completed
            int completedOperations = part.OperationsCompleted.Count;
            int totalSteps = part.ProductData.ProductionSteps.Length;

            if (completedOperations >= totalSteps)
            {
                // All steps complete - send to delivery
                RouteToDelivery(part);
                return;
            }

            // Find next machine type needed
            string nextStep = part.ProductData.ProductionSteps[completedOperations];
            Machine nextMachine = FindMachineForOperation(nextStep);

            if (nextMachine != null)
            {
                SendPartToMachine(part, nextMachine);
            }
            else
            {
                UnityEngine.Debug.LogWarning($"No machine found for operation: {nextStep}");
                // Part gets stuck - need to build missing machine!
            }
        }

        private Machine FindMachineForOperation(string operationName)
        {
            UnityEngine.Debug.Log($"[ROUTING] Looking for machine for operation: '{operationName}'");
            UnityEngine.Debug.Log($"[ROUTING] Available machines: {allMachines.Count}");

            foreach (Machine machine in allMachines)
            {
                if (machine.MachineData == null)
                {
                    UnityEngine.Debug.LogWarning($"[ROUTING] Machine {machine.name} has no MachineData!");
                    continue;
                }

                string machineTypeName = machine.MachineData.Type.ToString().Replace("_", " ");
                UnityEngine.Debug.Log($"[ROUTING] Checking machine: {machine.MachineID}, Type: {machineTypeName}");

                // Check if machine type matches operation
                if (operationName.Contains(machineTypeName) || machineTypeName.Contains(operationName.Split('-')[0].Trim()))
                {
                    UnityEngine.Debug.Log($"[ROUTING] Match found! {machineTypeName} matches '{operationName}'");

                    // Check if machine has capacity (queue not full)
                    MachineQueue queue = machine.GetComponent<MachineQueue>();
                    if (queue != null && !queue.IsFull)
                    {
                        UnityEngine.Debug.Log($"[ROUTING] Machine has capacity! Routing part here.");
                        return machine;
                    }
                    else if (queue == null)
                    {
                        UnityEngine.Debug.LogError($"[ROUTING] Machine {machine.MachineID} has NO MachineQueue component!");
                    }
                    else
                    {
                        UnityEngine.Debug.LogWarning($"[ROUTING] Machine queue is full ({queue.QueueSize}/{queue.MaxQueueSize})");
                    }
                }
                else
                {
                    UnityEngine.Debug.Log($"[ROUTING] No match: '{machineTypeName}' not in '{operationName}'");
                }
            }

            UnityEngine.Debug.LogError($"[ROUTING] No suitable machine found for operation: '{operationName}'");
            return null;
        }

        private void SendPartToMachine(Part part, Machine machine)
        {
            UnityEngine.Debug.Log($"Routing part {part.PartID} to {machine.MachineID}");

            // Add to machine's queue
            MachineQueue queue = machine.GetComponent<MachineQueue>();
            if (queue != null)
            {
                bool success = queue.EnqueuePart(part);
                if (!success)
                {
                    UnityEngine.Debug.LogWarning($"Failed to add part to queue at {machine.MachineID}");
                }
            }
            else
            {
                UnityEngine.Debug.LogError($"Machine {machine.MachineID} has no MachineQueue component!");
            }
        }

        private void RouteToDelivery(Part part)
        {
            UnityEngine.Debug.Log($"Part {part.PartID} completed all operations - routing to delivery");

            // Find delivery point
            DeliveryPoint delivery = FindFirstObjectByType<DeliveryPoint>();
            if (delivery != null)
            {
                delivery.DeliverPart(part);
            }
            else
            {
                // No delivery point - just mark as shipped
                part.ChangeStatus(PartStatus.Shipped);
                totalPartsDelivered++;
                UnityEngine.Debug.Log($"Part {part.PartID} delivered (no delivery point in scene)");
            }
        }
        #endregion

        #region Event Handlers
        private void OnMachinePartCompleted(Part part)
        {
            Debug.Log($"<color=cyan>Machine completed part: {part.PartID}</color>");

            // Find which machine completed this part
            Machine sourceMachine = registeredMachines.Values.FirstOrDefault(m =>
                m.GetComponent<MachineQueue>()?.GetCurrentPart() == part);

            // Route to next station
            RoutePartToNextStation(part);

            // Clear the output buffer now that part has been routed
            if (sourceMachine != null)
            {
                sourceMachine.ClearOutputBuffer();
            }
        }

        private void OnMachinePartFailed(Part part)
        {
            UnityEngine.Debug.Log($"Machine failed part: {part.PartID} (scrapped)");
            
            totalPartsScrapped++;
            
            // Remove from active tracking
            UnregisterPart(part);
        }

        private void OnPartStatusChanged(PartStatus newStatus)
        {
            // Track part status changes for metrics
            if (newStatus == PartStatus.Shipped)
            {
                totalPartsDelivered++;
            }
        }
        #endregion

        #region Public Helpers
        /// <summary>
        /// Get production efficiency (delivered / produced)
        /// </summary>
        public float GetEfficiency()
        {
            if (totalPartsProduced == 0) return 0f;
            return (float)totalPartsDelivered / totalPartsProduced;
        }

        /// <summary>
        /// Get scrap rate
        /// </summary>
        public float GetScrapRate()
        {
            if (totalPartsProduced == 0) return 0f;
            return (float)totalPartsScrapped / totalPartsProduced;
        }

        /// <summary>
        /// Reset all production metrics
        /// </summary>
        [ContextMenu("Reset Production Metrics")]
        public void ResetMetrics()
        {
            totalPartsProduced = 0;
            totalPartsScrapped = 0;
            totalPartsDelivered = 0;
            UnityEngine.Debug.Log("Production metrics reset");
        }
        #endregion

        #region Debug
        private void OnGUI()
        {
            // Simple on-screen stats (top-right corner)
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.alignment = TextAnchor.UpperRight;
            style.fontSize = 14;
            
            string stats = $"Production Stats:\n";
            stats += $"Active Parts: {activeParts.Count}\n";
            stats += $"Total Produced: {totalPartsProduced}\n";
            stats += $"Delivered: {totalPartsDelivered}\n";
            stats += $"Scrapped: {totalPartsScrapped}\n";
            stats += $"Efficiency: {GetEfficiency() * 100f:F1}%\n";
            stats += $"Scrap Rate: {GetScrapRate() * 100f:F1}%";
            
            GUI.Label(new Rect(Screen.width - 220, 180, 200, 150), stats, style);
        }
        #endregion
    }
}
