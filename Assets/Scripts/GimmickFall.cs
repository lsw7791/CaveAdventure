using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickFall : MonoBehaviour
{
    private Rigidbody2D rb;
    private UIHeart uiheart;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        uiheart = GetComponent<UIHeart>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            uiheart.Loss();
        }

        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            rb.gravityScale = 2.0f;
        }
    }

}
