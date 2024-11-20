using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoSingleton<SkillManager>
{
    public ObjectPool<FireBall> fireBallPool; // FireBall Ǯ
    [SerializeField] private FireBall fireBallPrefab;

    protected override void Awake()
    {
        base.Awake();
        fireBallPrefab = Resources.Load<FireBall>("Prefabs/Skills/FireBall");
        if (fireBallPool == null)
        {
            fireBallPool = new ObjectPool<FireBall>();
            fireBallPool.Initialize(fireBallPrefab, 10, transform); // Ǯ �ʱ�ȭ (������, �ʱ� ũ��, �θ� ����)
        }     

    }

    // FireBall�� Ǯ���� �������� �޼���
    public FireBall GetFireBallFromPool(Vector3 position, Quaternion rotation)
    {
        FireBall fireBall = fireBallPool.GetObject(position, rotation); // ��ġ�� ȸ������ �Ѱܼ� FireBall�� ��������
        fireBall.SetPool(fireBallPool); // Ǯ ����
        return fireBall;
    }

    // FireBall�� Ǯ�� ��ȯ�ϴ� �޼���
    public void ReturnFireBallToPool(FireBall fireBall)
    {
        fireBallPool.ReturnObject(fireBall); // Ǯ�� FireBall ��ȯ
    }

    // FireBall Ǯ�� ��� ��ü�� ������ ������ �����ϴ� �޼���
    public void ApplyDamageMultiplierToAllFireBalls(float multiplier)
    {
        foreach (FireBall fireBall in fireBallPool.GetAllObjects())
        {
            fireBall.SetDamageMultiplier(multiplier); // ��� FireBall�� ������ ���� ����
        }
    }
}
