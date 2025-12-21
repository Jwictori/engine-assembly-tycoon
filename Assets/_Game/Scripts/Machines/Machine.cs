using UnityEngine;
using System;
using EngineAssemblyTycoon.Core;

namespace EngineAssemblyTycoon.Machines
{
    /// <summary>
    /// Machine Status Enum
    /// Represents the current operational state of a machine
    /// </summary>
    public enum MachineStatus
    {
        Idle,           // Waiting for work
        Running,        // Processing a part
        Maintenance,    // Scheduled maintenance
        Error,          // Broken down
        Offline         // Powered off or not in use
    }

    /// <summary>
    /// Base class for all machines (CNC, Lathe, Assembly, etc.)
    /// Handles common functionality like cycle execution, status, telemetry
    /// </summary>
    public class Machine : MonoBehaviour
    {
        #region Serialized Fields (Inspector-Editable)
        [Header("Machine Configuration")]
        [SerializeField] private MachineSO machineData; // Reference to ScriptableObject data
        [SerializeField] private string machineID = "MACHINE_001"; // Unique identifier
        
        [Header("Runtime State")]
        [SerializeField] private MachineStatus currentStatus = MachineStatus.Idle;
        [SerializeField] private Part currentPart; // Part being processed
        [SerializeField] private float cycleProgress = 0f; // 0.0 to 1.0
        
        [Header("Performance Metrics")]
        [SerializeField] private int totalCyclesCompleted = 0;
        [SerializeField] private float toolWear = 0f; // 0.0 to 1.0 (100% = needs replacement)
        [SerializeField] private int scrapProduced = 0;
        #endregion

        #region Properties
        public string MachineID => machineID;
        public MachineStatus Status => currentStatus;
        public Part CurrentPart => currentPart;
        public float CycleProgress => cycleProgress;
        public float ToolWear => toolWear;
        public MachineSO MachineData => machineData;
        #endregion

        #region Events
        public event Action<Part> OnPartCompleted;
        public event Action<Part> OnPartFailed; // Scrapped
        public event Action<MachineStatus> OnStatusChanged;
        #endregion

        #region Unity Lifecycle
        private void Update()
        {
            if (currentStatus == MachineStatus.Running && currentPart != null)
            {
                ProcessCycle();
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Start processing a part
        /// </summary>
        public void StartCycle(Part part)
        {
            if (currentStatus != MachineStatus.Idle)
            {
                Debug.LogWarning($"{machineID}: Cannot start cycle, machine is {currentStatus}");
                return;
            }

            currentPart = part;
            cycleProgress = 0f;
            ChangeStatus(MachineStatus.Running);
            
            Debug.Log($"{machineID}: Started processing part {part.PartID}");
        }

        /// <summary>
        /// Stop the current cycle (emergency stop or error)
        /// </summary>
        public void StopCycle()
        {
            if (currentPart != null)
            {
                Debug.LogWarning($"{machineID}: Cycle stopped for part {currentPart.PartID}");
                currentPart = null;
            }
            
            cycleProgress = 0f;
            ChangeStatus(MachineStatus.Idle);
        }
        #endregion

        #region Private Methods
        private void ProcessCycle()
        {
            if (machineData == null)
            {
                Debug.LogError($"{machineID}: No MachineData assigned!");
                StopCycle();
                return;
            }

            // Increment cycle progress based on machine's base cycle time
            float cycleTimeSeconds = machineData.BaseCycleTime * 60f; // Convert minutes to seconds
            cycleProgress += Time.deltaTime / cycleTimeSeconds;

            // Check if cycle complete
            if (cycleProgress >= 1.0f)
            {
                CompleteCycle();
            }
        }

        private void CompleteCycle()
        {
            // Determine if part passes or fails (quality check)
            bool partPassed = CheckQuality();

            if (partPassed)
            {
                Debug.Log($"{machineID}: Part {currentPart.PartID} completed successfully!");
                OnPartCompleted?.Invoke(currentPart);
            }
            else
            {
                Debug.LogWarning($"{machineID}: Part {currentPart.PartID} FAILED quality check (scrapped)");
                scrapProduced++;
                OnPartFailed?.Invoke(currentPart);
            }

            // Update metrics
            totalCyclesCompleted++;
            IncrementToolWear();

            // Reset for next cycle
            currentPart = null;
            cycleProgress = 0f;
            ChangeStatus(MachineStatus.Idle);
        }

        private bool CheckQuality()
        {
            // Simple quality check: random roll against base scrap rate
            // TODO: Factor in worker skill, MES parameters, tool wear (Week 2-3)
            float scrapRate = machineData.BaseScrapRate;
            
            // Tool wear increases scrap rate
            float wearPenalty = toolWear * 0.1f; // +10% scrap at 100% wear
            float totalScrapRate = scrapRate + wearPenalty;
            
            float roll = UnityEngine.Random.value;
            return roll > totalScrapRate; // Part passes if roll > scrap rate
        }

        private void IncrementToolWear()
        {
            // Each cycle increases tool wear slightly
            // At 100% wear, tool should be replaced
            toolWear += 0.001f; // 0.1% wear per cycle = 1000 cycles to full wear
            toolWear = Mathf.Clamp01(toolWear);

            if (toolWear >= 0.8f)
            {
                Debug.LogWarning($"{machineID}: Tool wear critical ({toolWear * 100f:F1}%)!");
            }
        }

        private void ChangeStatus(MachineStatus newStatus)
        {
            if (currentStatus == newStatus) return;

            currentStatus = newStatus;
            OnStatusChanged?.Invoke(newStatus);
            Debug.Log($"{machineID}: Status changed to {newStatus}");
        }
        #endregion

        #region Debug Methods
        [ContextMenu("Simulate Breakdown")]
        private void DEBUG_Breakdown()
        {
            StopCycle();
            ChangeStatus(MachineStatus.Error);
            Debug.Log($"{machineID}: SIMULATED BREAKDOWN");
        }

        [ContextMenu("Reset Tool Wear")]
        private void DEBUG_ResetToolWear()
        {
            toolWear = 0f;
            Debug.Log($"{machineID}: Tool wear reset to 0%");
        }
        #endregion
    }
}
