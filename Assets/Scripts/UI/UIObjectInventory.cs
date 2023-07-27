using UnityEngine;
using System.Collections;
using TMPro;
using Villanger;
using UnityEngine.UI;
using ItemResources;

public class UIObjectInventory : MonoBehaviour
{
    

    private VillagerBehaviour _villager;
    [SerializeField] private GameObject ItemFramePrefab;
    private GameObject newItem;
    [SerializeField] private GameObject InventoryUIParent;
    [SerializeField] private Item testItem;
    
    private void Start()
    {
        
    }


    public void InitializePanel(VillagerBehaviour villager)
    {
        Sprite appleImage = Resources.Load<Sprite>("apple");
        _villager = villager;

        foreach (var item in _villager.GetVillagerInventory().inventory.Keys)
        {
            // make as many item panels as there are individual items
            for (int i = 0; i < _villager.GetVillagerInventory().inventory[item]; i++)
            {
                newItem = Instantiate(ItemFramePrefab);
                newItem.transform.SetParent(InventoryUIParent.transform);
                /*
                if (item.itemName == "Apple")
                {
                    newItem.transform.Find("ObjectImage").GetComponent<Image>().sprite = appleImage;
                }
                */
                // causing a null reference for no reason :arsenic:, removed until fixed
                // newItem.transform.Find("ItemInfo").GetComponent<TextMeshPro>().text = "Name: " + item.itemName;
            }
        }
        

    }

    public void ClosePanel()
    {
        if (transform.gameObject.activeSelf == false) return;

        // get rid of old items
        for (int i = 0; i < InventoryUIParent.transform.childCount; i++)
        {
            Destroy(InventoryUIParent.transform.GetChild(i).gameObject);
        }

        gameObject.SetActive(false);
    }


}

