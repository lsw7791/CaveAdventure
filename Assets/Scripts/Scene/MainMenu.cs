using UnityEngine;
using UnityEngine.SceneManagement;  // �� ���� Ŭ����

public class MainMenu : MonoBehaviour
{
    // NEW GAME ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void NewGame()
    {
        // "GameScene"�� ���ο� ���� ������ �����ϰ� �ε�
        SceneManager.LoadScene("MainScene");  // "GameScene"�� ���� ���� �� �̸����� ����
        GameManager.Instance.CurrentMap = 1;
    }

    // LOAD GAME ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void LoadGame()
    {
        // ����� ���� ���°� �ִٸ�, �׿� �´� ���� �ε�
        // ���⼭�� ������ "SavedGameScene"�� �ε��Ѵٰ� ����
        if (PlayerPrefs.HasKey("SavedGame"))
        {
            SceneManager.LoadScene("SavedGameScene");  // ����� ���� �� �̸����� ����
        }
        else
        {
            Debug.Log("����� ������ �����ϴ�.");
            // ����� ������ ������ ������ �޽����� ǥ���ϰų� �ٸ� ���� �ε��� �� �ֽ��ϴ�.
        }
    }

    // EXIT ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void ExitGame()
    {
        // ������ �����մϴ�.
        Debug.Log("���� ����");
        Application.Quit(); //���� ���� ���忡���� ������
    }
}