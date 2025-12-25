using UnityEngine;
using EngineAssemblyTycoon.Core;

namespace EngineAssemblyTycoon.DevTools
{
    /// <summary>
    /// DebugConsole - Developer debug menu for testing and debugging
    /// Toggle with ~ (tilde) key or F1
    /// Should be disabled in production builds
    /// </summary>
    public class DebugConsole : MonoBehaviour
    {
        #region Settings
        [Header("Debug Settings")]
        [SerializeField] private KeyCode toggleKey = KeyCode.BackQuote; // ~ key
        [SerializeField] private KeyCode alternateToggleKey = KeyCode.F1;
        [SerializeField] private bool enabledInBuild = false; // Disable in production
        #endregion

        #region Private Fields
        private bool isVisible = false;
        private Rect windowRect = new Rect(20, 20, 400, 600);
        private Vector2 scrollPosition;
        private string customCashAmount = "10000";
        private string customXPAmount = "1000";
        #endregion

        #region Unity Lifecycle
        private void Start()
        {
            // Disable in production builds if configured
            #if !UNITY_EDITOR
            if (!enabledInBuild)
            {
                enabled = false;
                return;
            }
            #endif

            UnityEngine.Debug.Log("Debug Console initialized. Press ~ or F1 to toggle.");
        }

        private void Update()
        {
            // Toggle visibility
            if (Input.GetKeyDown(toggleKey) || Input.GetKeyDown(alternateToggleKey))
            {
                isVisible = !isVisible;
            }
        }

        private void OnGUI()
        {
            if (!isVisible) return;

            // Draw debug window
            windowRect = GUILayout.Window(0, windowRect, DrawDebugWindow, "🛠️ DEBUG CONSOLE");
        }
        #endregion

        #region Debug Window GUI
        private void DrawDebugWindow(int windowID)
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);

            GUILayout.Label("=== ECONOMY ===", GetHeaderStyle());
            DrawEconomySection();

            GUILayout.Space(10);
            GUILayout.Label("=== PROGRESSION ===", GetHeaderStyle());
            DrawProgressionSection();

            GUILayout.Space(10);
            GUILayout.Label("=== PRODUCTION ===", GetHeaderStyle());
            DrawProductionSection();

            GUILayout.Space(10);
            GUILayout.Label("=== MACHINES ===", GetHeaderStyle());
            DrawMachinesSection();

            GUILayout.Space(10);
            GUILayout.Label("=== GAME STATE ===", GetHeaderStyle());
            DrawGameStateSection();

            GUILayout.Space(10);
            GUILayout.Label("=== SYSTEM ===", GetHeaderStyle());
            DrawSystemSection();

            GUILayout.EndScrollView();

