using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUI: MonoBehaviour
{
    public GameObject soundUI;

    public void OnclickSoundUIBtn()
    {
        if (soundUI.activeSelf)
        {
            soundUI.SetActive(false);

        }

        soundUI.SetActive(true);
    }
}
