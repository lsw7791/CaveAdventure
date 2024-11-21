using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickGround : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;  // 기믹의 Collider2D를 저장할 변수

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();  // Collider2D 초기화

        // 기믹이 시작될 때 X와 Y 축의 위치를 Freeze
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }

    void Update()
    {
        // 기믹의 위치가 Y축 -10 이하로 내려가면 비활성화하고 중력 스케일을 0으로 설정
        if (this.transform.position.y < -10)
        {
            rb.gravityScale = 0f;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // X축은 계속 Freeze하고, Y축만 해제
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;  // X는 Freeze 유지
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY; // Y는 해제

            // 중력 값을 변경하여 기믹이 떨어지도록 설정
            rb.gravityScale = 20.0f;

            // TODO: 플레이어 체력 감소나 게임 오버 처리
        }
    }
}