using UnityEngine;
using System;
using System.Collections.Generic;

namespace EngineAssemblyTycoon.Core
{
    /// <summary>
    /// Part Status - Where the part currently is in production
    /// </summary>
    public enum PartStatus
    {
        WaitingForProcessing,   // In queue/buffer
        InProcess,              // Being machined/assembled
        QualityCheck,           // At QC station
        Passed,                 // QC passed, ready for delivery
        Failed,                 // Scrapped
        Shipped                 // Delivered to customer
    }

    /// <summary>
    /// Part - Represents a physical part moving through the factory
    /// Tracks genealogy, quality data, and production history
    /// </summary>
    public class Part : MonoBehaviour
    {
        #region Serialized Fields
        [Header("Part Identity")]
        [SerializeField] private string partID; // Unique serial number (e.g., "ENG-v2-S00542")
        [SerializeField] private ProductSO productData; // Reference to product definition
        [SerializeField] private int version = 1; // Product version (for ECO tracking)
        
        [Header("Current State")]
        [SerializeField] private PartStatus status = PartStatus.WaitingForProcessing;
        [SerializeField] private Vector2 position; // Grid position in factory
        
        [Header("Production History (Genealogy)")]
        [SerializeField] private List<string> operationsCompleted = new List<string>();
        [SerializeField] private string materialLot = ""; // Raw material batch number
        [SerializeField] private DateTime creationTime;
        #endregion

        #region Properties
        public string PartID => partID;
        public ProductSO ProductData => productData;
        public int Version => version;
        public PartStatus Status => status;
        public List<string> OperationsCompleted => operationsCompleted;
        public string MaterialLot => materialLot;
        #endregion

        #region Events
        public event Action<PartStatus> OnStatusChanged;
        #endregion

        #region Initialization
        /// <summary>
        /// Initialize a new part with product data
        /// Called by PartSpawner or ProductionManager
        /// </summary>
        public void Initialize(ProductSO product, string lotNumber)
        {
            productData = product;
            version = product.Version;
            materialLot = lotNumber;
            creationTime = DateTime.Now;
            
            // Generate unique Part ID
            partID = GeneratePartID();
            
            Debug.Log($"Part created: {partID} (Product: {product.ProductName}, Lot: {materialLot})");
        }

        private string GeneratePartID()
        {
            // Format: PRODUCT-vVERSION-SXXXXX
            // Example: ENG-v2-S00542
            string productCode = productData != null ? productData.ProductID : "UNK";
            int serialNumber = UnityEngine.Random.Range(10000, 99999); // Simple serial (TODO: Use global counter)
            
            return $"{productCode}-v{version}-S{serialNumber}";
        }
        #endregion

        #region Status Management
        /// <summary>
        /// Change part status and trigger event
        /// </summary>
        public void ChangeStatus(PartStatus newStatus)
        {
            if (status == newStatus) return;

            status = newStatus;
            OnStatusChanged?.Invoke(newStatus);
            
            Debug.Log($"{partID}: Status changed to {newStatus}");
        }
        #endregion

        #region Genealogy Tracking
        /// <summary>
        /// Record that an operation was completed on this part
        /// Used for traceability and quality investigations
        /// </summary>
        public void RecordOperation(string operationName, string machineID)
        {
            string record = $"{operationName} on {machineID} at {DateTime.Now:HH:mm:ss}";
            operationsCompleted.Add(record);
            
            Debug.Log($"{partID}: Operation recorded - {record}");
        }

        /// <summary>
        /// Get full production history as formatted string
        /// </summary>
        public string GetProductionHistory()
        {
            if (operationsCompleted.Count == 0)
                return "No operations completed yet.";

            string history = $"Part {partID} Production History:\n";
            history += $"Material Lot: {materialLot}\n";
            history += $"Created: {creationTime:yyyy-MM-dd HH:mm:ss}\n";
            history += "Operations:\n";
            
            foreach (string operation in operationsCompleted)
            {
                history += $"  - {operation}\n";
            }
            
            return history;
        }
        #endregion

        #region Quality Data (Placeholder for Week 3)
        // TODO: Add quality measurements
        // - Dimensional data (length, width, height)
        // - Torque values (for assembly)
        // - Surface finish measurements
        // This will be implemented when we add the QC system
        #endregion

        #region Movement (Placeholder for Week 2)
        /// <summary>
        /// Move part to a new grid position
        /// TODO: Integrate with conveyor/AGV system
        /// </summary>
        public void MoveTo(Vector2 newPosition)
        {
            position = newPosition;
            transform.position = new Vector3(position.x, position.y, 0);
        }
        #endregion

        #region Debug Methods
        [ContextMenu("Print Production History")]
        private void DEBUG_PrintHistory()
        {
            Debug.Log(GetProductionHistory());
        }

        [ContextMenu("Mark as Scrapped")]
        private void DEBUG_Scrap()
        {
            ChangeStatus(PartStatus.Failed);
            Debug.Log($"{partID}: Manually marked as scrapped");
        }
        #endregion
    }
}
