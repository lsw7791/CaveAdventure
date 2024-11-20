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
    }

    // LOAD GAME 버튼 클릭 시 호출되는 함수
    public void LoadGame()
    {
        // 저장된 게임 상태가 있다면, 그에 맞는 씬을 로드
        // 여기서는 간단히 "SavedGameScene"을 로드한다고 가정
        if (PlayerPrefs.HasKey("SavedGame"))
        {
            SceneManager.LoadScene("SavedGameScene");  // 저장된 게임 씬 이름으로 변경
        }
        else
        {
            Debug.Log("저장된 게임이 없습니다.");
            // 저장된 게임이 없으면 적절한 메시지를 표시하거나 다른 씬을 로드할 수 있습니다.
        }
    }

    // EXIT 버튼 클릭 시 호출되는 함수
    public void ExitGame()
    {
        // 게임을 종료합니다.
        Debug.Log("게임 종료");
        Application.Quit(); //실제 게임 빌드에서는 동작함
    }
}