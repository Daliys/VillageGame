using UnityEngine;
using Villanger;

namespace UI
{
    public class UIObjectInventory : MonoBehaviour
    {

        private StockpileInventory _stockpileInventory;
        private VillagerBehaviour _villager;
        [SerializeField] private GameObject ItemFramePrefab;

        [SerializeField] private GameObject InventoryUIParent;



        public void InitializePanel(VillagerBehaviour villager)
        {
            //Sprite appleImage = Resources.Load<Sprite>("apple");
            _villager = villager;
            foreach (var item in _villager.GetVillagerInventory().inventory.Keys)
            {
                GameObject newItem = Instantiate(ItemFramePrefab, InventoryUIParent.transform, true);
                newItem.GetComponent<UIObjectSlot>()
                    .InitializeSlot(item, _villager.GetVillagerInventory().inventory[item]);
            }
        }

        public void InitializePanel(FlagStockpileBehaviour stockpile)
        {
            RemoveAllItems();

            _stockpileInventory = stockpile.stockpileInventory;

            foreach (var item in _stockpileInventory.inventory.Keys)
            {
                GameObject newItem = Instantiate(ItemFramePrefab, InventoryUIParent.transform, true);
                newItem.GetComponent<UIObjectSlot>().InitializeSlot(item, _stockpileInventory.inventory[item]);
            }
        }


        public void ClosePanel()
        {
            if (transform.gameObject.activeSelf == false) return;

            RemoveAllItems();
            gameObject.SetActive(false);
        }

        private void RemoveAllItems()
        {
            for (int i = 0; i < InventoryUIParent.transform.childCount; i++)
            {
                Destroy(InventoryUIParent.transform.GetChild(i).gameObject);
            }
        }
    }
}