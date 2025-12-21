using UnityEngine;
using TMPro; // TextMeshPro for better text rendering
using EngineAssemblyTycoon.Core;

namespace EngineAssemblyTycoon.UI
{
    /// <summary>
    /// UIManager - Manages all UI elements
    /// Displays cash, buttons, and other interface elements
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        #region Singleton
        private static UIManager _instance;
        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<UIManager>();
                }
                return _instance;
            }
        }
        #endregion

        #region UI References
        [Header("UI Elements")]
        [SerializeField] private TextMeshProUGUI cashText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI xpText;
        
        [Header("Panels (Optional for Week 2)")]
        [SerializeField] private GameObject machineShopPanel;
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
            // Subscribe to GameManager events
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnCashChanged += UpdateCashDisplay;
                GameManager.Instance.OnLevelUp += UpdateLevelDisplay;
                GameManager.Instance.OnXPGained += UpdateXPDisplay;
            }
            
            // Initial update
            UpdateAllDisplays();
        }

        private void OnDestroy()
        {
            // Unsubscribe from events
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnCashChanged -= UpdateCashDisplay;
                GameManager.Instance.OnLevelUp -= UpdateLevelDisplay;
                GameManager.Instance.OnXPGained -= UpdateXPDisplay;
            }
        }
        #endregion

        #region Display Updates
        /// <summary>
        /// Update all UI elements at once
        /// </summary>
        public void UpdateAllDisplays()
        {
            if (GameManager.Instance != null)
            {
                UpdateCashDisplay((int)GameManager.Instance.Cash);
                UpdateLevelDisplay(GameManager.Instance.PlayerLevel);
                UpdateXPDisplay(0); // Just refresh, don't add XP
            }
        }

        /// <summary>
        /// Update cash display
        /// </summary>
        private void UpdateCashDisplay(int newCash)
        {
            if (cashText != null)
            {
                cashText.text = $"${newCash:N0}";
            }
        }

        /// <summary>
        /// Update level display
        /// </summary>
        private void UpdateLevelDisplay(int newLevel)
        {
            if (levelText != null)
            {
                levelText.text = $"Level {newLevel}";
            }
        }

        /// <summary>
        /// Update XP display
        /// </summary>
        private void UpdateXPDisplay(int xpGained)
        {
            if (xpText != null && GameManager.Instance != null)
            {
                int current = GameManager.Instance.CurrentXP;
                int needed = GameManager.Instance.XPToNextLevel;
                float percent = (float)current / needed * 100f;
                
                xpText.text = $"XP: {current}/{needed} ({percent:F0}%)";
            }
        }
        #endregion

        #region Panel Management
        /// <summary>
        /// Show machine shop panel
        /// </summary>
        public void ShowMachineShop()
        {
            if (machineShopPanel != null)
            {
                machineShopPanel.SetActive(true);
            }
        }

        /// <summary>
        /// Hide machine shop panel
        /// </summary>
        public void HideMachineShop()
        {
            if (machineShopPanel != null)
            {
                machineShopPanel.SetActive(false);
            }
        }
        #endregion

        #region Button Callbacks (Called from UI buttons)
        /// <summary>
        /// Called when "Buy CNC Machine" button is clicked
        /// </summary>
        public void OnBuyCNCMachineButton()
        {
            Debug.Log("Buy CNC Machine button clicked!");
            
            // TODO: Week 2 - Start machine placement mode
            // For now, just test that cash system works
            if (GameManager.Instance != null)
            {
                bool success = GameManager.Instance.SpendCash(35000f);
                if (success)
                {
                    Debug.Log("Purchased CNC Machine! (No placement yet)");
                }
                else
                {
                    Debug.LogWarning("Not enough cash to buy CNC Machine!");
                }
            }
        }

        /// <summary>
        /// Called when any debug button is clicked
        /// </summary>
        public void OnDebugAddCashButton()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddCash(10000f);
                Debug.Log("DEBUG: Added $10,000");
            }
        }
        #endregion
    }
}
