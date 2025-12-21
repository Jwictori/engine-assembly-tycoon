using UnityEngine;

namespace EngineAssemblyTycoon.Machines
{
    /// <summary>
    /// Machine Type Enum
    /// Defines the category of machine
    /// </summary>
    public enum MachineType
    {
        CNC_Mill,
        CNC_Lathe,
        Assembly,
        Nutrunner,
        QC_Station,
        Conveyor
    }

    /// <summary>
    /// MachineSO - ScriptableObject that stores machine configuration data
    /// This is the DATA definition, not the machine behavior (which is in Machine.cs)
    /// 
    /// To create: Right-click in Project > Create > Game/Machine
    /// </summary>
    [CreateAssetMenu(fileName = "New Machine", menuName = "Game/Machine", order = 1)]
    public class MachineSO : ScriptableObject
    {
        [Header("Identity")]
        [Tooltip("Unique identifier for this machine type (e.g., 'CNC_MILL_01')")]
        public string MachineID = "MACHINE_001";
        
        [Tooltip("Display name shown to player")]
        public string DisplayName = "CNC Mill";
        
        [Tooltip("Type/category of machine")]
        public MachineType Type = MachineType.CNC_Mill;

        [Header("Economics")]
        [Tooltip("Purchase cost in dollars")]
        public int PurchaseCost = 35000;
        
        [Tooltip("Maintenance cost per 1000 cycles")]
        public int MaintenanceCost = 800;
        
        [Tooltip("Power consumption in kW")]
        public float PowerConsumption = 8f;

        [Header("Performance")]
        [Tooltip("Base cycle time in MINUTES (will be converted to seconds in code)")]
        public float BaseCycleTime = 12f; // 12 minutes default
        
        [Tooltip("Base scrap rate (0.0 to 1.0). Example: 0.04 = 4% scrap rate")]
        [Range(0f, 1f)]
        public float BaseScrapRate = 0.04f;
        
        [Tooltip("Precision in millimeters. Lower = better. Example: 0.01 = ±0.01mm")]
        public float Precision = 0.01f;

        [Header("Capacity")]
        [Tooltip("Grid size (width in cells). Example: 3 = 3×3 cells")]
        public int GridWidth = 3;
        
        [Tooltip("Grid size (height in cells)")]
        public int GridHeight = 3;

        [Header("Visuals (Placeholder for Week 2)")]
        [Tooltip("Sprite to display in factory view")]
        public Sprite MachineSprite;
        
        [Tooltip("Icon for UI panels")]
        public Sprite Icon;

        #region Validation
        private void OnValidate()
        {
            // Ensure values stay within reasonable bounds
            PurchaseCost = Mathf.Max(0, PurchaseCost);
            MaintenanceCost = Mathf.Max(0, MaintenanceCost);
            BaseCycleTime = Mathf.Max(0.1f, BaseCycleTime); // Minimum 0.1 minutes
            BaseScrapRate = Mathf.Clamp01(BaseScrapRate);
            GridWidth = Mathf.Max(1, GridWidth);
            GridHeight = Mathf.Max(1, GridHeight);
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Get cycle time in seconds (for actual gameplay use)
        /// </summary>
        public float GetCycleTimeSeconds()
        {
            return BaseCycleTime * 60f;
        }

        /// <summary>
        /// Calculate parts per hour at base efficiency
        /// </summary>
        public float GetPartsPerHour()
        {
            return 60f / BaseCycleTime;
        }

        /// <summary>
        /// Get formatted machine info for UI
        /// </summary>
        public string GetInfoText()
        {
            return $"{DisplayName}\n" +
                   $"Type: {Type}\n" +
                   $"Cycle Time: {BaseCycleTime:F1} min\n" +
                   $"Scrap Rate: {BaseScrapRate * 100f:F1}%\n" +
                   $"Cost: ${PurchaseCost:N0}\n" +
                   $"Maintenance: ${MaintenanceCost:N0}/1000 cycles";
        }
        #endregion
    }
}
