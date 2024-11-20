using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    enum MyEnum
    {
        MainMenu,
        Stage1,
        Stage2
    }
    public ParticleSystem ParticleEffects;
    public int CurrentMap;
    [SerializeField] GameObject Grid1;
    [SerializeField] GameObject Grid2;
    GameObject grid1Instance;
    GameObject grid2Instance;
    protected override void Awake()
    {
        base.Awake();
        //ParticleEffects = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();
        CurrentMap = (int)MyEnum.MainMenu;
        Grid1 = Resources.Load<GameObject>("Grids/GridLake");
        Grid2 = Resources.Load<GameObject>("Grids/GridMine");
        SpawnAllGrid();
    }

    public void SetStage(int stageNum)
    {
        switch (stageNum)
        {
            case 0:
                // TODO : 생성된 모든 오브젝트를 풀로 반환
                break;
            case 1:
                grid1Instance.SetActive(true);
                MonsterManager.Instance.Stage1Monster();
                break;
            case 2:
                grid2Instance.SetActive(true);
                MonsterManager.Instance.Stage2Monster();
                break;
            default:
                // TODO : 생성된 모든 오브젝트를 풀로 반환 후 메인메뉴로 이동
                break;
        }
    }

    private void SpawnAllGrid()
    {
        grid1Instance = Instantiate(Grid1, Vector3.zero, Quaternion.identity, transform);
        grid1Instance.SetActive(false);
        grid2Instance = Instantiate(Grid2, Vector3.zero, Quaternion.identity, transform);
        grid2Instance.SetActive(false);


    }
}
