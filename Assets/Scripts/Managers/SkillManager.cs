using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoSingleton<SkillManager>
{
    public ObjectPool<FireBall> fireBallPool; // FireBall 풀
    [SerializeField] private FireBall fireBallPrefab;

    protected override void Awake()
    {
        base.Awake();
        fireBallPrefab = Resources.Load<FireBall>("Prefabs/Skills/FireBall");
        if (fireBallPool == null)
        {
            fireBallPool = new ObjectPool<FireBall>();
            fireBallPool.Initialize(fireBallPrefab, 10, transform); // 풀 초기화 (프리팹, 초기 크기, 부모 지정)
        }     

    }

    // FireBall을 풀에서 가져오는 메서드
    public FireBall GetFireBallFromPool(Vector3 position, Quaternion rotation)
    {
        FireBall fireBall = fireBallPool.GetObject(position, rotation); // 위치와 회전값을 넘겨서 FireBall을 가져오기
        fireBall.SetPool(fireBallPool); // 풀 설정
        return fireBall;
    }

    // FireBall을 풀에 반환하는 메서드
    public void ReturnFireBallToPool(FireBall fireBall)
    {
        fireBallPool.ReturnObject(fireBall); // 풀에 FireBall 반환
    }

    // FireBall 풀의 모든 객체에 데미지 배율을 적용하는 메서드
    public void ApplyDamageMultiplierToAllFireBalls(float multiplier)
    {
        foreach (FireBall fireBall in fireBallPool.GetAllObjects())
        {
            fireBall.SetDamageMultiplier(multiplier); // 모든 FireBall에 데미지 배율 적용
        }
    }
}
