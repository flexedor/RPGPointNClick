using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WinCanwase, HudCanvase;

    private void OnEnable()
    {
       
        GameManager.WinSequence += OnWin;
    }
    private void OnDisable() {
        GameManager.WinSequence -= OnWin;
    }
    void OnWin()
    {
        WinCanwase.SetActive(true);
        HudCanvase.SetActive(false);
    }
}
