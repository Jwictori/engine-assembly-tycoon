using UnityEngine;
using System.Collections;

namespace EngineAssemblyTycoon.Core
{
    /// <summary>
    /// PartSpawner - Creates new parts and introduces them to the factory
    /// Acts as the "raw material input" in the production line
    /// </summary>
    public class PartSpawner : MonoBehaviour
    {
        #region Settings
        [Header("Spawn Configuration")]
        [SerializeField] private ProductSO productToSpawn;
        [SerializeField] private float spawnInterval = 10f; // Seconds between spawns
        [SerializeField] private bool autoSpawn = true;
        [SerializeField] private int maxActiveParts = 20; // Prevent infinite spawning
        
        [Header("Spawn Location")]
        [SerializeField] private Transform spawnPoint; // Where parts appear
        [SerializeField] private Vector2 gridSpawnPosition = new Vector2(0, 0);
        
        [Header("References")]
        [SerializeField] private GameObject partPrefab; // Will create if null
        #endregion

        #region Private Fields
        private int totalPartsSpawned = 0;
        private int activePartsCount = 0;
        private float timeSinceLastSpawn = 0f;
        private bool isSpawning = false;
        #endregion

        #region Properties
        public int TotalPartsSpawned => totalPartsSpawned;
        public int ActivePartsCount => activePartsCount;
        public bool IsSpawning => isSpawning;
        #endregion

        #region Unity Lifecycle
        private void Start()
        {
            // Set spawn point if not assigned
            if (spawnPoint == null)
            {
                spawnPoint = transform;
            }

            // Start auto-spawning if enabled
            if (autoSpawn)
            {
                StartSpawning();
            }

            UnityEngine.Debug.Log($"PartSpawner initialized. Product: {(productToSpawn != null ? productToSpawn.ProductName : "None")}");
        }

        private void Update()
        {
            if (!isSpawning || !autoSpawn) return;

            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= spawnInterval)
            {
                // Check if we haven't exceeded max parts
                if (activePartsCount < maxActiveParts)
                {
                    SpawnPart();
                    timeSinceLastSpawn = 0f;
                }
                else
                {
                    UnityEngine.Debug.LogWarning($"Max active parts reached ({maxActiveParts}). Waiting for parts to complete.");
                }
            }
        }
        #endregion

        #region Spawning Control
        /// <summary>
        /// Start automatic part spawning
        /// </summary>
        public void StartSpawning()
        {
            isSpawning = true;
            timeSinceLastSpawn = 0f;
            UnityEngine.Debug.Log($"Started spawning {productToSpawn?.ProductName ?? "parts"}");
        }

        /// <summary>
        /// Stop automatic part spawning
        /// </summary>
        public void StopSpawning()
        {
            isSpawning = false;
            UnityEngine.Debug.Log("Stopped spawning parts");
        }

        /// <summary>
        /// Spawn a single part immediately
        /// </summary>
        public Part SpawnPart()
        {
            if (productToSpawn == null)
            {
                UnityEngine.Debug.LogError("Cannot spawn part - no product assigned!");
                return null;
            }

            // Create part GameObject
            GameObject partObj = CreatePartObject();
            if (partObj == null) return null;

            // Position at spawn point
            Vector3 worldPos;
            if (GridManager.Instance != null)
            {
                worldPos = GridManager.Instance.GridToWorldPosition((int)gridSpawnPosition.x, (int)gridSpawnPosition.y);
            }
            else
            {
                worldPos = spawnPoint.position;
            }
            partObj.transform.position = worldPos;

            // Get Part component
            Part part = partObj.GetComponent<Part>();
            if (part == null)
            {
                part = partObj.AddComponent<Part>();
            }

            // Initialize part with product data
            string lotNumber = GenerateLotNumber();
            part.Initialize(productToSpawn, lotNumber);

            // Register with ProductionManager
            if (ProductionManager.Instance != null)
            {
                ProductionManager.Instance.RegisterPart(part);
                UnityEngine.Debug.Log($"[SPAWNER] Registered part {part.PartID} with ProductionManager");
            }
            else
            {
                UnityEngine.Debug.LogError("[SPAWNER] ProductionManager not found");
            }

            if (ProductionManager.Instance != null)
            {
                ProductionManager.Instance.RoutePartToNextStation(part);
            }

            // Add visual component
            PartVisual visual = partObj.GetComponent<PartVisual>();
            if (visual == null)
            {
                visual = partObj.AddComponent<PartVisual>();
            }
            visual.Initialize(productToSpawn);

            // Subscribe to part completion
            part.OnStatusChanged += HandlePartStatusChanged;

            // Update counters
            totalPartsSpawned++;
            activePartsCount++;

            UnityEngine.Debug.Log($"Spawned part: {part.PartID} (Total: {totalPartsSpawned}, Active: {activePartsCount})");

            return part;
        }

