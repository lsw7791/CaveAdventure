using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(this.transform.position.y <-10)
        {
            if (rb.gravityScale >= 10.0f)
            {
                rb.gravityScale = 0f;
            }
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(rb.gravityScale <=5f)
            {
            //TODO : 플레이어 체력 감소나 게임 오버
            }
            rb.gravityScale = 20.0f;
        }
    }
}
