using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUI : MonoBehaviour
{
    public GameObject soundUI;
    public GameObject informationUI;

    private bool isPaused = false;


    public void OnclickSoundUIBtn()
    {
        soundUI.SetActive(!soundUI.activeSelf);
    }

    public void OnclickPauseBtn()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; 
            isPaused = false;    
        }
        else
        {
            Time.timeScale = 0f; 
            isPaused = true;     
        }
    }

    public void OnclickInformationUIBtn()
    {
        informationUI.SetActive(!informationUI.activeSelf);
    }
}

      
