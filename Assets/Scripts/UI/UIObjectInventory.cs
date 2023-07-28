using UnityEngine;
using Villanger;
using ItemResources;
using UI;

public class UIObjectInventory : MonoBehaviour
{

    private FlagStockpileBehaviour _stockpile;
    private VillagerBehaviour _villager;
    [SerializeField] private GameObject ItemFramePrefab;
   
    [SerializeField] private GameObject InventoryUIParent;
    [SerializeField] private Item testItem;

    private void Start()
    {

    }


    public void InitializePanel(VillagerBehaviour villager)
    {
        //Sprite appleImage = Resources.Load<Sprite>("apple");
        _villager = villager;

        foreach (var item in _villager.GetVillagerInventory().inventory.Keys)
        {
            GameObject newItem = Instantiate(ItemFramePrefab, InventoryUIParent.transform, true);
            newItem.GetComponent<UIObjectSlot>().InitializeSlot( item, _villager.GetVillagerInventory().inventory[item]);
        }
        
    }

    public void InitializePanel(FlagStockpileBehaviour stockpile)
    {
        RemoveAllItems();
        
        _stockpile = stockpile;

        foreach (var item in _stockpile.inventory.Keys)
        {
            GameObject newItem = Instantiate(ItemFramePrefab, InventoryUIParent.transform, true);
            newItem.GetComponent<UIObjectSlot>().InitializeSlot(item, _stockpile.inventory[item]);
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

