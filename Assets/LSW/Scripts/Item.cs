using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO itemSO;  // ItemSO를 참조하는 필드
    public float moveSpeed = 5f;
    private Transform playerTransform;
    private bool isMoving = false;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            float distance = Vector2.Distance(transform.position, playerTransform.position);

            if (distance < 1f && !isMoving)
            {
                isMoving = true;
            }

            if (isMoving && distance > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (itemSO != null)
            {
                Inventory inventory = FindObjectOfType<Inventory>();  // 인벤토리 찾기
                if (inventory != null)
                {
                    inventory.AddItem(itemSO);  // 아이템을 인벤토리에 추가
                }
                else
                {
                    Debug.Log("Inventory not found.");
                }
            }
            else
            {
                Debug.Log("ItemSO is null, cannot add item.");
            }

            Destroy(gameObject);  // 아이템 오브젝트 삭제
        }
    }

}
