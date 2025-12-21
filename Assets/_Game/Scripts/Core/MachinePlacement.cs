using UnityEngine;
using EngineAssemblyTycoon.Machines;

namespace EngineAssemblyTycoon.Core
{
    /// <summary>
    /// MachinePlacement - Handles the machine placement system
    /// Allows player to place machines on the factory grid
    /// </summary>
    public class MachinePlacement : MonoBehaviour
    {
        #region Singleton
        private static MachinePlacement _instance;
        public static MachinePlacement Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<MachinePlacement>();
                }
                return _instance;
            }
        }
        #endregion

        #region Settings
        [Header("Placement Settings")]
        [SerializeField] private GameObject machinePrefab; // Prefab with Machine component
        [SerializeField] private LayerMask gridLayer; // Layer for detecting grid cells
        
        [Header("Visual Feedback")]
        [SerializeField] private Color validPlacementColor = new Color(0.3f, 1f, 0.3f, 0.5f);
        [SerializeField] private Color invalidPlacementColor = new Color(1f, 0.3f, 0.3f, 0.5f);
        #endregion

        #region Private Fields
        private bool isPlacingMachine = false;
        private GameObject ghostMachine; // Visual preview of machine being placed
        private MachineSO machineDataToPlace;
        private SpriteRenderer ghostRenderer;
        #endregion

        #region Properties
        public bool IsPlacingMachine => isPlacingMachine;
        #endregion

        #region Unity Lifecycle
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
        }

        private void Update()
        {
            if (isPlacingMachine)
            {
                UpdateGhostPosition();
                HandlePlacementInput();
            }
        }
        #endregion

        #region Placement Control
        /// <summary>
        /// Start placing a machine of specified type
        /// </summary>
        public void StartPlacingMachine(MachineSO machineData)
        {
            if (isPlacingMachine)
            {
                CancelPlacement();
            }

            machineDataToPlace = machineData;
            isPlacingMachine = true;

            CreateGhostMachine();
            
            Debug.Log($"Started placing machine: {machineData.DisplayName}");
        }

        /// <summary>
        /// Cancel current placement
        /// </summary>
        public void CancelPlacement()
        {
            if (ghostMachine != null)
            {
                Destroy(ghostMachine);
            }
            
            isPlacingMachine = false;
            machineDataToPlace = null;
            ghostRenderer = null;
            
            Debug.Log("Placement cancelled");
        }
        #endregion

        #region Ghost Machine (Visual Preview)
        private void CreateGhostMachine()
        {
            // Create ghost machine for preview
            ghostMachine = new GameObject("GhostMachine");
            
            // Add sprite renderer
            ghostRenderer = ghostMachine.AddComponent<SpriteRenderer>();
            
            // Create simple colored sprite (placeholder)
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, Color.white);
            texture.Apply();
            
            Sprite sprite = Sprite.Create(
                texture,
                new Rect(0, 0, 1, 1),
                new Vector2(0.5f, 0.5f),
                1f
            );
            
            ghostRenderer.sprite = sprite;
            ghostRenderer.sortingOrder = 10; // Above grid
            
            // Scale to machine size
            float width = machineDataToPlace.GridWidth;
            float height = machineDataToPlace.GridHeight;
            ghostMachine.transform.localScale = new Vector3(width * 0.9f, height * 0.9f, 1f);
            
            // Set initial color
            ghostRenderer.color = validPlacementColor;
        }

        private void UpdateGhostPosition()
        {
            if (ghostMachine == null || GridManager.Instance == null) return;

            // Get mouse position in world
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            // Convert to grid coordinates
            if (GridManager.Instance.WorldToGridPosition(mouseWorldPos, out int gridX, out int gridY))
            {
                // Check if placement is valid
                bool canPlace = GridManager.Instance.IsAreaAvailable(
                    gridX, 
                    gridY, 
                    machineDataToPlace.GridWidth, 
                    machineDataToPlace.GridHeight
                );

                // Update ghost color
                ghostRenderer.color = canPlace ? validPlacementColor : invalidPlacementColor;

                // Snap to grid
                Vector3 snapPos = GridManager.Instance.GridToWorldPosition(gridX, gridY);
                
                // Offset for multi-cell machines (center them)
                snapPos.x += (machineDataToPlace.GridWidth - 1) * GridManager.Instance.CellSize / 2f;
                snapPos.y += (machineDataToPlace.GridHeight - 1) * GridManager.Instance.CellSize / 2f;
                
                ghostMachine.transform.position = snapPos;
            }
            else
            {
                // Outside grid bounds
                ghostRenderer.color = invalidPlacementColor;
                ghostMachine.transform.position = mouseWorldPos;
            }
        }
        #endregion

        #region Placement Input
        private void HandlePlacementInput()
        {
            // Left click to place
            if (Input.GetMouseButtonDown(0))
            {
                TryPlaceMachine();
            }

            // Right click or ESC to cancel
            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
            {
                CancelPlacement();
            }
        }

        private void TryPlaceMachine()
        {
            if (GridManager.Instance == null) return;

            // Get current grid position
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            if (!GridManager.Instance.WorldToGridPosition(mouseWorldPos, out int gridX, out int gridY))
            {
                Debug.LogWarning("Cannot place outside grid bounds!");
                return;
            }

            // Check if area is available
            bool canPlace = GridManager.Instance.IsAreaAvailable(
                gridX,
                gridY,
                machineDataToPlace.GridWidth,
                machineDataToPlace.GridHeight
            );

            if (!canPlace)
            {
                Debug.LogWarning("Cannot place machine here - area occupied!");
                return;
            }

            // Check if player can afford it
            if (GameManager.Instance != null)
            {
                if (!GameManager.Instance.SpendCash(machineDataToPlace.PurchaseCost))
                {
                    Debug.LogWarning($"Cannot afford {machineDataToPlace.DisplayName}! Cost: ${machineDataToPlace.PurchaseCost}");
                    return;
                }
            }

            // Place the machine!
            PlaceMachine(gridX, gridY);
        }

        private void PlaceMachine(int gridX, int gridY)
        {
            // Calculate world position
            Vector3 worldPos = GridManager.Instance.GridToWorldPosition(gridX, gridY);
            
            // Offset for multi-cell machines
            worldPos.x += (machineDataToPlace.GridWidth - 1) * GridManager.Instance.CellSize / 2f;
            worldPos.y += (machineDataToPlace.GridHeight - 1) * GridManager.Instance.CellSize / 2f;

            // Create machine GameObject
            GameObject machineObj = new GameObject(machineDataToPlace.DisplayName);
            machineObj.transform.position = worldPos;

            // Add Machine component
            Machine machineComponent = machineObj.AddComponent<Machine>();
            
            // Add visual component
            MachineVisual visualComponent = machineObj.AddComponent<MachineVisual>();
            visualComponent.Initialize(machineDataToPlace);

            // Occupy grid cells
            GridManager.Instance.OccupyArea(
                gridX,
                gridY,
                machineDataToPlace.GridWidth,
                machineDataToPlace.GridHeight,
                machineObj
            );

            Debug.Log($"Placed {machineDataToPlace.DisplayName} at ({gridX}, {gridY})");

            // Continue placement mode (or cancel if you want one-at-a-time)
            // For now, let's cancel so player must click button again
            CancelPlacement();
        }
        #endregion

        #region Public Helper Methods
        /// <summary>
        /// Start placing a CNC machine (called from UI button)
        /// </summary>
        public void StartPlacingCNC(MachineSO cncMachineData)
        {
            StartPlacingMachine(cncMachineData);
        }
        #endregion
    }
}
