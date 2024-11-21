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
    [SerializeField] GameObject Gimmick1Prefab;
    [SerializeField] GameObject Gimmick2Prefab;
    [SerializeField] GameObject Gimmick3Prefab;
    [SerializeField] GameObject LadderPrefab;
    [SerializeField] GameObject PlayerPrefab;



    GameObject grid1Instance;
    GameObject grid2Instance;
    GameObject Ground1Gimmick;
    GameObject Ground2Gimmick;
    GameObject Fall1Gimmick;

    GameObject Ladder;
    GameObject player;


    protected override void Awake()
    {
        base.Awake();

        // ParticleEffects = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();
        CurrentMap = PlayerPrefs.GetInt("SavedMap", (int)MyEnum.MainMenu); // 저장된 맵 번호 불러오기
        Grid1 = Resources.Load<GameObject>("Grids/GridLake");
        Grid2 = Resources.Load<GameObject>("Grids/GridMine");
        Gimmick1Prefab = Resources.Load<GameObject>("Prefabs/Gimmicks/GimmickGround1");
        Gimmick2Prefab = Resources.Load<GameObject>("Prefabs/Gimmicks/GimmickGround2");
        Gimmick3Prefab = Resources.Load<GameObject>("Prefabs/Gimmicks/GimmickFall1");
        LadderPrefab = Resources.Load<GameObject>("Prefabs/Ladder");
        PlayerPrefab = Resources.Load<GameObject>("Prefabs/GameSettings/Player");


        player = Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity, transform);
        player.SetActive(false);
        SpawnAllGrid();
        SpawnAllGimmick();
        SetStage(CurrentMap); // 저장된 맵 상태로 복원
    }

    public void SetStage(int stageNum)
    {
        AllSetActiveFalse();
        CurrentMap = stageNum; // 현재 맵 번호 업데이트

        switch (stageNum)
        {
            case 0:
                grid1Instance.SetActive(true);
                Ground1Gimmick.SetActive(true);
                Ground1Gimmick.transform.position = new Vector2(10f, -4.3f);
                Fall1Gimmick.SetActive(true);
                Fall1Gimmick.transform.position = new Vector2(10f, 4f);
                MonsterManager.Instance.Stage1Monster();
                break;
            case 1:
                player.SetActive(true);
                player.transform.position = new Vector2(0, 0);
                grid1Instance.SetActive(true);
                Ground1Gimmick.SetActive(true);
                Ground1Gimmick.transform.position = new Vector2(10f, -4.3f);
                Fall1Gimmick.SetActive(true);
                Fall1Gimmick.transform.position = new Vector2(10f, 4f);
                MonsterManager.Instance.Stage1Monster();
                break;
            case 2:
                player.SetActive(true);
                player.transform.position = new Vector2(17f, 0f);
                grid1Instance.SetActive(false);
                Ground1Gimmick.SetActive(false);
                Fall1Gimmick.SetActive(false);
                grid2Instance.SetActive(true);
                Ground1Gimmick.SetActive(true);
                Ground1Gimmick.transform.position = new Vector2(-7f, -4.4f);
                Ground2Gimmick.SetActive(true);
                Ground2Gimmick.transform.position = new Vector2(8f, -4.4f);
                MonsterManager.Instance.Stage2Monster();
                Ladder.SetActive(true);
                Ladder.transform.position = new Vector2(4.5f, 0f);
                break;
            default:
                // TODO: 필요한 경우 기본 처리 추가
                break;
        }
    }

    public void SaveCurrentMap()
    {
        PlayerPrefs.SetInt("SavedMap", CurrentMap); // 현재 맵 번호 저장
        PlayerPrefs.Save(); // 저장 강제 적용
        Debug.Log("Map Saved: " + CurrentMap);
    }

    private void SpawnAllGrid()
    {
        grid1Instance = Instantiate(Grid1, Vector3.zero, Quaternion.identity, transform);
        grid1Instance.SetActive(false);
        grid2Instance = Instantiate(Grid2, Vector3.zero, Quaternion.identity, transform);
        grid2Instance.SetActive(false);
    }

    void SpawnAllGimmick()
    {
        Ground1Gimmick = Instantiate(Gimmick1Prefab, Vector3.zero, Quaternion.identity, transform);
        Ground1Gimmick.SetActive(false);
        Ground2Gimmick = Instantiate(Gimmick2Prefab, Vector3.zero, Quaternion.identity, transform);
        Ground2Gimmick.SetActive(false);
        Fall1Gimmick = Instantiate(Gimmick3Prefab, Vector3.zero, Quaternion.identity, transform);
        Fall1Gimmick.SetActive(false);
        Ladder = Instantiate(LadderPrefab, Vector3.zero, Quaternion.identity, transform);
        Ladder.SetActive(false);
    }

    void AllSetActiveFalse()
    {
        grid1Instance.SetActive(false);
        grid2Instance.SetActive(false);
        Ground1Gimmick.SetActive(false);
        Ground2Gimmick.SetActive(false);
        Fall1Gimmick.SetActive(false);
        Ladder.SetActive(false);
        MonsterManager.Instance.StageMonsterReturn();
    }
}
