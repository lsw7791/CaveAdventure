using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);

            GameManager.Instance.uiGameOver = this;

    }

    public void GameOverOn()
    {
        gameObject.SetActive(true);
    }
    public void GameOverOff()
    {
        gameObject.SetActive(false);
    }
}
