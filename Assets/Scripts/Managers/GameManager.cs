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
                // TODO : 생성된 모든 오브젝트를 풀로 반환
                break;
            case 1:
                // TODO : 1스테이지 세팅
                break;
            case 2:
                // TODO : 2스테이지 세팅
                break;
            default:
                // TODO : 생성된 모든 오브젝트를 풀로 반환 후 메인메뉴로 이동
                break;
        }
    }
}
