using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    /// <summary>
    /// this is a simple event class for initialize checking game state(win of not enough XP)
    /// </summary>
    public static System.Action knockInDoor;
    private void OnMouseDown()
    {
        knockInDoor?.Invoke();
    }
}
