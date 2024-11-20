using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public ParticleSystem ParticleEffects;
    public int CurrentMap;
    enum MyEnum
    {
        MainMenu,
        Stage1,
        Stage2
    }
    protected override void Awake()
    {
        base.Awake();
        ParticleEffects = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();
        CurrentMap = (int)MyEnum.MainMenu;
    }

    void SetStage(int stageNum)
    {
        switch (stageNum)
        {
            case 0:
                // TODO : ������ ��� ������Ʈ�� Ǯ�� ��ȯ
                break;
            case 1:
                // TODO : 1�������� ����
                break;
            case 2:
                // TODO : 2�������� ����
                break;
            default:
                // TODO : ������ ��� ������Ʈ�� Ǯ�� ��ȯ �� ���θ޴��� �̵�
                break;
        }
    }
}
