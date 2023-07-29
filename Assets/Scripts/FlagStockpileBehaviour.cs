using System.Collections.Generic;
using UnityEngine;
using ItemResources;
using UI;

public class FlagStockpileBehaviour : MonoBehaviour
{
    public int villageID = -5;
    public StockpileInventory stockpileInventory;
  
    [SerializeField] UIObjectInventory uiObjectInventory;


    FlagStockpileBehaviour()
    {
        stockpileInventory = new StockpileInventory(20);
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
