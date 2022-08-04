using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    /// <summary>
    ///Players point and health system 
    /// </summary>
    public static Player Instance;
    
    [SerializeField]
    private int Health;
    [SerializeField]
    public int Exp;

    public Text HealthText;
    public Text ExpText;
    
    public static System.Action<string> OnHpChanged,OnXpChanged;
    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseHeath(int value)
    {
        
        Health += value;
        OnHpChanged?.Invoke($"Health have been changed on {value} now it is {Health}");
        HealthText.text = $"HP:{Health}";
    }

    public void IncreaseExp(int value)
    {
        Exp += value;
        OnHpChanged?.Invoke($"XP have been changed on {value} now it is {Exp}");
        ExpText.text = $"XP:{Exp}";
    }
    
}
