using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어가 포탈에 접촉했을 때
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CurrentMap++;
            GameManager.Instance.SetStage(GameManager.Instance.CurrentMap);
            Destroy(transform.parent.gameObject);
        }
    }
}
