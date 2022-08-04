using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;
    public int ExpToWin=20;
    
    public static System.Action WinSequence;
    public static System.Action<string> NotEnouthExpSequence;

    private void OnEnable()
    {
        player = GetComponentInChildren<Player>();
        DoorScript.knockInDoor += CheckWinSequence;
        Debug.Log($"{player.Exp} player xp");
    }
    private void OnDisable() {
        DoorScript.knockInDoor -= CheckWinSequence;
    }

    private void CheckWinSequence()
    {
        if (player.Exp>ExpToWin)
        {
            WinSequence?.Invoke();
        }
        else
        {
            NotEnouthExpSequence?.Invoke($"To win you need {ExpToWin} XP, you have:{player.Exp} XP");
        }
    }
}
