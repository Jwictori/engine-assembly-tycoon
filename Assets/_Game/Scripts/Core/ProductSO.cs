using UnityEngine;

namespace EngineAssemblyTycoon.Core
{
    /// <summary>
    /// ProductSO - ScriptableObject that defines a product (engine variant)
    /// Contains specifications, BOM, routing, and quality requirements
    /// 
    /// To create: Right-click in Project > Create > Game/Product
    /// </summary>
    [CreateAssetMenu(fileName = "New Product", menuName = "Game/Product", order = 2)]
    public class ProductSO : ScriptableObject
    {
        [Header("Identity")]
        [Tooltip("Unique product code (e.g., 'ENG', 'TRANS', 'PUMP')")]
        public string ProductID = "ENG";
        
        [Tooltip("Display name shown to player")]
        public string ProductName = "Standard Engine";
        
        [Tooltip("Product version number (for ECO tracking)")]
        public int Version = 1;
        
        [TextArea(3, 5)]
        [Tooltip("Description of this product")]
        public string Description = "4-cylinder gasoline engine for automotive applications";

        [Header("Economics")]
        [Tooltip("Material cost per unit (aluminum, steel, bolts, etc.)")]
        public float MaterialCost = 145f;
        
        [Tooltip("Base selling price (before contract negotiations)")]
        public float BaseSalePrice = 400f;
        
        [Tooltip("Estimated labor hours required")]
        public float LaborHours = 2.5f;

        [Header("Production Requirements")]
        [Tooltip("Operations required to produce this product (in order)")]
        public string[] ProductionSteps = new string[] 
        { 
            "Lathe - Rough Machining",
            "CNC - Precision Machining", 
            "Assembly - Cylinder Head",
            "Assembly - Bolt Tightening",
            "QC - Dimensional Check"
        };

        [Header("Quality Specifications")]
        [Tooltip("Maximum acceptable scrap rate for this product (0.0 to 1.0)")]
        [Range(0f, 1f)]
        public float MaxScrapRate = 0.03f; // 3% scrap allowed
        
        [Tooltip("Required dimensional precision (±mm)")]
        public float RequiredPrecision = 0.05f; // ±0.05mm
        
        [Tooltip("Key dimensions to verify (placeholder for Week 3 QC system)")]
        public string[] QualityCheckpoints = new string[]
        {
            "Length: 200mm ±0.05mm",
            "Width: 150mm ±0.05mm",
            "Bore: 85mm ±0.05mm"
        };

        [Header("Visuals (Placeholder)")]
        [Tooltip("Sprite to display for this product in UI")]
        public Sprite ProductIcon;

        #region Helper Methods
        /// <summary>
        /// Calculate profit margin at base price
        /// </summary>
        public float GetBaseProfit()
        {
            return BaseSalePrice - MaterialCost;
        }

        /// <summary>
        /// Get profit margin as percentage
        /// </summary>
        public float GetProfitMarginPercent()
        {
            return (GetBaseProfit() / BaseSalePrice) * 100f;
        }

        /// <summary>
        /// Get formatted product info for UI
        /// </summary>
        public string GetInfoText()
        {
            return $"{ProductName} (v{Version})\n" +
                   $"{Description}\n\n" +
                   $"Material Cost: ${MaterialCost:F2}\n" +
                   $"Sale Price: ${BaseSalePrice:F2}\n" +
                   $"Profit: ${GetBaseProfit():F2} ({GetProfitMarginPercent():F1}%)\n" +
                   $"Max Scrap: {MaxScrapRate * 100f:F1}%";
        }

        /// <summary>
        /// Get number of production steps required
        /// </summary>
        public int GetStepCount()
        {
            return ProductionSteps != null ? ProductionSteps.Length : 0;
        }
        #endregion

        #region Validation
        private void OnValidate()
        {
            // Ensure reasonable values
            MaterialCost = Mathf.Max(0f, MaterialCost);
            BaseSalePrice = Mathf.Max(MaterialCost, BaseSalePrice); // Can't sell below cost
            LaborHours = Mathf.Max(0.1f, LaborHours);
            MaxScrapRate = Mathf.Clamp01(MaxScrapRate);
            RequiredPrecision = Mathf.Max(0.001f, RequiredPrecision);
            Version = Mathf.Max(1, Version);
        }
        #endregion
    }
}
