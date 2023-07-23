using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagStockpileBehaviour : MonoBehaviour
{
    public int villageID = -5;
    public List<string> stockedItems;

    public int maxStorage = 20;
    public int filledStorage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// append an item to stockpile. might be reworked according to how things go.
    /// </summary>
    /// <param name="spaceTakenUpByObject"></param>
    public void appendItem(int spaceTakenUpByObject, string objectName)
    {
        if (filledStorage + spaceTakenUpByObject <= maxStorage)
        {
            filledStorage += spaceTakenUpByObject;
            stockedItems.Add(objectName);
        }
    }
}
