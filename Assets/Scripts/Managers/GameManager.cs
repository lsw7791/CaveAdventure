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
    public int KeyNum;
    public int playerLife;
    [SerializeField] GameObject Grid1;
    [SerializeField] GameObject Grid2;
    [SerializeField] GameObject Grid3;

    [SerializeField] GameObject Gimmick1Prefab;
    [SerializeField] GameObject Gimmick2Prefab;
    [SerializeField] GameObject Gimmick3Prefab;
    [SerializeField] GameObject LadderPrefab;
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] GameObject Key1Prefab;
    [SerializeField] GameObject Key2Prefab;
    [SerializeField] GameObject Key3Prefab;
    [SerializeField] GameObject Key4Prefab;

    GameObject grid1Instance;
    GameObject grid2Instance;
    GameObject grid3Instance;

    GameObject Ground1Gimmick;
    GameObject Ground2Gimmick;
    GameObject Fall1Gimmick;
    public GameObject Ladder;
    GameObject player;
    GameObject Key1;
    GameObject Key2;
    GameObject Key3;
    GameObject Key4;
    public UIHeart uiHeart;
    public UIGameOver uiGameOver;

    protected override void Awake()
    {
        base.Awake();

        // Resource에서 필요한 오브젝트 로드
        Grid1 = Resources.Load<GameObject>("Grids/GridLake");
        Grid2 = Resources.Load<GameObject>("Grids/GridMine");
        Grid3 = Resources.Load<GameObject>("Grids/GridNatrue");

        Gimmick1Prefab = Resources.Load<GameObject>("Prefabs/Gimmicks/GimmickGround1");
        Gimmick2Prefab = Resources.Load<GameObject>("Prefabs/Gimmicks/GimmickGround2");
        Gimmick3Prefab = Resources.Load<GameObject>("Prefabs/Gimmicks/GimmickFall1");
        LadderPrefab = Resources.Load<GameObject>("Prefabs/Ladder");
        PlayerPrefab = Resources.Load<GameObject>("Prefabs/GameSettings/Player");
        Key1Prefab = Resources.Load<GameObject>("Prefabs/Keys/Key1");
        Key2Prefab = Resources.Load<GameObject>("Prefabs/Keys/Key2");
        Key3Prefab = Resources.Load<GameObject>("Prefabs/Keys/Key3");
        Key4Prefab = Resources.Load<GameObject>("Prefabs/Keys/Key4");
        

        // 초기화
        player = Instantiate(PlayerPrefab, new Vector2(10f,10f), Quaternion.identity, transform);
        player.SetActive(false);
        SpawnAllGrid();
        SpawnAllGimmick();
        SpawnKey();
        SetStage(CurrentMap); // 저장된 맵 상태로 복원
        KeyNum = 0;

        // 저장된 맵 번호를 불러와 스테이지 설정
        LoadCurrentMap();
    }
    private void Start()
    {
        playerLife = 1;      
    }
    public void SetStage(int stageNum)
    {
        PlayerPrefs.GetInt("HeartCount", 1);
        AllSetActiveFalse();
        Time.timeScale = 1;
        CurrentMap = stageNum; // 현재 맵 번호 업데이트
        KeyNum = 0;
        switch (stageNum)
        {
            case 0:
                AllSetActiveFalse();
                break;
            case 1:
                grid1Instance.SetActive(true);
                player.SetActive(true);
                player.transform.position = new Vector2(0, 0);
                Ground1Gimmick.SetActive(true);
                Ground1Gimmick.transform.position = new Vector2(10f, -4.3f);
                Fall1Gimmick.SetActive(true);
                Fall1Gimmick.transform.position = new Vector2(10f, 4f);
                MonsterManager.Instance.Stage1Monster();
                break;
            case 2:
                grid2Instance.SetActive(true);
                player.SetActive(true);
                player.transform.position = new Vector2(17f, 0f);
                grid1Instance.SetActive(false);
                Ground1Gimmick.SetActive(false);
                Fall1Gimmick.SetActive(false);
                Ground1Gimmick.SetActive(true);
                Ground1Gimmick.transform.position = new Vector2(-7f, -4.4f);
                Ground2Gimmick.SetActive(true);
                Ground2Gimmick.transform.position = new Vector2(8f, -4.4f);
                MonsterManager.Instance.Stage2Monster();              
                Key1.SetActive(true);
                Key1.transform.position = new Vector2(28f, -2f);
                Key2.SetActive(true);
                Key2.transform.position = new Vector2(-12f, -2f);
                Key3.SetActive(true);
                Key3.transform.position = new Vector2(-9f,7f);
                Key4.SetActive(true);
                Key4.transform.position = new Vector2(24f, 6f);
                break;
            case 3:
                grid3Instance.SetActive(true);
                player.SetActive(true);
                player.transform.position = new Vector2(-25f, 0f);
                break;
            default:
                Debug.LogWarning("Invalid stage number!");
                break;
        }
    }
    private void Update()
    {
        if(player.transform.position.y <= -50)
        {
            GameOver();
        }
    }
    public void SaveCurrentMap()
    {
        PlayerPrefs.SetInt("SavedMap", CurrentMap); // 현재 맵 번호 저장
        PlayerPrefs.Save(); // 저장 강제 적용
        Debug.Log("Map Saved: " + CurrentMap);
    }
    void SpawnKey()
    {
        Key1 = Instantiate(Key1Prefab, Vector3.zero, Quaternion.identity, transform);
        Key1.SetActive(false);
        Key2 = Instantiate(Key2Prefab, Vector3.zero, Quaternion.identity, transform);
        Key2.SetActive(false);
        Key3 = Instantiate(Key3Prefab, Vector3.zero, Quaternion.identity, transform);
        Key3.SetActive(false);
        Key4 = Instantiate(Key4Prefab, Vector3.zero, Quaternion.identity, transform);
        Key4.SetActive(false);

    }
    public void LoadCurrentMap()
    {
        int savedMap = PlayerPrefs.GetInt("SavedMap", (int)MyEnum.MainMenu); // 저장된 맵 번호 불러오기 (기본값: MainMenu)
        SetStage(savedMap);
    }

    private void SpawnAllGrid()
    {
        grid1Instance = Instantiate(Grid1, Vector3.zero, Quaternion.identity, transform);
        grid1Instance.SetActive(false);
        grid2Instance = Instantiate(Grid2, Vector3.zero, Quaternion.identity, transform);
        grid2Instance.SetActive(false);
        grid3Instance = Instantiate(Grid3, Vector3.zero, Quaternion.identity, transform);
        grid3Instance.SetActive(false);
    }

    private void SpawnAllGimmick()
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

    private void AllSetActiveFalse()
    {
        grid1Instance.SetActive(false);
        grid2Instance.SetActive(false);
        grid3Instance.SetActive(false);

        Ground1Gimmick.SetActive(false);
        Ground2Gimmick.SetActive(false);
        Fall1Gimmick.SetActive(false);
        Ladder.SetActive(false);
        player.SetActive(false);
        Key1.SetActive(false);
        Key2.SetActive(false);
        Key3.SetActive(false);
        Key4.SetActive(false);

        MonsterManager.Instance.StageMonsterReturn();
    }

   

    public void GameOver()
    {
        // 게임 시간 멈추기
      
        Time.timeScale = 0;
        // 게임 오버 UI 활성화
        uiGameOver.GameOverOn();
        playerLife = 1;
        GameSave();
    }

    public void UpdateUI()
    {
        if (uiHeart.heartText != null)
        {
            uiHeart.heartText.text = playerLife.ToString();
        }
        else
        {
            Debug.LogError("Text 컴포넌트가 할당되지 않았습니다.");
        }
    }
    public void GameSave()
    {
        PlayerPrefs.SetInt("HeartCount", playerLife);  // 새로운 하트 수 저장
        PlayerPrefs.Save();  // 변경 사항 저장
    }
    public void PlayerLifeAdd()
    {
        // 하트를 증가시키고 UI를 갱신합니다.
        playerLife += 1;
        UpdateUI();
    }

    public void PlayerLifeLoss()
    {
        playerLife -= 1;  // 하트 감소

        if (playerLife <= 0)
        {
            GameOver();
        }
        UpdateUI();
    }
}
