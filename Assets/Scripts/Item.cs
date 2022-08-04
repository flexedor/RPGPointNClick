using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "NewItem",menuName = "Item/Create New Item")]

public class Item : ScriptableObject
{
   /// <summary>
   ///scriptable object for in game items 
   /// </summary>
   public string itemName;
   public int HpToAdd;
   public int XpToAdd;
   public Sprite icon;
}
