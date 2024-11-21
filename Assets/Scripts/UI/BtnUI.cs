using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnUI : MonoBehaviour
{
    public GameObject soundUI;
    public GameObject informationUI;
    public GameObject savePanel;

    private bool isPaused = false;

    public void OnClickSoundUIBtn()
    {
        soundUI.SetActive(!soundUI.activeSelf);
    }

    public void OnClickPauseBtn()
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

    public void OnClickInformationUIBtn()
    {
        informationUI.SetActive(!informationUI.activeSelf);
    }

    public void OnClickSaveBtn()
    {
        StartCoroutine(ShowSavePanel());
    }

    public void OnClickExitBtn()
    {
        SceneManager.LoadScene("IntroScene");
    }

    private IEnumerator ShowSavePanel()
    {
        savePanel.SetActive(true); // 패널 활성화
        yield return new WaitForSeconds(2f); // 2초 대기
        savePanel.SetActive(false); // 패널 비활성화
    }
}
