using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DropItem
{
    [Header("Item Settings")]
    public List<GameObject> itemPrefabs; // 드랍할 아이템 프리팹 리스트
    [Range(0f, 1f)] public float dropRate; // 드랍 확률 (0~1 범위)

    [Header("Drop Amount")]
    public int minAmount = 1; // 최소 드랍 개수
    public int maxAmount = 1; // 최대 드랍 개수

    // 랜덤으로 프리팹을 선택하는 메서드
    public GameObject GetRandomPrefab()
    {
        if (itemPrefabs == null || itemPrefabs.Count == 0)
            return null;

        int randomIndex = UnityEngine.Random.Range(0, itemPrefabs.Count);
        return itemPrefabs[randomIndex];
    }
}
