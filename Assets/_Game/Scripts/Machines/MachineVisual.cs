using UnityEngine;
using EngineAssemblyTycoon.Machines;

namespace EngineAssemblyTycoon.Core
{
    /// <summary>
    /// MachineVisual - Handles the visual representation of a machine
    /// Creates sprite, animations, and visual feedback
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class MachineVisual : MonoBehaviour
    {
        #region Private Fields
        private SpriteRenderer spriteRenderer;
        private MachineSO machineData;
        private Machine machineComponent;
        
        // Visual states
        private Color idleColor = new Color(0.7f, 0.7f, 0.7f, 1f);
        private Color runningColor = new Color(0.3f, 0.8f, 0.3f, 1f);
        private Color errorColor = new Color(0.8f, 0.3f, 0.3f, 1f);
        private Color maintenanceColor = new Color(0.8f, 0.6f, 0.2f, 1f);
        #endregion

        #region Initialization
        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            machineComponent = GetComponent<Machine>();
        }

        /// <summary>
        /// Initialize visual with machine data
        /// </summary>
        public void Initialize(MachineSO data)
        {
            machineData = data;
            CreateVisual();
            
            // Subscribe to machine status changes
            if (machineComponent != null)
            {
                machineComponent.OnStatusChanged += UpdateVisualForStatus;
            }
        }

        private void OnDestroy()
        {
            // Unsubscribe from events
            if (machineComponent != null)
            {
                machineComponent.OnStatusChanged -= UpdateVisualForStatus;
            }
        }
        #endregion

        #region Visual Creation
        private void CreateVisual()
        {
            if (machineData.MachineSprite != null)
            {
                // Use provided sprite
                spriteRenderer.sprite = machineData.MachineSprite;
            }
            else
            {
                // Create placeholder sprite
                CreatePlaceholderSprite();
            }

            // Set size based on machine grid size
            float width = machineData.GridWidth;
            float height = machineData.GridHeight;
            transform.localScale = new Vector3(width * 0.9f, height * 0.9f, 1f);

            // Set sorting order (above grid, below UI)
            spriteRenderer.sortingOrder = 0;

            // Set initial color
            spriteRenderer.color = idleColor;
        }

        private void CreatePlaceholderSprite()
        {
            // Create a simple colored square based on machine type
            Color machineColor = GetColorForMachineType(machineData.Type);

            Texture2D texture = new Texture2D(64, 64);
            
            // Fill with solid color
            for (int y = 0; y < 64; y++)
            {
                for (int x = 0; x < 64; x++)
                {
                    // Add border
                    if (x < 2 || x > 61 || y < 2 || y > 61)
                    {
                        texture.SetPixel(x, y, Color.black);
                    }
                    else
                    {
                        texture.SetPixel(x, y, machineColor);
                    }
                }
            }
            
            texture.Apply();

            Sprite sprite = Sprite.Create(
                texture,
                new Rect(0, 0, 64, 64),
                new Vector2(0.5f, 0.5f),
                64f
            );

            spriteRenderer.sprite = sprite;
        }

        private Color GetColorForMachineType(MachineType type)
        {
            // Different colors for different machine types (placeholder)
            switch (type)
            {
                case MachineType.CNC_Mill:
                    return new Color(0.5f, 0.5f, 0.8f, 1f); // Blue-ish
                case MachineType.CNC_Lathe:
                    return new Color(0.8f, 0.5f, 0.5f, 1f); // Red-ish
                case MachineType.Assembly:
                    return new Color(0.5f, 0.8f, 0.5f, 1f); // Green-ish
                case MachineType.Nutrunner:
                    return new Color(0.8f, 0.8f, 0.5f, 1f); // Yellow-ish
                case MachineType.QC_Station:
                    return new Color(0.8f, 0.5f, 0.8f, 1f); // Purple-ish
                default:
                    return Color.gray;
            }
        }
        #endregion

        #region Status Visualization
        private void UpdateVisualForStatus(MachineStatus newStatus)
        {
            switch (newStatus)
            {
                case MachineStatus.Idle:
                    spriteRenderer.color = idleColor;
                    break;
                case MachineStatus.Running:
                    spriteRenderer.color = runningColor;
                    // TODO: Add animation/particle effects
                    break;
                case MachineStatus.Error:
                    spriteRenderer.color = errorColor;
                    break;
                case MachineStatus.Maintenance:
                    spriteRenderer.color = maintenanceColor;
                    break;
                case MachineStatus.Offline:
                    spriteRenderer.color = new Color(0.3f, 0.3f, 0.3f, 0.5f);
                    break;
            }
        }
        #endregion

        #region Mouse Interaction (Show Info)
        private void OnMouseEnter()
        {
            // Highlight on hover
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.white, 0.3f);
            
            // TODO: Show tooltip with machine info
        }

        private void OnMouseExit()
        {
            // Restore color based on status
            if (machineComponent != null)
            {
                UpdateVisualForStatus(machineComponent.Status);
            }
        }

        private void OnMouseDown()
        {
            // Select machine (for future UI panel showing details)
            Debug.Log($"Clicked on machine: {machineData.DisplayName}");
            
            // TODO: Week 3 - Show machine detail panel
        }
        #endregion

        #region Debug
        private void OnDrawGizmosSelected()
        {
            // Draw machine bounds when selected in editor
            if (machineData != null)
            {
                Gizmos.color = Color.cyan;
                float width = machineData.GridWidth;
                float height = machineData.GridHeight;
                Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
            }
        }
        #endregion
    }
}
