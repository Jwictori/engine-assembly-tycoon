using UnityEngine;
using EngineAssemblyTycoon.Machines;
using EngineAssemblyTycoon.Core;

namespace EngineAssemblyTycoon.UI
{
    /// <summary>
    /// MachineShop - Handles purchasing and placing machines
    /// This is the bridge between UI buttons and the placement system
    /// </summary>
    public class MachineShop : MonoBehaviour
    {
        #region Machine Data References
        [Header("Available Machines")]
        [Tooltip("Drag your CNC_Mill_Basic ScriptableObject here")]
        [SerializeField] private MachineSO cncMachineData;
        
        [Tooltip("Add more machine types here in future")]
        [SerializeField] private MachineSO latheMachineData;
        [SerializeField] private MachineSO assemblyMachineData;
        #endregion

        #region Button Callbacks
        /// <summary>
        /// Called when "Buy CNC Machine" button is clicked
        /// </summary>
        public void OnBuyCNCMachine()
        {
            if (cncMachineData == null)
            {
                Debug.LogError("CNC Machine Data not assigned to MachineShop! Drag the ScriptableObject into the Inspector.");
                return;
            }

            // Check if player can afford it
            if (GameManager.Instance == null)
            {
                Debug.LogError("GameManager not found!");
                return;
            }

            if (GameManager.Instance.Cash < cncMachineData.PurchaseCost)
            {
                Debug.LogWarning($"Not enough cash! Need ${cncMachineData.PurchaseCost:N0}, have ${GameManager.Instance.Cash:N0}");
                
                // TODO: Show error message to player (Week 3 - UI polish)
                return;
            }

            // Start placement mode
            if (MachinePlacement.Instance != null)
            {
                Debug.Log($"Starting placement for {cncMachineData.DisplayName}. Click on grid to place!");
                MachinePlacement.Instance.StartPlacingMachine(cncMachineData);
            }
            else
            {
                Debug.LogError("MachinePlacement system not found!");
            }
        }

        /// <summary>
        /// Called when "Buy Lathe" button is clicked (future)
        /// </summary>
        public void OnBuyLathe()
        {
            if (latheMachineData != null)
            {
                MachinePlacement.Instance?.StartPlacingMachine(latheMachineData);
            }
        }

        /// <summary>
        /// Called when "Buy Assembly Station" button is clicked (future)
        /// </summary>
        public void OnBuyAssemblyStation()
        {
            if (assemblyMachineData != null)
            {
                MachinePlacement.Instance?.StartPlacingMachine(assemblyMachineData);
            }
        }
        #endregion

        #region Debug Helpers
        [ContextMenu("Test: Start CNC Placement")]
        private void DEBUG_StartCNCPlacement()
        {
            OnBuyCNCMachine();
        }
        #endregion
    }
}
