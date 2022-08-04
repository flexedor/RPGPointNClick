using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    /// <summary>
    ///controller responsible for UI items mechanics such as remove item and use item  
    /// </summary>
    private Item item;
    public Button RemoveButton;
    public static System.Action<string> OnItemUsed;
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        
        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        OnItemUsed?.Invoke($"{item.itemName} has been used");
        Player.Instance.IncreaseHeath(item.HpToAdd); 
        Player.Instance.IncreaseExp(item.XpToAdd);
        RemoveItem();
    }
}
