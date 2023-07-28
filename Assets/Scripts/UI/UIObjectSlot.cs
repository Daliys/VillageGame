using ItemResources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIObjectSlot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI itemAmount;
        [SerializeField] private Image itemIcon;
        
        public void InitializeSlot(Item item, int amount)
        {
            itemName.text = item.itemName;
            itemAmount.text = amount.ToString();
            itemIcon.sprite = item.sprite;
        }
    }
}
