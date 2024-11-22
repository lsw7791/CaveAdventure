using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 플레이어와 충돌 확인
        {
            gameObject.SetActive(false);
            GameManager.Instance.KeyNum += 1;
            Debug.Log(GameManager.Instance.KeyNum);
        }
        if (GameManager.Instance.KeyNum >=2)
        {
            GameManager.Instance.Ladder.SetActive(true);
            GameManager.Instance.Ladder.transform.position = new Vector2(4.5f, 0f);
        }
        if (GameManager.Instance.KeyNum >= 4)
        {
            GameManager.Instance.Box2.SetActive(true);
            GameManager.Instance.Box2.transform.position = new Vector2(34f, 4.5f);

        }
    }

}
