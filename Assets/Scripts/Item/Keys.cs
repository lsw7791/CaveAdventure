using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToActivate; // 활성화할 오브젝트 배열

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);

        if (collision.CompareTag("Player")) // 플레이어와 충돌 확인
        {
            gameObject.SetActive(false);
            GameManager.Instance.KeyNum += 1;
        }
        if (GameManager.Instance.KeyNum <=2)
        {
            GameManager.Instance.Ladder.SetActive(true);
            GameManager.Instance.Ladder.transform.position = new Vector2(4.5f, 0f);
        }
        if (GameManager.Instance.KeyNum <= 4)
        {
            //TODO : 끝나는 포탈 열기
        }
    }

}
