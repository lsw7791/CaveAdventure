using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Transform playerPos;  // 플레이어의 Transform을 저장할 변수
    Vector3 offset;
    // 카메라와 플레이어 사이의 거리

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어 태그가 붙은 오브젝트를 찾아서 플레이어 변수에 할당
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        offset = new Vector3(0, 0, -10);  // X, Y, Z 값 조정 가능
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어의 위치를 카메라에 반영
        if (playerPos != null)
        {
            // 카메라의 위치를 플레이어 위치 + 오프셋으로 설정
            transform.position = playerPos.position + offset;
        }
    }
}
