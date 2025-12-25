using UnityEngine;
using System.Collections.Generic;

namespace EngineAssemblyTycoon.Machines
{
    /// <summary>
    /// MachineQueue - Manages the queue of parts waiting at a machine
    /// Handles FIFO (First In, First Out) ordering
    /// Attached to each Machine that processes parts
    /// </summary>
    public class MachineQueue : MonoBehaviour
    {
        #region Settings
        [Header("Queue Configuration")]
        [SerializeField] private int maxQueueSize = 10;
        [SerializeField] private bool autoProcessNext = true;
        #endregion

        #region Private Fields
        private Queue<Core.Part> waitingParts = new Queue<Core.Part>();
        private Machine machineComponent;
        #endregion

        #region Properties
        public int QueueSize => waitingParts.Count;
        public int MaxQueueSize => maxQueueSize;
        public bool IsFull => waitingParts.Count >= maxQueueSize;
        public bool HasWaitingParts => waitingParts.Count > 0;
        #endregion

        #region Unity Lifecycle
        private void Awake()
        {
            machineComponent = GetComponent<Machine>();
            if (machineComponent == null)
            {
                UnityEngine.Debug.LogError($"MachineQueue requires a Machine component on {gameObject.name}!");
            }
        }

        private void Start()
        {
            // Subscribe to machine events
            if (machineComponent != null)
            {
                machineComponent.OnPartCompleted += OnMachinePartCompleted;
                machineComponent.OnPartFailed += OnMachinePartFailed;
            }
        }

        private void OnDestroy()
        {
            if (machineComponent != null)
            {
                machineComponent.OnPartCompleted -= OnMachinePartCompleted;
                machineComponent.OnPartFailed -= OnMachinePartFailed;
            }
        }
        #endregion

        #region Queue Management
        /// <summary>
        /// Add a part to the queue
        /// Returns true if successfully added, false if queue is full
        /// </summary>
        public bool EnqueuePart(Core.Part part)
        {
            if (part == null)
            {
                UnityEngine.Debug.LogWarning("Attempted to enqueue null part!");
                return false;
            }

            if (IsFull)
            {
                UnityEngine.Debug.LogWarning($"Queue full at {machineComponent?.MachineID ?? "Unknown"}! Cannot add part {part.PartID}");
                return false;
            }

            waitingParts.Enqueue(part);
            part.ChangeStatus(Core.PartStatus.WaitingForProcessing);
            
            UnityEngine.Debug.Log($"Part {part.PartID} added to queue at {machineComponent?.MachineID}. Queue size: {waitingParts.Count}");

            // Position part visually near machine
            PositionPartInQueue(part);

            // If machine is idle, start processing immediately
            if (autoProcessNext && machineComponent != null && machineComponent.Status == MachineStatus.Idle)
            {
                ProcessNextPart();
            }

            return true;
        }

        /// <summary>
        /// Start processing the next part in queue
        /// </summary>
        public bool ProcessNextPart()
        {
            if (machine == null)
            {
                UnityEngine.Debug.LogError("Cannot process - machine reference is null!");
                return false;
            }

            if (machineComponent == null)
            {
                UnityEngine.Debug.LogError("Cannot process part - no Machine component!");
                return false;
            }

            // Don't start new work if machine isn't idle
            if (machineComponent.Status != MachineStatus.Idle)
            {
                UnityEngine.Debug.Log($"{machineComponent.MachineID}: Still processing. Queue size: {waitingParts.Count}");
                return false;
            }

            if (waitingParts.Count == 0)
            {
                UnityEngine.Debug.Log($"{machineComponent.MachineID}: Queue empty. Waiting for parts.");
                return false;
            }

            Core.Part nextPart = waitingParts.Dequeue();

            // Record this operation in part's history
            nextPart.RecordOperation(
                machineComponent.MachineData?.DisplayName ?? "Unknown Operation",
                machineComponent.MachineID
            );

            // Start processing
            machineComponent.StartCycle(nextPart);

            UnityEngine.Debug.Log($"<color=green>Started processing {nextPart.PartID} on {machineComponent.MachineID}. Queue remaining: {waitingParts.Count}</color>");

            return true;
        }

        /// <summary>
        /// Get the next part without removing it from queue
        /// </summary>
        public Core.Part PeekNext()
        {
            return waitingParts.Count > 0 ? waitingParts.Peek() : null;
        }

        /// <summary>
        /// Clear all parts from queue
        /// </summary>
        public void ClearQueue()
        {
            waitingParts.Clear();
            UnityEngine.Debug.Log($"Queue cleared at {machineComponent?.MachineID}");
        }
        #endregion

        #region Event Handlers
        private void OnMachinePartCompleted(Core.Part completedPart)
        {
            UnityEngine.Debug.Log($"Part {completedPart.PartID} completed at {machineComponent.MachineID}");

            // TODO: Week 3 - Route part to next station
            // For now, just mark as passed
            completedPart.ChangeStatus(Core.PartStatus.Passed);

            // Process next part in queue if available
            if (autoProcessNext && HasWaitingParts)
            {
                ProcessNextPart();
            }
        }

        private void OnMachinePartFailed(Core.Part failedPart)
        {
            UnityEngine.Debug.Log($"Part {failedPart.PartID} FAILED at {machineComponent.MachineID}");

            failedPart.ChangeStatus(Core.PartStatus.Failed);

            // Process next part in queue
            if (autoProcessNext && HasWaitingParts)
            {
                ProcessNextPart();
            }
        }
        #endregion

        #region Visual Positioning
        private void PositionPartInQueue(Core.Part part)
        {
            // Position parts in a line near the machine
            // This is a simple visual representation
            Vector3 machinePos = transform.position;
            int queuePosition = waitingParts.Count - 1; // -1 because we just enqueued

            // Offset to the left of machine
            Vector3 queueOffset = new Vector3(-1.5f, 0f, 0f);
            Vector3 spacing = new Vector3(0f, -0.4f, 0f); // Stack vertically

            Vector3 targetPos = machinePos + queueOffset + (spacing * queuePosition);
            part.MoveTo(new Vector2(targetPos.x, targetPos.y));
        }
        #endregion

        #region Debug Visualization
        private void OnDrawGizmos()
        {
            // Draw queue area
            if (waitingParts != null && waitingParts.Count > 0)
            {
                Gizmos.color = Color.yellow;
                Vector3 queuePos = transform.position + new Vector3(-1.5f, 0f, 0f);
                Gizmos.DrawWireCube(queuePos, new Vector3(0.8f, maxQueueSize * 0.4f, 0f));
            }
        }

        private void OnDrawGizmosSelected()
        {
            // Draw max queue size indicator
            Gizmos.color = new Color(1f, 1f, 0f, 0.3f);
            Vector3 queuePos = transform.position + new Vector3(-1.5f, 0f, 0f);
            Gizmos.DrawCube(queuePos, new Vector3(0.8f, maxQueueSize * 0.4f, 0f));
        }
        #endregion

        #region Public Helpers
        /// <summary>
        /// Get list of all parts currently in queue (for UI display)
        /// </summary>
        public List<Core.Part> GetQueuedParts()
        {
            return new List<Core.Part>(waitingParts);
        }

        /// <summary>
        /// Check if a specific part is in the queue
        /// </summary>
        public bool ContainsPart(Core.Part part)
        {
            return waitingParts.Contains(part);
        }
        #endregion
    }
}
