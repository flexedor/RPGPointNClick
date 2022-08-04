using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MassageFunction : MonoBehaviour
{
    /// <summary>
    ///class responsible for chat massages  
    /// </summary>
    public Transform ChatContainer;
    public GameObject ChatItem;
    public List<string> Massages = new List<string>();
    private void OnEnable()
    {
        InventoryManager.onItemAdd += AddMassage;
        InventoryItemController.OnItemUsed += AddMassage;
        Player.OnHpChanged +=AddMassage;
        Player.OnXpChanged +=AddMassage;
        GameManager.NotEnoughExpSequence += AddMassage;
    }
    private void OnDisable() {
        InventoryManager.onItemAdd -= AddMassage;
        InventoryItemController.OnItemUsed -= AddMassage;
        Player.OnHpChanged -=AddMassage;
        Player.OnXpChanged -=AddMassage;
        GameManager.NotEnoughExpSequence -= AddMassage;
    
    }
    /// <summary>
    ///print all massages from list 
    /// </summary>
    public void showMassage()
    {
        //delete old messages 
        foreach (Transform item in ChatContainer)
        {
            Destroy(item.gameObject);
        }
        //insert items in UI list
        foreach (var massage in Massages)
        {
            GameObject obj = Instantiate(ChatItem, ChatContainer);
            var itemName = obj.transform.Find("MassageContent").GetComponent<Text>();
            itemName.text = massage;
        }
    }
    /// <summary>
    ///add message to list for printing 
    /// </summary>
    public void AddMassage(string StrToAdd)
    {
        Massages.Add(StrToAdd);
        showMassage();
    }
}

