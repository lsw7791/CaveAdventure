using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;  
    public ItemSO itemSO;  
    public float spawnRange = 10f;  

    public void SpawnItem()
    {
        // 랜덤 위치 생성
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            0f,
            Random.Range(-spawnRange, spawnRange)
        );

        // 아이템을 생성하고, `ItemSO`를 할당
        GameObject item = Instantiate(itemPrefab, randomPosition, Quaternion.identity);
        item.GetComponent<PickUp>().item = itemSO;  // 아이템 오브젝트에 데이터 할당
    }
}
