using UnityEngine;

namespace EngineAssemblyTycoon.Core
{
    /// <summary>
    /// GridManager - Creates and manages the factory floor grid
    /// Handles grid creation, cell tracking, and coordinate conversion
    /// </summary>
    public class GridManager : MonoBehaviour
    {
        #region Singleton
        private static GridManager _instance;
        public static GridManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<GridManager>();
                }
                return _instance;
            }
        }
        #endregion

        #region Grid Settings
        [Header("Grid Configuration")]
        [SerializeField] private int gridWidth = 30;
        [SerializeField] private int gridHeight = 30;
        [SerializeField] private float cellSize = 1f; // 1 Unity unit = 1 meter = 1 cell
        
        [Header("Visual Settings")]
        [SerializeField] private Color gridLineColor = new Color(0.3f, 0.3f, 0.3f, 0.5f);
        [SerializeField] private Color cellAvailableColor = new Color(0.2f, 0.2f, 0.2f, 1f);
        [SerializeField] private Color cellOccupiedColor = new Color(0.5f, 0.2f, 0.2f, 1f);
        
        [Header("Prefabs")]
        [SerializeField] private GameObject gridCellPrefab;
        #endregion

        #region Private Fields
        private GridCell[,] cells; // 2D array of all grid cells
        private Transform gridParent; // Parent object to hold all cells
        #endregion

        #region Properties
        public int GridWidth => gridWidth;
        public int GridHeight => gridHeight;
        public float CellSize => cellSize;
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

        private void Start()
        {
            CreateGrid();
        }
        #endregion

        #region Grid Creation
        /// <summary>
        /// Creates the visual grid of cells
        /// </summary>
        private void CreateGrid()
        {
            Debug.Log($"Creating factory grid: {gridWidth}x{gridHeight} cells");

            // Create parent object to organize hierarchy
            gridParent = new GameObject("Grid").transform;
            gridParent.SetParent(transform);
            gridParent.localPosition = Vector3.zero;

            // Initialize 2D array
            cells = new GridCell[gridWidth, gridHeight];

            // Create each cell
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    CreateCell(x, y);
                }
            }

            Debug.Log($"Grid created successfully. Total cells: {gridWidth * gridHeight}");
        }

        /// <summary>
        /// Creates a single grid cell at specified coordinates
        /// </summary>
        private void CreateCell(int x, int y)
        {
            GameObject cellObj;

            if (gridCellPrefab != null)
            {
                // Use prefab if assigned
                cellObj = Instantiate(gridCellPrefab, gridParent);
            }
            else
            {
                // Create simple quad if no prefab
                cellObj = CreateSimpleCell();
            }

            // Position the cell
            Vector3 worldPos = GridToWorldPosition(x, y);
            cellObj.transform.position = worldPos;
            cellObj.name = $"Cell_{x}_{y}";

            // Add or get GridCell component
            GridCell cellComponent = cellObj.GetComponent<GridCell>();
            if (cellComponent == null)
            {
                cellComponent = cellObj.AddComponent<GridCell>();
            }

            // Initialize the cell
            cellComponent.Initialize(x, y, this);

            // Store in array
            cells[x, y] = cellComponent;
        }

        /// <summary>
        /// Creates a simple quad sprite for a cell (fallback if no prefab)
        /// </summary>
        private GameObject CreateSimpleCell()
        {
            GameObject cell = new GameObject();
            
            // Add sprite renderer
            SpriteRenderer sr = cell.AddComponent<SpriteRenderer>();
            
            // Create a simple white square sprite
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, cellAvailableColor);
            texture.Apply();
            
            Sprite sprite = Sprite.Create(
                texture,
                new Rect(0, 0, 1, 1),
                new Vector2(0.5f, 0.5f),
                1f // Pixels per unit
            );
            
            sr.sprite = sprite;
            sr.sortingOrder = -10; // Behind everything else
            
            // Scale to cell size (slightly smaller to show grid lines)
            cell.transform.localScale = new Vector3(cellSize * 0.95f, cellSize * 0.95f, 1f);
            
            // Add box collider for mouse interaction
            BoxCollider2D collider = cell.AddComponent<BoxCollider2D>();
            collider.size = Vector2.one;
            
            return cell;
        }
        #endregion

        #region Coordinate Conversion
        /// <summary>
        /// Convert grid coordinates to world position
        /// </summary>
        public Vector3 GridToWorldPosition(int x, int y)
        {
            // Center the grid at origin
            float offsetX = -gridWidth * cellSize / 2f;
            float offsetY = -gridHeight * cellSize / 2f;
            
            float worldX = offsetX + (x * cellSize) + (cellSize / 2f);
            float worldY = offsetY + (y * cellSize) + (cellSize / 2f);
            
            return new Vector3(worldX, worldY, 0f);
        }

        /// <summary>
        /// Convert world position to grid coordinates
        /// Returns false if position is outside grid
        /// </summary>
        public bool WorldToGridPosition(Vector3 worldPos, out int x, out int y)
        {
            float offsetX = -gridWidth * cellSize / 2f;
            float offsetY = -gridHeight * cellSize / 2f;
            
            x = Mathf.FloorToInt((worldPos.x - offsetX) / cellSize);
            y = Mathf.FloorToInt((worldPos.y - offsetY) / cellSize);
            
            // Check if within bounds
            return x >= 0 && x < gridWidth && y >= 0 && y < gridHeight;
        }
        #endregion

        #region Cell Queries
        /// <summary>
        /// Get cell at grid coordinates
        /// </summary>
        public GridCell GetCell(int x, int y)
        {
            if (x < 0 || x >= gridWidth || y < 0 || y >= gridHeight)
            {
                return null;
            }
            return cells[x, y];
        }

        /// <summary>
        /// Check if a rectangular area is available (for machine placement)
        /// </summary>
        public bool IsAreaAvailable(int startX, int startY, int width, int height)
        {
            for (int x = startX; x < startX + width; x++)
            {
                for (int y = startY; y < startY + height; y++)
                {
                    GridCell cell = GetCell(x, y);
                    if (cell == null || cell.IsOccupied)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Mark a rectangular area as occupied (when machine placed)
        /// </summary>
        public void OccupyArea(int startX, int startY, int width, int height, GameObject occupant)
        {
            for (int x = startX; x < startX + width; x++)
            {
                for (int y = startY; y < startY + height; y++)
                {
                    GridCell cell = GetCell(x, y);
                    if (cell != null)
                    {
                        cell.SetOccupied(true, occupant);
                    }
                }
            }
            Debug.Log($"Occupied area at ({startX}, {startY}) size {width}x{height}");
        }

        /// <summary>
        /// Clear a rectangular area (when machine removed)
        /// </summary>
        public void ClearArea(int startX, int startY, int width, int height)
        {
            for (int x = startX; x < startX + width; x++)
            {
                for (int y = startY; y < startY + height; y++)
                {
                    GridCell cell = GetCell(x, y);
                    if (cell != null)
                    {
                        cell.SetOccupied(false, null);
                    }
                }
            }
            Debug.Log($"Cleared area at ({startX}, {startY}) size {width}x{height}");
        }
        #endregion

        #region Debug Visualization
        private void OnDrawGizmos()
        {
            // Draw grid lines in editor
            if (!Application.isPlaying)
            {
                Gizmos.color = gridLineColor;
                
                float offsetX = -gridWidth * cellSize / 2f;
                float offsetY = -gridHeight * cellSize / 2f;
                
                // Vertical lines
                for (int x = 0; x <= gridWidth; x++)
                {
                    float xPos = offsetX + (x * cellSize);
                    Gizmos.DrawLine(
                        new Vector3(xPos, offsetY, 0),
                        new Vector3(xPos, offsetY + (gridHeight * cellSize), 0)
                    );
                }
                
                // Horizontal lines
                for (int y = 0; y <= gridHeight; y++)
                {
                    float yPos = offsetY + (y * cellSize);
                    Gizmos.DrawLine(
                        new Vector3(offsetX, yPos, 0),
                        new Vector3(offsetX + (gridWidth * cellSize), yPos, 0)
                    );
                }
            }
        }
        #endregion
    }
}
