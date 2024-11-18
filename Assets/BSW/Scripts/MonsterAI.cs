using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public enum MonsterState
    {
        Idle,   // ��� ����
        Follow, // �÷��̾� ����
        Attack, // ����
        Chase   // �÷��̾� �߰�
    }

    public MonsterState currentState = MonsterState.Idle;  // �⺻ ���´� Idle
    public Transform player;   // �÷��̾� Transform
    public float followDistance = 5f; // �÷��̾�� ��������� �� ���� ����
    public float attackDistance = 1.5f; // ���� ����
    public float moveSpeed = 2f;  // ���� �̵� �ӵ�
    public float attackCooldown = 2f; // ���� ��Ÿ��

    private Animator animator;    // �ִϸ�����
    private float lastAttackTime = 0f; // ������ ���� �ð�

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ���¿� ���� �ൿ ����
        switch (currentState)
        {
            case MonsterState.Idle:
                IdleBehavior();
                break;
            case MonsterState.Follow:
                FollowBehavior();
                break;
            case MonsterState.Attack:
                AttackBehavior();
                break;
            case MonsterState.Chase:
                ChaseBehavior();
                break;
        }

        // �ִϸ��̼� ���� ������Ʈ
        UpdateAnimationState();
    }

    void IdleBehavior()
    {
        // �÷��̾ ��������� Follow ���·� ����
        if (Vector2.Distance(transform.position, player.position) <= followDistance)
        {
            currentState = MonsterState.Follow;
        }
    }

    void FollowBehavior()
    {
        // �÷��̾ ���� ���� ���� ������ Attack ���·� ����
        if (Vector2.Distance(transform.position, player.position) <= attackDistance)
        {
            currentState = MonsterState.Attack;
        }
        else
        {
            // �÷��̾ �־����� ��� Follow
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // ���� ���� ���̸� Chase ���·� ����
            if (Vector2.Distance(transform.position, player.position) > followDistance)
            {
                currentState = MonsterState.Chase;
            }
        }
    }

    void AttackBehavior()
    {
        // ���� ��Ÿ���� ���� ��� ����
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            // ���� �ִϸ��̼� Ʈ����
            animator.SetTrigger("Attack");
            // ���� ���� ���� (������ ó�� ��) �߰� ����
        }

        // ���� �� ���� �ð� �� Idle ���·� ���ư���
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            currentState = MonsterState.Idle;
        }
    }

    void ChaseBehavior()
    {
        // Chase ���¿����� ��� �÷��̾ ����
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // �߰� �߿� �÷��̾ ���� ���� �̳��� ������ Follow�� ���� ����
        if (Vector2.Distance(transform.position, player.position) <= followDistance)
        {
            currentState = MonsterState.Follow;
        }
    }

    void UpdateAnimationState()
    {
        // ���¿� �´� �ִϸ��̼� ��ȯ
        if (currentState == MonsterState.Idle)
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsAttacking", false);
        }
        else if (currentState == MonsterState.Follow || currentState == MonsterState.Chase)
        {
            animator.SetBool("IsMoving", true);
            animator.SetBool("IsAttacking", false);
        }
        else if (currentState == MonsterState.Attack)
        {
            animator.SetBool("IsAttacking", true);
            animator.SetBool("IsMoving", false);
        }
    }
}
