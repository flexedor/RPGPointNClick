using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///Main class responsible for game state and win sequence 
/// </summary>
public class GameManager : MonoBehaviour
{
    private Player player;
    
    //Experiences points needed to win game 
    public int ExpToWin=20;
    
    public static System.Action WinSequence;
    public static System.Action<string> NotEnoughExpSequence;

    private void OnEnable()
    {
        player = GetComponentInChildren<Player>();
        DoorScript.knockInDoor += CheckWinSequence;
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
            NotEnoughExpSequence?.Invoke($"To win you need {ExpToWin} XP, you have:{player.Exp} XP");
        }
    }
}
