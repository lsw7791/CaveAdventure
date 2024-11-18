using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public enum MonsterState
    {
        Idle,   // 대기 상태
        Follow, // 플레이어 추적
        Attack, // 공격
        Chase   // 플레이어 추격
    }

    public MonsterState currentState = MonsterState.Idle;  // 기본 상태는 Idle
    public Transform player;   // 플레이어 Transform
    public float followDistance = 5f; // 플레이어와 가까워졌을 때 추적 시작
    public float attackDistance = 1.5f; // 공격 범위
    public float moveSpeed = 2f;  // 몬스터 이동 속도
    public float attackCooldown = 2f; // 공격 쿨타임

    private Animator animator;    // 애니메이터
    private float lastAttackTime = 0f; // 마지막 공격 시간

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 상태에 따라 행동 수행
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

        // 애니메이션 상태 업데이트
        UpdateAnimationState();
    }

    void IdleBehavior()
    {
        // 플레이어가 가까워지면 Follow 상태로 변경
        if (Vector2.Distance(transform.position, player.position) <= followDistance)
        {
            currentState = MonsterState.Follow;
        }
    }

    void FollowBehavior()
    {
        // 플레이어가 공격 범위 내에 들어오면 Attack 상태로 변경
        if (Vector2.Distance(transform.position, player.position) <= attackDistance)
        {
            currentState = MonsterState.Attack;
        }
        else
        {
            // 플레이어가 멀어지면 계속 Follow
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // 공격 범위 밖이면 Chase 상태로 변경
            if (Vector2.Distance(transform.position, player.position) > followDistance)
            {
                currentState = MonsterState.Chase;
            }
        }
    }

    void AttackBehavior()
    {
        // 공격 쿨타임이 지난 경우 공격
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            // 공격 애니메이션 트리거
            animator.SetTrigger("Attack");
            // 실제 공격 로직 (데미지 처리 등) 추가 가능
        }

        // 공격 후 일정 시간 후 Idle 상태로 돌아가기
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            currentState = MonsterState.Idle;
        }
    }

    void ChaseBehavior()
    {
        // Chase 상태에서는 계속 플레이어를 추적
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // 추격 중에 플레이어가 일정 범위 이내로 들어오면 Follow로 상태 변경
        if (Vector2.Distance(transform.position, player.position) <= followDistance)
        {
            currentState = MonsterState.Follow;
        }
    }

    void UpdateAnimationState()
    {
        // 상태에 맞는 애니메이션 전환
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
