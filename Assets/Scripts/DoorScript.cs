using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public static System.Action knockInDoor;
    private void OnMouseDown()
    {
        knockInDoor?.Invoke();
    }
}
