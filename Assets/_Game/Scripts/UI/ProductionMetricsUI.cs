using UnityEngine;
using TMPro;
using EngineAssemblyTycoon.Core;

namespace EngineAssemblyTycoon.UI
{
    /// <summary>
    /// ProductionMetricsUI - Displays real-time production statistics
    /// Shows parts produced, delivered, in-progress, throughput, etc.
    /// </summary>
    public class ProductionMetricsUI : MonoBehaviour
    {
        #region UI References
        [Header("Production Stats Text Elements")]
        [SerializeField] private TextMeshProUGUI partsProducedText;
        [SerializeField] private TextMeshProUGUI partsDeliveredText;
        [SerializeField] private TextMeshProUGUI partsInProgressText;
        [SerializeField] private TextMeshProUGUI partsScrappedText;
        
        [Header("Performance Metrics")]
        [SerializeField] private TextMeshProUGUI efficiencyText;
        [SerializeField] private TextMeshProUGUI scrapRateText;
        [SerializeField] private TextMeshProUGUI throughputText;
        
        [Header("Revenue")]
        [SerializeField] private TextMeshProUGUI totalRevenueText;
        
        [Header("Update Settings")]
        [SerializeField] private float updateInterval = 0.5f; // Update UI twice per second
        [SerializeField] private float throughputTimeWindow = 3600f; // 1 hour in seconds (configurable)
        #endregion

        #region Private Fields
        private float updateTimer = 0f;
        
        // Throughput tracking with time window
        private System.Collections.Generic.Queue<DeliveryRecord> deliveryHistory = new System.Collections.Generic.Queue<DeliveryRecord>();
        
        // Helper struct for delivery tracking
        private struct DeliveryRecord
        {
            public float timestamp;
            public int count;
        }
        #endregion

        #region Unity Lifecycle
        private void Start()
        {
            UpdateAllMetrics();
        }

        private void Update()
        {
            // Update UI at regular intervals (not every frame for performance)
            updateTimer += Time.deltaTime;
            if (updateTimer >= updateInterval)
            {
                updateTimer = 0f;
                UpdateAllMetrics();
            }
        }
        #endregion

        #region UI Updates
        /// <summary>
        /// Update all production metrics displays
        /// </summary>
        private void UpdateAllMetrics()
        {
            if (ProductionManager.Instance == null)
            {
                Debug.LogWarning("ProductionManager not found - cannot update metrics");
                return;
            }

            ProductionManager pm = ProductionManager.Instance;

            // Basic counts
            if (partsProducedText != null)
                partsProducedText.text = pm.TotalPartsProduced.ToString();

            if (partsDeliveredText != null)
                partsDeliveredText.text = pm.TotalPartsDelivered.ToString();

            if (partsInProgressText != null)
                partsInProgressText.text = pm.ActivePartsCount.ToString();

            if (partsScrappedText != null)
                partsScrappedText.text = pm.TotalPartsScrapped.ToString();

            // Performance metrics
            if (efficiencyText != null)
            {
                float efficiency = pm.GetEfficiency() * 100f;
                efficiencyText.text = $"{efficiency:F1}%";
                
                // Color code efficiency
                if (efficiency >= 90f)
                    efficiencyText.color = Color.green;
                else if (efficiency >= 70f)
                    efficiencyText.color = Color.yellow;
                else
                    efficiencyText.color = Color.red;
            }

            if (scrapRateText != null)
            {
                float scrapRate = pm.GetScrapRate() * 100f;
                scrapRateText.text = $"{scrapRate:F1}%";
                
                // Color code scrap rate (lower is better)
                if (scrapRate <= 2f)
                    scrapRateText.color = Color.green;
                else if (scrapRate <= 5f)
                    scrapRateText.color = Color.yellow;
                else
                    scrapRateText.color = Color.red;
            }

            // Throughput (parts per hour)
            if (throughputText != null)
            {
                float throughput = CalculateThroughput();
                throughputText.text = $"{throughput:F1} parts/hr";
            }

            // Revenue
            if (totalRevenueText != null)
            {
                DeliveryPoint delivery = Object.FindFirstObjectByType<DeliveryPoint>();
                if (delivery != null)
                {
                    totalRevenueText.text = $"${delivery.TotalRevenue:N0}";
                }
            }
        }

        /// <summary>
        /// Calculate current throughput in parts per hour
        /// Uses rolling average over configured time window (default: 1 hour)
        /// </summary>
        private float CalculateThroughput()
        {
            if (ProductionManager.Instance == null)
                return 0f;

            float currentTime = Time.time;
            int currentDelivered = ProductionManager.Instance.TotalPartsDelivered;
            
            // Add current delivery count to history
            deliveryHistory.Enqueue(new DeliveryRecord 
            { 
                timestamp = currentTime, 
                count = currentDelivered 
            });
            
            // Remove records older than time window
            while (deliveryHistory.Count > 0 && 
                   currentTime - deliveryHistory.Peek().timestamp > throughputTimeWindow)
            {
                deliveryHistory.Dequeue();
            }
            
            // Need at least 2 data points to calculate throughput
            if (deliveryHistory.Count < 2)
                return 0f;
            
            // Calculate throughput based on oldest and newest records in window
            var oldestRecord = deliveryHistory.Peek();
            var newestRecord = new DeliveryRecord { timestamp = currentTime, count = currentDelivered };
            
            float timeSpan = newestRecord.timestamp - oldestRecord.timestamp;
            int partsDelivered = newestRecord.count - oldestRecord.count;
            
            if (timeSpan <= 0f)
                return 0f;
            
            // Convert to parts per hour
            float partsPerSecond = partsDelivered / timeSpan;
            float partsPerHour = partsPerSecond * 3600f;
            
            return partsPerHour;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Force an immediate UI update
        /// </summary>
        public void ForceUpdate()
        {
            UpdateAllMetrics();
        }

        /// <summary>
        /// Reset throughput calculation (e.g., when starting new production run)
        /// </summary>
        public void ResetThroughput()
        {
            deliveryHistory.Clear();
            UpdateAllMetrics(); // Immediate update after reset
        }
        
        /// <summary>
        /// Set the time window for throughput calculation
        /// </summary>
        /// <param name="seconds">Time window in seconds (e.g., 3600 for 1 hour, 60 for 1 minute)</param>
        public void SetThroughputTimeWindow(float seconds)
        {
            throughputTimeWindow = Mathf.Max(1f, seconds); // Minimum 1 second
            deliveryHistory.Clear(); // Clear history when changing window
        }
        #endregion
    }
}
