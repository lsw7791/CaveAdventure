using UnityEngine;
using UnityEngine.SceneManagement;  // �� ���� Ŭ����

public class MainMenu : MonoBehaviour
{
    // NEW GAME ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void NewGame()
    {
        // "GameScene"�� ���ο� ���� ������ �����ϰ� �ε�
        SceneManager.LoadScene("MainScene");  // "GameScene"�� ���� ���� �� �̸����� ����
        GameManager.Instance.CurrentMap = 3;
        GameManager.Instance.SetStage(GameManager.Instance.CurrentMap);
    }

    // LOAD GAME ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene");
        GameManager.Instance.SetStage(GameManager.Instance.CurrentMap);
    }

    // EXIT ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void ExitGame()
    {
        // ������ �����մϴ�.
        Debug.Log("���� ����");
        Application.Quit(); //���� ���� ���忡���� ������
    }
}