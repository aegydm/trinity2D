using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public static GameManager instance;
    public EnemySpawnManager enemySpawnManager;
    public BossManager bossManager;
    public GameState currentGameState = GameState.menu;
    public float time;
    public GameObject boss;

    public GameObject menuUi;
    public GameObject overUi;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;    //싱글 톤 선언: 이로써 모든 불러오기 허가
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            return;
        }
    }
    void Start()
    {
        //SetGameState(GameState.menu);  제귀함수오류발생~ 방지
        Menu();
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        enemySpawnManager = GameObject.Find("EnemySpawnManager").GetComponent<EnemySpawnManager>();
        //bossManager = GameObject.Find("Boss").GetComponent<BossManager>();
        //Debug.Log("위 오류는 보스가 비활성되어 찾지못하는 오류");
    }
    void Update()
    {
        //CheckGameOver();  // 게임오버(클리어 / 게임오버 통일)
        time += Time.deltaTime;
        if (time > 15 && time <16)
        {
            InBoss();  //조건 부합시 보스전으로 이동
        }
    }
    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //Menu();
        }
        else if (newGameState == GameState.inGame)
        {
            Ingame(); //EnemySpawnManager, BossManager
        }
        else if (newGameState == GameState.gameOver)
        {
            GameOver();
        }
        currentGameState = newGameState;         //외부에서 상태받기 - 안쓰게됨
    }

    //----------------------외부에의한 상태변화---------------------------
    public void Menu()        //게임 실행시 첫 화면, 시작 버튼이 존재
    {
        menuUi.SetActive(true);   // 메뉴 활성화 - UI메니저 할당
        Time.timeScale = 0;         // 게임시간 일시정지
        SetGameState(GameState.menu);
    }
    public void StartGame()   //게임시작 버튼 눌리면 실행
    {
        menuUi.SetActive(false);
        Time.timeScale = 1;
        SetGameState(GameState.inGame);
    }
    public void QuitGame()    //게임 나가기버튼
    {
        Application.Quit();
    }
    //--------------------------------------------------------------------


    public void Ingame() //게임중인상태 - 노멀상태 일반 몹, 정예몹
    {
        Debug.Log("인게임 실행됨");
        enemySpawnManager.PullingEnemyS();      //에너미 풀링
        enemySpawnManager.Stage1();             //스테이지 실행 = 에너미S 4마리 출현 

        while (currentGameState == GameState.inGame)
        {

        }
    }
    public void InBoss() //게임중인상태 - 보스필드 상태
    {
        Debug.Log("보스켜짐");
        boss.SetActive(true);
        //bossManager.Invoke("Think", 3);
    }

    public void CheckGameOver()   //상시검사, 게임 오버 여부 판별
    {
        if(playerInfo._PlayerHp <= 0)
        {
            SetGameState(GameState.gameOver);
        }
        //else if()
        //{

        //}
    }
    public void GameOver()   //임시코드 (보스 생존여부 판단 불가시 따로 외부에서 선언해줘야할함수
    {
        Time.timeScale = 0;
        overUi.SetActive(true);
    }



}