            // Make window draggable
            GUI.DragWindow(new Rect(0, 0, 10000, 20));
        }
        #endregion

        #region Economy Section
        private void DrawEconomySection()
        {
            if (GameManager.Instance == null)
            {
                GUILayout.Label("⚠️ GameManager not found!");
                return;
            }

            // Current cash display
            GUILayout.Label($"Current Cash: ${GameManager.Instance.Cash:N0}");

            // Add cash buttons
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("+$10,000"))
            {
                GameManager.Instance.AddCash(10000f);
                UnityEngine.Debug.Log("DEBUG: Added $10,000");
            }
            if (GUILayout.Button("+$100,000"))
            {
                GameManager.Instance.AddCash(100000f);
                UnityEngine.Debug.Log("DEBUG: Added $100,000");
            }
            if (GUILayout.Button("+$1,000,000"))
            {
                GameManager.Instance.AddCash(1000000f);
                UnityEngine.Debug.Log("DEBUG: Added $1,000,000");
            }
            GUILayout.EndHorizontal();

            // Custom cash amount
            GUILayout.BeginHorizontal();
            GUILayout.Label("Custom Amount:", GUILayout.Width(120));
            customCashAmount = GUILayout.TextField(customCashAmount, GUILayout.Width(100));
            if (GUILayout.Button("Add"))
            {
                if (float.TryParse(customCashAmount, out float amount))
                {
                    GameManager.Instance.AddCash(amount);
                    UnityEngine.Debug.Log($"DEBUG: Added ${amount:N0}");
                }
            }
            GUILayout.EndHorizontal();

            // Set infinite cash
            if (GUILayout.Button("🔓 Set Infinite Cash ($999,999,999)"))
            {
                GameManager.Instance.AddCash(999999999f);
                UnityEngine.Debug.Log("DEBUG: Infinite cash enabled");
            }

            // Challenge Points
            GUILayout.Space(5);
            GUILayout.Label($"Challenge Points: {GameManager.Instance.ChallengePoints}");
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("+1,000 CP"))
            {
                GameManager.Instance.AddChallengePoints(1000);
            }
            if (GUILayout.Button("+10,000 CP"))
            {
                GameManager.Instance.AddChallengePoints(10000);
            }
            GUILayout.EndHorizontal();
        }
        #endregion

        #region Progression Section
        private void DrawProgressionSection()
        {
            if (GameManager.Instance == null) return;

            GUILayout.Label($"Current Level: {GameManager.Instance.PlayerLevel}");
            GUILayout.Label($"XP: {GameManager.Instance.CurrentXP} / {GameManager.Instance.XPToNextLevel}");

            // Add XP buttons
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("+500 XP"))
            {
                GameManager.Instance.AddXP(500);
            }
            if (GUILayout.Button("+5,000 XP"))
            {
                GameManager.Instance.AddXP(5000);
            }
            if (GUILayout.Button("Level Up"))
            {
                GameManager.Instance.AddXP(GameManager.Instance.XPToNextLevel);
            }
            GUILayout.EndHorizontal();

            // Custom XP amount
            GUILayout.BeginHorizontal();
            GUILayout.Label("Custom XP:", GUILayout.Width(120));
            customXPAmount = GUILayout.TextField(customXPAmount, GUILayout.Width(100));
            if (GUILayout.Button("Add"))
            {
                if (int.TryParse(customXPAmount, out int xp))
                {
                    GameManager.Instance.AddXP(xp);
                }
            }
            GUILayout.EndHorizontal();

            // Max level
            if (GUILayout.Button("🚀 Jump to Level 25"))
            {
                while (GameManager.Instance.PlayerLevel < 25)
                {
                    GameManager.Instance.AddXP(GameManager.Instance.XPToNextLevel);
                }
                UnityEngine.Debug.Log("DEBUG: Jumped to max level");
            }
        }
        #endregion

        #region Production Section
        private void DrawProductionSection()
        {
            // TODO: Week 3 - Add production debug options
            GUILayout.Label("(Production controls coming in Week 3)");
            
            // Placeholder buttons for future
            GUI.enabled = false;
            if (GUILayout.Button("Spawn 10 Parts")) { }
            if (GUILayout.Button("Complete All Parts Instantly")) { }
            if (GUILayout.Button("Clear All Parts")) { }
            GUI.enabled = true;
        }
        #endregion

        #region Machines Section
        private void DrawMachinesSection()
        {
            // TODO: Week 3 - Add machine debug options
            GUILayout.Label("(Machine controls coming in Week 3)");
            
            // Placeholder buttons for future
            GUI.enabled = false;
            if (GUILayout.Button("Fix All Broken Machines")) { }
            if (GUILayout.Button("Reset All Tool Wear")) { }
            if (GUILayout.Button("Delete All Machines")) { }
            GUI.enabled = true;
        }
        #endregion

        #region Game State Section
        private void DrawGameStateSection()
        {
            if (GUILayout.Button("⏸️ Pause Game"))
            {
                Time.timeScale = 0f;
                UnityEngine.Debug.Log("DEBUG: Game paused");
            }

            if (GUILayout.Button("▶️ Resume Game"))
            {
                Time.timeScale = 1f;
                UnityEngine.Debug.Log("DEBUG: Game resumed");
            }

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("⏩ 2x Speed"))
            {
                Time.timeScale = 2f;
                UnityEngine.Debug.Log("DEBUG: 2x speed");
            }
            if (GUILayout.Button("⏩⏩ 5x Speed"))
            {
                Time.timeScale = 5f;
                UnityEngine.Debug.Log("DEBUG: 5x speed");
            }
            GUILayout.EndHorizontal();

            GUILayout.Space(5);
            GUILayout.Label($"Current Time Scale: {Time.timeScale:F1}x");
        }
        #endregion

        #region System Section
        private void DrawSystemSection()
        {
            if (GUILayout.Button("📋 Log System Info"))
            {
                LogSystemInfo();
            }

            if (GUILayout.Button("🗑️ Clear Console"))
            {
                ClearConsole();
            }

            if (GUILayout.Button("💾 Force Save (Future)"))
            {
                UnityEngine.Debug.Log("Save system not implemented yet");
            }

            GUILayout.Space(5);
            GUILayout.Label($"FPS: {(int)(1f / Time.deltaTime)}");
            GUILayout.Label($"Memory: {System.GC.GetTotalMemory(false) / 1048576}MB");
        }
        #endregion

        #region Helper Methods
        private GUIStyle GetHeaderStyle()
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.fontStyle = FontStyle.Bold;
            style.fontSize = 14;
            return style;
        }

        private void LogSystemInfo()
        {
            UnityEngine.Debug.Log("=== SYSTEM INFO ===");
            UnityEngine.Debug.Log($"Unity Version: {Application.unityVersion}");
            UnityEngine.Debug.Log($"Platform: {Application.platform}");
            UnityEngine.Debug.Log($"Screen: {Screen.width}x{Screen.height}");
            
            if (GameManager.Instance != null)
            {
                UnityEngine.Debug.Log($"Cash: ${GameManager.Instance.Cash:N0}");
                UnityEngine.Debug.Log($"Level: {GameManager.Instance.PlayerLevel}");
            }

            if (GridManager.Instance != null)
            {
                UnityEngine.Debug.Log($"Grid: {GridManager.Instance.GridWidth}x{GridManager.Instance.GridHeight}");
            }
        }

        private void ClearConsole()
        {
            #if UNITY_EDITOR
            var assembly = System.Reflection.Assembly.GetAssembly(typeof(UnityEditor.Editor));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
            #endif
            UnityEngine.Debug.Log("Console cleared");
        }
        #endregion
    }
}
