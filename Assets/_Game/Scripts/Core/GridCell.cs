using UnityEngine;

namespace EngineAssemblyTycoon.Core
{
    /// <summary>
    /// GridCell - Represents a single cell in the factory grid
    /// Handles visual feedback, occupancy state, and mouse interaction
    /// </summary>
    public class GridCell : MonoBehaviour
    {
        #region Private Fields
        private int gridX;
        private int gridY;
        private bool isOccupied = false;
        private GameObject occupyingObject = null;
        private GridManager gridManager;
        private SpriteRenderer spriteRenderer;
        
        // Colors
        private Color normalColor = new Color(0.2f, 0.2f, 0.2f, 1f);
        private Color hoverColor = new Color(0.3f, 0.5f, 0.3f, 1f);
        private Color occupiedColor = new Color(0.5f, 0.2f, 0.2f, 1f);
        #endregion

        #region Properties
        public int GridX => gridX;
        public int GridY => gridY;
        public bool IsOccupied => isOccupied;
        public GameObject OccupyingObject => occupyingObject;
        #endregion

        #region Initialization
        /// <summary>
        /// Initialize this cell with its grid coordinates
        /// Called by GridManager when cell is created
        /// </summary>
        public void Initialize(int x, int y, GridManager manager)
        {
            gridX = x;
            gridY = y;
            gridManager = manager;
            
            // Get sprite renderer
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = normalColor;
            }
        }
        #endregion

        #region Occupancy Management
        /// <summary>
        /// Set whether this cell is occupied
        /// </summary>
        public void SetOccupied(bool occupied, GameObject occupant = null)
        {
            isOccupied = occupied;
            occupyingObject = occupant;
            
            UpdateVisual();
        }

        /// <summary>
        /// Update cell visual based on state
        /// </summary>
        private void UpdateVisual()
        {
            if (spriteRenderer == null) return;
            
            if (isOccupied)
            {
                spriteRenderer.color = occupiedColor;
            }
            else
            {
                spriteRenderer.color = normalColor;
            }
        }
        #endregion

        #region Mouse Interaction
        private void OnMouseEnter()
        {
            if (!isOccupied && spriteRenderer != null)
            {
                spriteRenderer.color = hoverColor;
            }
            
            // Could trigger tooltip here in future
            // Debug.Log($"Mouse over cell ({gridX}, {gridY})");
        }

        private void OnMouseExit()
        {
            UpdateVisual();
        }

        private void OnMouseDown()
        {
            // Handle cell click (for machine placement, etc.)
            Debug.Log($"Clicked cell ({gridX}, {gridY}) - Occupied: {isOccupied}");
            
            // TODO: Week 2 - Trigger machine placement here
        }
        #endregion

        #region Debug
        /// <summary>
        /// Display cell info in Inspector
        /// </summary>
        private void OnValidate()
        {
            gameObject.name = $"Cell_{gridX}_{gridY}";
        }
        #endregion
    }
}