        /// <summary>
        /// Spawn multiple parts at once (for testing)
        /// </summary>
        public void SpawnMultipleParts(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (activePartsCount >= maxActiveParts)
                {
                    UnityEngine.Debug.LogWarning($"Stopped spawning at {i} parts (max reached)");
                    break;
                }
                SpawnPart();
            }
        }
        #endregion

        #region Part Creation
        private GameObject CreatePartObject()
        {
            GameObject partObj;

            if (partPrefab != null)
            {
                // Use prefab if assigned
                partObj = Instantiate(partPrefab);
            }
            else
            {
                // Create simple part object
                partObj = new GameObject("Part");
            }

            return partObj;
        }

        private string GenerateLotNumber()
        {
            // Generate material lot number (for traceability)
            // Format: LOT-YYYYMMDD-XXX
            System.DateTime now = System.DateTime.Now;
            int randomNum = Random.Range(100, 999);
            return $"LOT-{now:yyyyMMdd}-{randomNum}";
        }
        #endregion

        #region Event Handlers
        private void HandlePartStatusChanged(PartStatus newStatus)
        {
            // When part is delivered or scrapped, reduce active count
            if (newStatus == PartStatus.Shipped || newStatus == PartStatus.Failed)
            {
                activePartsCount--;
                UnityEngine.Debug.Log($"Part completed. Active parts: {activePartsCount}");
            }
        }
        #endregion

        #region Public Helpers
        /// <summary>
        /// Set the product to spawn
        /// </summary>
        public void SetProduct(ProductSO product)
        {
            productToSpawn = product;
            UnityEngine.Debug.Log($"PartSpawner now spawning: {product.ProductName}");
        }

        /// <summary>
        /// Set spawn interval (seconds between parts)
        /// </summary>
        public void SetSpawnInterval(float seconds)
        {
            spawnInterval = Mathf.Max(0.1f, seconds);
            UnityEngine.Debug.Log($"Spawn interval set to {spawnInterval}s");
        }
        #endregion

        #region Debug Visualization
        private void OnDrawGizmos()
        {
            // Draw spawn point
            Vector3 spawnPos;
            if (GridManager.Instance != null && Application.isPlaying)
            {
                spawnPos = GridManager.Instance.GridToWorldPosition((int)gridSpawnPosition.x, (int)gridSpawnPosition.y);
            }
            else if (spawnPoint != null)
            {
                spawnPos = spawnPoint.position;
            }
            else
            {
                spawnPos = transform.position;
            }

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(spawnPos, 0.3f);
            Gizmos.DrawLine(spawnPos, spawnPos + Vector3.up * 0.5f);
        }

        private void OnDrawGizmosSelected()
        {
            // Draw spawn range
            if (spawnPoint != null)
            {
                Gizmos.color = new Color(0, 1, 0, 0.3f);
                Gizmos.DrawSphere(spawnPoint.position, 0.5f);
            }
        }
        #endregion
    }
}
