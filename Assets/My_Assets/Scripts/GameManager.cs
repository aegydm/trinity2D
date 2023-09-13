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
    public static GameManager instance;  
    public EnemySpawnManager enemySpawnManager;
    public BossManager bossManager;
    public GameState currentGameState = GameState.menu;

    public GameObject menuUi;

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
        //currentGameState = GameState.menu;  //게임 시작 전 메뉴상태로 전환
        //SetGameState(currentGameState);
        Menu();
        enemySpawnManager = GameObject.Find("EnemySpawnManager").GetComponent<EnemySpawnManager>();
        bossManager = GameObject.Find("Boss").GetComponent<BossManager>();
    }
    void Update()
    {
        CheckGameOver();  // 게임오버(클리어 / 게임오버 통일)
    }
    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu) 
        {
            //UIManager
        } 
        else if (newGameState == GameState.inGame) 
        {
            Ingame(); //EnemySpawnManager, BossManager
        }
        else if (newGameState == GameState.gameOver) 
        { 
            
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
    public void QuitGame()    //게임 나가기
    {
        Application.Quit();
    }
    //--------------------------------------------------------------------


    public void Ingame() //게임중인상태 - 노멀상태 일반 몹, 정예몹
    {
        InBoss();  //조건 부합시 보스전으로 이동
    }
    public void InBoss() //게임중인상태 - 보스필드 상태
    {

    }

    public void CheckGameOver()   //상시검사, 게임 오버 여부 판별
    {
        //플레이어 체력검사
        //플레이어 채력 0 시 게임 오버
        //플레이어 생존 보스 다운 = 게임 승리 
        SetGameState(GameState.gameOver);
    }
    public void GameOver()   //임시코드 (보스 생존여부 판단 불가시 따로 외부에서 선언해줘야할함수
    {
        Time.timeScale = 0;
        SetGameState(GameState.gameOver);
    }
    
    
    
}
