using System.Collections.Generic;
using UnityEngine;
using ItemResources;

public class FlagStockpileBehaviour : MonoBehaviour
{
    public int villageID = -5;
    public readonly Dictionary<Item, int> inventory = new Dictionary<Item, int>();

    public int numberOfSlots = 20;
    public int slotsTaken = 0;

    [SerializeField] UIObjectInventory uiObjectInventory;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    /// <summary>
    ///  Add an item to the inventory. If the item is already in the inventory, add the amount to the existing amount.
    /// </summary>
    /// <param name="item">the item to be added to the inventory  </param>
    /// <param name="amount">amount of the item to be added to the inventory</param>
    public void AddItemToInventory(Item item, int amount)
    {
        Debug.Log("Detected item addition attempt to stockpile");
        if (slotsTaken + amount * item.spaceTaken <= numberOfSlots)
        {
            Debug.Log("Adding item with name " + item.itemName);
            if (inventory.ContainsKey(item))
            {
                inventory[item] += amount;
            }
            else
            {
                inventory.Add(item, amount);
            }
            slotsTaken += amount;
        }
    }


    /// <summary>
    /// shortcut to not use rays because they break too much
    /// </summary>
    private void OnMouseDown()
    {
        // fingers crossed
        uiObjectInventory.gameObject.SetActive(true);
        uiObjectInventory.InitializePanel(this);
    }
    

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }
}
