using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 관리 클래스

public class MainMenu : MonoBehaviour
{
    // NEW GAME 버튼 클릭 시 호출되는 함수
    public void NewGame()
    {
        // "GameScene"을 새로운 게임 씬으로 지정하고 로드
        SceneManager.LoadScene("MainScene");  // "GameScene"은 실제 게임 씬 이름으로 변경
        GameManager.Instance.CurrentMap = 1;
        GameManager.Instance.SetStage(GameManager.Instance.CurrentMap);
    }

    // LOAD GAME 버튼 클릭 시 호출되는 함수
    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene");
        GameManager.Instance.CurrentMap = 2;
        GameManager.Instance.SetStage(GameManager.Instance.CurrentMap);
    }

    // EXIT 버튼 클릭 시 호출되는 함수
    public void ExitGame()
    {
        // 게임을 종료합니다.
        Debug.Log("게임 종료");
        Application.Quit(); //실제 게임 빌드에서는 동작함
    }
}