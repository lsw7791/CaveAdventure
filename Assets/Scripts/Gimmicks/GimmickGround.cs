using UnityEngine;

public class GimmickGround : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;  // ����� Collider2D�� ������ ����

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();  // Collider2D �ʱ�ȭ

        // ����� ���۵� �� X�� Y ���� ��ġ�� Freeze
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }

    void Update()
    {
        // ����� ��ġ�� Y�� -10 ���Ϸ� �������� ��Ȱ��ȭ�ϰ� �߷� �������� 0���� ����
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
            // X���� ��� Freeze�ϰ�, Y�ุ ����
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;  // X�� Freeze ����
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY; // Y�� ����

            // �߷� ���� �����Ͽ� ����� ���������� ����
            rb.gravityScale = 20.0f;

            // TODO: �÷��̾� ü�� ���ҳ� ���� ���� ó��
        }
    }
}