using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 관리를 위한 네임스페이스
using UnityEngine.UI; // UI 컴포넌트 관리

public class GameOverUIController : MonoBehaviour
{
    public Button retryButton;  // Retry 버튼
    public Button exitButton;   // Exit 버튼

    void Start()
    {
        // Retry 버튼 클릭 시 재시작 함수 연결
        retryButton.onClick.AddListener(ReloadGame);

        // Exit 버튼 클릭 시 첫 화면으로 돌아가는 함수 연결
        exitButton.onClick.AddListener(ExitToMainMenu);
    }

    // 게임 재시작 (현재 씬 다시 로드)
    void ReloadGame()
    {
        // 현재 씬을 다시 로드하여 게임을 재시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 첫 화면으로 돌아가기
    void ExitToMainMenu()
    {
        // "MainMenu"라는 씬으로 이동 (MainMenu 씬을 실제로 만들어야 합니다)
        SceneManager.LoadScene("IntroSence");
    }
}
