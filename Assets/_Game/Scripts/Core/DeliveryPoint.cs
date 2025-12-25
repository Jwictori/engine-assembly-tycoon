using UnityEngine;

namespace EngineAssemblyTycoon.Core
{
    /// <summary>
    /// DeliveryPoint - Final destination for completed parts
    /// Acts as the "output" of the factory
    /// Tracks deliveries and awards rewards
    /// </summary>
    public class DeliveryPoint : MonoBehaviour
    {
        #region Settings
        [Header("Delivery Configuration")]
        [SerializeField] private Vector2 gridPosition = new Vector2(28, 15); // Right side of grid
        [SerializeField] private float deliveryReward = 400f; // Base payment per part
        [SerializeField] private int deliveryXP = 10; // XP per delivery
        
        [Header("Visual")]
        [SerializeField] private Color deliveryZoneColor = new Color(0.2f, 0.8f, 0.2f, 0.5f); // Green
        #endregion

        #region Private Fields
        private int totalDeliveries = 0;
        private float totalRevenue = 0f;
        #endregion

        #region Properties
        public int TotalDeliveries => totalDeliveries;
        public float TotalRevenue => totalRevenue;
        #endregion

        #region Unity Lifecycle
        private void Start()
        {
            // Position delivery point on grid
            if (GridManager.Instance != null)
            {
                Vector3 worldPos = GridManager.Instance.GridToWorldPosition(
                    (int)gridPosition.x,
                    (int)gridPosition.y
                );
                transform.position = worldPos;
            }

            UnityEngine.Debug.Log($"Delivery Point initialized at grid ({gridPosition.x}, {gridPosition.y})");
        }
        #endregion

        #region Delivery Handling
        /// <summary>
        /// Deliver a completed part
        /// </summary>
        public void DeliverPart(Part part)
        {
            if (part == null)
            {
                UnityEngine.Debug.LogWarning("Attempted to deliver null part!");
                return;
            }

            UnityEngine.Debug.Log($"Delivering part: {part.PartID}");

            // Calculate payment
            float payment = CalculatePayment(part);
            
            // Award payment
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddCash(payment);
                GameManager.Instance.AddXP(deliveryXP);
            }

            // Update metrics
            totalDeliveries++;
            totalRevenue += payment;

            // Mark part as shipped
            part.ChangeStatus(PartStatus.Shipped);

            // Move part to delivery location (visual)
            part.MoveTo(gridPosition);

            // Log delivery
            UnityEngine.Debug.Log($"✓ Part {part.PartID} delivered! Payment: ${payment:N0}, Total revenue: ${totalRevenue:N0}");
            
            // Show delivery effect (optional visual feedback)
            ShowDeliveryEffect(part);
        }

        private float CalculatePayment(Part part)
        {
            // Base payment
            float payment = deliveryReward;

            // Bonus for product type
            if (part.ProductData != null)
            {
                payment = part.ProductData.BaseSalePrice;
            }

            // Quality bonus (future - Week 4)
            // If part has perfect quality, add bonus
            // For now, just use base price

            return payment;
        }

        private void ShowDeliveryEffect(Part part)
        {
            // TODO: Week 3 - Add particle effect, sound, etc.
            // For now, just a log message
        }
        #endregion

        #region Visual Representation
        private void OnDrawGizmos()
        {
            // Draw delivery zone
            Vector3 pos;
            if (GridManager.Instance != null && Application.isPlaying)
            {
                pos = GridManager.Instance.GridToWorldPosition((int)gridPosition.x, (int)gridPosition.y);
            }
            else
            {
                pos = transform.position;
            }

            Gizmos.color = deliveryZoneColor;
            Gizmos.DrawCube(pos, new Vector3(2f, 2f, 0.1f));
            
            // Draw arrow pointing to zone
            Gizmos.color = Color.green;
            Gizmos.DrawLine(pos + Vector3.up * 1.5f, pos);
        }

        private void OnDrawGizmosSelected()
        {
            // Highlight when selected
            Vector3 pos = transform.position;
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(pos, new Vector3(2.5f, 2.5f, 0.1f));
        }
        #endregion

        #region Public Helpers
        /// <summary>
        /// Get average revenue per delivery
        /// </summary>
        public float GetAverageRevenue()
        {
            return totalDeliveries > 0 ? totalRevenue / totalDeliveries : 0f;
        }

        /// <summary>
        /// Reset delivery metrics
        /// </summary>
        [ContextMenu("Reset Delivery Metrics")]
        public void ResetMetrics()
        {
            totalDeliveries = 0;
            totalRevenue = 0f;
            UnityEngine.Debug.Log("Delivery metrics reset");
        }
        #endregion
    }
}
