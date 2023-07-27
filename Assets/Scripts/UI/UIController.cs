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

        private VillagerBehaviour _villager;

        public static UIController Instance;
        

        private void Awake()
        {
            Instance = this;
        }
        
        
        public void ShowVillagerInformationPanel(VillagerBehaviour villager)
        {
            _villager = villager;
            uiVillagerInformation.gameObject.SetActive(true);
            uiVillagerInformation.InitializePanel(villager);
        }
        
        
        public void OnMissTap()
        {
            // !! now the panels are to be closed with esc key because scrolling the inventory requires clicking
            // uiVillagerInformation.ClosePanel();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape) && !uiObjectInventory.gameObject.activeSelf)
            {
                uiVillagerInformation.ClosePanel();
            } else if (Input.GetKey(KeyCode.Escape) && uiObjectInventory.gameObject.activeSelf)
            {

                uiObjectInventory.ClosePanel();
                
            }

            if (Input.GetKey(KeyCode.F) && !uiObjectInventory.gameObject.activeSelf && uiVillagerInformation.gameObject.activeSelf)
            {
                uiObjectInventory.gameObject.SetActive(true);
                uiObjectInventory.InitializePanel(_villager);
                
            }
        }
    }
}