using UnityEngine;
using System;

namespace EngineAssemblyTycoon.Core
{
    /// <summary>
    /// GameManager - The core singleton that manages overall game state.
    /// This persists across scenes and coordinates all major systems.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Singleton Pattern
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<GameManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("GameManager");
                        _instance = go.AddComponent<GameManager>();
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region Player Data
        [Header("Player Progression")]
        [SerializeField] private int playerLevel = 1;
        [SerializeField] private int currentXP = 0;
        [SerializeField] private int xpToNextLevel = 1000;
        
        [Header("Economy")]
        [SerializeField] private float cash = 50000f;
        [SerializeField] private int challengePoints = 0;
        
        [Header("Reputation")]
        [SerializeField] private int reputation = 50; // 0-100 scale
        #endregion

        #region Properties (Public Access)
        public int PlayerLevel => playerLevel;
        public int CurrentXP => currentXP;
        public int XPToNextLevel => xpToNextLevel;
        public float Cash => cash;
        public int ChallengePoints => challengePoints;
        public int Reputation => reputation;
        #endregion

        #region Events
        public event Action<int> OnCashChanged;
        public event Action<int> OnXPGained;
        public event Action<int> OnLevelUp;
        public event Action<int> OnReputationChanged;
        #endregion

        #region Unity Lifecycle
        private void Awake()
        {
            // Singleton enforcement
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            _instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene loads
            
            Initialize();
        }

        private void Start()
        {
            Debug.Log($"GameManager initialized. Starting cash: ${cash:N0}");
        }
        #endregion

        #region Initialization
        private void Initialize()
        {
            // TODO: Load saved game data here (Week 3-4)
            Debug.Log("GameManager: Initializing game systems...");
        }
        #endregion

        #region Economy Methods
        /// <summary>
        /// Add cash to player's account
        /// </summary>
        public void AddCash(float amount)
        {
            cash += amount;
            OnCashChanged?.Invoke((int)cash);
            Debug.Log($"Cash added: +${amount:N0}. New balance: ${cash:N0}");
        }

        /// <summary>
        /// Deduct cash from player's account
        /// Returns true if successful, false if insufficient funds
        /// </summary>
        public bool SpendCash(float amount)
        {
            if (cash >= amount)
            {
                cash -= amount;
                OnCashChanged?.Invoke((int)cash);
                Debug.Log($"Cash spent: -${amount:N0}. New balance: ${cash:N0}");
                return true;
            }
            else
            {
                Debug.LogWarning($"Insufficient funds! Need ${amount:N0}, have ${cash:N0}");
                return false;
            }
        }
        #endregion

        #region Progression Methods
        /// <summary>
        /// Award XP to player and check for level up
        /// </summary>
        public void AddXP(int amount)
        {
            currentXP += amount;
            OnXPGained?.Invoke(amount);
            Debug.Log($"XP gained: +{amount}. Progress: {currentXP}/{xpToNextLevel}");

            // Check for level up
            while (currentXP >= xpToNextLevel)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            currentXP -= xpToNextLevel;
            playerLevel++;
            
            // XP curve: Each level requires more XP (exponential growth)
            xpToNextLevel = CalculateXPForNextLevel(playerLevel);
            
            OnLevelUp?.Invoke(playerLevel);
            Debug.Log($"LEVEL UP! Now Level {playerLevel}. Next level: {xpToNextLevel} XP");
            
            // TODO: Unlock new features based on level (Tech Tree - Week 4)
        }

        private int CalculateXPForNextLevel(int level)
        {
            // XP Formula from GDD Section 14.7
            // Rough approximation: XP = 1000 * (level ^ 1.5)
            return Mathf.RoundToInt(1000f * Mathf.Pow(level, 1.5f));
        }

        public void AddChallengePoints(int amount)
        {
            challengePoints += amount;
            Debug.Log($"Challenge Points earned: +{amount}. Total: {challengePoints}");
        }
        #endregion

        #region Reputation Methods
        /// <summary>
        /// Modify player reputation (0-100 scale)
        /// </summary>
        public void ModifyReputation(int delta)
        {
            reputation = Mathf.Clamp(reputation + delta, 0, 100);
            OnReputationChanged?.Invoke(reputation);
            
            string change = delta > 0 ? "increased" : "decreased";
            Debug.Log($"Reputation {change} by {Mathf.Abs(delta)}. New reputation: {reputation}");
        }
        #endregion

        #region Debug/Testing Methods
        [ContextMenu("Add 10000 Cash (DEBUG)")]
        private void DEBUG_AddCash()
        {
            AddCash(10000f);
        }

        [ContextMenu("Add 500 XP (DEBUG)")]
        private void DEBUG_AddXP()
        {
            AddXP(500);
        }
        #endregion
    }
}
