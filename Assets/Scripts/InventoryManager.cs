using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    //items main list 
    public List<Item> Items = new List<Item>();
    public static System.Action<string> onItemAdd;
    public Transform ItemContent;
    public GameObject InventoryItem;

    public Toggle EnableRemove;

    public InventoryItemController[] InventoryItems;
    
    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    ///add new item into items main list 
    /// </summary>
    public void Add(Item item)
    {
        onItemAdd?.Invoke($"Item {item.itemName} has been added to your inventory");
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        //clean inventory before draw it again
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        //create and insert UI icons from item list  
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
            
            removeButton.gameObject.SetActive(EnableRemove.isOn);
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
        SetInventoryItems();
    }
    /// <summary>
    ///turning on/off remove button in UI items
    /// </summary>
    public void EnableItemsRemove()
    {
        foreach (Transform Item in ItemContent)
        {
            Item.Find("RemoveButton").gameObject.SetActive(EnableRemove.isOn);
        }
    }
    /// <summary>
    ///inserting scriptable objects properties into UI items in inventory   
    /// </summary>
    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }
}
