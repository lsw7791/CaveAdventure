using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToActivate; // 활성화할 오브젝트 배열

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 플레이어와 충돌 확인
        {
            gameObject.SetActive(false);

            ActivateObjects();
        }
    }

    private void ActivateObjects()
    {
        foreach (var obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
