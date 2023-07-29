using System;
using TMPro;
using UnityEngine;
using Villanger;

namespace UI
{
    /// <summary>
    ///   This class is responsible for controlling the whole UI.
    /// </summary>
    public class UIController : MonoBehaviour
    {
        [SerializeField] private UIVillagerInformation uiVillagerInformation;
        [SerializeField] private UIObjectInventory uiObjectInventory;
        [SerializeField] private TextMeshProUGUI gameSpeedText;
        
        private VillagerBehaviour _villager;

        public static UIController Instance;
        

        private void Awake()
        {
            Instance = this;
            // make a string format fot text in format "x1.0"
            

      UpdateTimeSpeed();
        }
        
        
        public void ShowVillagerInformationPanel(VillagerBehaviour villager)
        {
            if(uiVillagerInformation.gameObject.activeSelf) uiVillagerInformation.ClosePanel();
            
            _villager = villager;
            uiVillagerInformation.gameObject.SetActive(true);
            uiVillagerInformation.InitializePanel(villager);
        }
        
        
        public void OnMissTap()
        {
            Debug.Log("misstap");
            // !! now the panels are to be closed with esc key because scrolling the inventory requires clicking
            // uiVillagerInformation.ClosePanel();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                uiVillagerInformation.ClosePanel();
                uiObjectInventory.ClosePanel();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!uiObjectInventory.gameObject.activeSelf && uiVillagerInformation.gameObject.activeSelf)
                {
                    uiObjectInventory.gameObject.SetActive(true);
                    uiObjectInventory.InitializePanel(_villager);
                }
                else if (uiObjectInventory.gameObject.activeSelf)
                {
                    uiObjectInventory.ClosePanel();

                }
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Time.timeScale = Time.timeScale <= 1f? 1f : Time.timeScale - 1f;
                UpdateTimeSpeed();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                Time.timeScale = Time.timeScale >= 10f? 10f : Time.timeScale + 1f;
                UpdateTimeSpeed();
            }
            
            
            
           
        }

        private void UpdateTimeSpeed()
        {
            gameSpeedText.text = $"x{Time.timeScale:0.0}";
        }
    }
}