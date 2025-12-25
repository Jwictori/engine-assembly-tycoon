using UnityEngine;

namespace EngineAssemblyTycoon.Core
{
    /// <summary>
    /// PartVisual - Handles visual representation of a part
    /// Shows as small colored sprite that moves through factory
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class PartVisual : MonoBehaviour
    {
        #region Private Fields
        private SpriteRenderer spriteRenderer;
        private ProductSO productData;
        private Part partComponent;
        
        // Visual properties
        private Color baseColor = new Color(0.9f, 0.9f, 0.3f, 1f); // Yellow-ish for parts
        private float pulseSpeed = 2f;
        private float pulseAmount = 0.1f;
        #endregion

        #region Initialization
        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            partComponent = GetComponent<Part>();
        }

        /// <summary>
        /// Initialize visual with product data
        /// </summary>
        public void Initialize(ProductSO product)
        {
            productData = product;
            CreateVisual();
            
            // Subscribe to part status changes for visual feedback
            if (partComponent != null)
            {
                partComponent.OnStatusChanged += UpdateVisualForStatus;
            }
        }

        private void OnDestroy()
        {
            if (partComponent != null)
            {
                partComponent.OnStatusChanged -= UpdateVisualForStatus;
            }
        }
        #endregion

        #region Visual Creation
        private void CreateVisual()
        {
            // Check if product has a custom sprite
            if (productData != null && productData.ProductIcon != null)
            {
                spriteRenderer.sprite = productData.ProductIcon;
            }
            else
            {
                // Create simple placeholder sprite
                CreatePlaceholderSprite();
            }

            // Set size (parts are small, ~0.3 units)
            transform.localScale = new Vector3(0.3f, 0.3f, 1f);

            // Set sorting order (above grid, below machines)
            spriteRenderer.sortingOrder = 5;

            // Set initial color based on product
            spriteRenderer.color = GetColorForProduct();
        }

        private void CreatePlaceholderSprite()
        {
            // Create a simple colored circle
            Texture2D texture = new Texture2D(32, 32);
            
            // Draw circle
            Vector2 center = new Vector2(16, 16);
            float radius = 14f;
            
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    float dist = Vector2.Distance(new Vector2(x, y), center);
                    if (dist < radius)
                    {
                        // Inside circle
                        texture.SetPixel(x, y, Color.white);
                    }
                    else if (dist < radius + 2f)
                    {
                        // Border
                        texture.SetPixel(x, y, Color.black);
                    }
                    else
                    {
                        // Outside (transparent)
                        texture.SetPixel(x, y, Color.clear);
                    }
                }
            }
            
            texture.Apply();

            Sprite sprite = Sprite.Create(
                texture,
                new Rect(0, 0, 32, 32),
                new Vector2(0.5f, 0.5f),
                32f
            );

            spriteRenderer.sprite = sprite;
        }

        private Color GetColorForProduct()
        {
            if (productData == null) return baseColor;

            // Different colors for different product types
            // You can customize this based on product ID or version
            int version = productData.Version;
            
            switch (version)
            {
                case 1:
                    return new Color(0.9f, 0.9f, 0.3f, 1f); // Yellow
                case 2:
                    return new Color(0.3f, 0.9f, 0.3f, 1f); // Green
                case 3:
                    return new Color(0.3f, 0.6f, 0.9f, 1f); // Blue
                default:
                    return baseColor;
            }
        }
        #endregion

        #region Status Visualization
        private void UpdateVisualForStatus(PartStatus status)
        {
            switch (status)
            {
                case PartStatus.WaitingForProcessing:
                    // Normal color, maybe slightly dimmed
                    spriteRenderer.color = GetColorForProduct() * 0.8f;
                    break;

                case PartStatus.InProcess:
                    // Brighten while being processed
                    spriteRenderer.color = GetColorForProduct() * 1.2f;
                    break;

                case PartStatus.QualityCheck:
                    // Pulse white during QC
                    spriteRenderer.color = Color.white;
                    break;

                case PartStatus.Passed:
                    // Green tint for passed parts
                    spriteRenderer.color = GetColorForProduct() * new Color(0.7f, 1f, 0.7f, 1f);
                    break;

                case PartStatus.Failed:
                    // Red for failed/scrapped
                    spriteRenderer.color = Color.red;
                    // Fade out and destroy
                    StartCoroutine(FadeOutAndDestroy());
                    break;

                case PartStatus.Shipped:
                    // Fade out when shipped
                    StartCoroutine(FadeOutAndDestroy());
                    break;
            }
        }

        private System.Collections.IEnumerator FadeOutAndDestroy()
        {
            float fadeTime = 0.5f;
            float elapsed = 0f;
            Color startColor = spriteRenderer.color;

            while (elapsed < fadeTime)
            {
                elapsed += Time.deltaTime;
                float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeTime);
                spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
                yield return null;
            }

            // Destroy the entire part GameObject after fade
            Destroy(gameObject);
        }
        #endregion

        #region Animation (Subtle Pulse)
        private void Update()
        {
            // Subtle pulsing effect when in process
            if (partComponent != null && partComponent.Status == PartStatus.InProcess)
            {
                float pulse = Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
                transform.localScale = new Vector3(0.3f + pulse, 0.3f + pulse, 1f);
            }
        }
        #endregion

        #region Mouse Interaction
        private void OnMouseEnter()
        {
            // Highlight on hover
            if (partComponent != null)
            {
                spriteRenderer.color = Color.white;
            }
        }

        private void OnMouseExit()
        {
            // Restore color
            if (partComponent != null)
            {
                UpdateVisualForStatus(partComponent.Status);
            }
        }

        private void OnMouseDown()
        {
            // Show part info
            if (partComponent != null)
            {
                UnityEngine.Debug.Log(partComponent.GetProductionHistory());
            }
        }
        #endregion
    }
}
