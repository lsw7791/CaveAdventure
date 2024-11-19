using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public SkillSO fireBallData; // ���̾�� ������ (������ ��)
    private Rigidbody2D rb;      // ���̾�� Rigidbody2D ������Ʈ
    private Vector2 fireBallDir = Vector2.right; // ���̾�� ���� (�⺻������ ���������� ����)

    private void Start()
    {
        // Rigidbody2D ������Ʈ ��������
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(fireBallDir * fireBallData.skillSpeed, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���Ϳ� �浹 �� ������ �ֱ�
        if (collision.gameObject.CompareTag("Monster"))
        {
            Monster monster = collision.gameObject.GetComponent<Monster>(); // ���� ������Ʈ ��������
            if (monster != null)
            {
                monster.TakeDamage(fireBallData.skillDamage); // ���Ϳ��� �������� ��
            }
        }

        // GroundLayer�� �浹 �� (�ʿ��� ó��)
        if (collision.gameObject.CompareTag("GroundLayer"))
        {
            // �ٴڰ� �浹���� �� �� �۾��� ���⿡ �߰�
        }

        // �浹 �� ���̾ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}