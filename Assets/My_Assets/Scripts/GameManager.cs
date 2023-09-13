using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject stopUi;

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
        Menu();
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        enemySpawnManager = GameObject.Find("EnemySpawnManager").GetComponent<EnemySpawnManager>();
        //bossManager = GameObject.Find("Boss").GetComponent<BossManager>();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > 12){InBoss();}

        if (Input.GetKeyDown(KeyCode.Escape)){StopGame();}
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //Menu();                     제귀함수오류발생 방지
            overUi.SetActive(false);
            menuUi.SetActive(true);
            stopUi.SetActive(false);
        }
        else if (newGameState == GameState.inGame)
        {
            Ingame(); 
            overUi.SetActive(false);
            menuUi.SetActive(false);
            stopUi.SetActive(false);
        }
        else if (newGameState == GameState.gameOver)
        {
            //GameOver();;                제귀함수오류발생 방지
            overUi.SetActive(true);
            menuUi.SetActive(false);
            stopUi.SetActive(false);
        }
        currentGameState = newGameState;  //게임상태 검색에 사용하면 되는 변수
    }

    //----------------------상태 입력에 따른 값들---------------------------
    public void Menu()                          //게임 실행시 첫 화면, 시작 버튼이 존재
    {
        Time.timeScale = 0;
        SetGameState(GameState.menu);
    }

    public void Ingame()                        //게임중인상태 - 노멀상태 일반 몹, 정예몹
    {
        Debug.Log("인게임 실행됨");
        enemySpawnManager.PullingEnemyS();      //에너미 풀링
        enemySpawnManager.Stage1();             //스테이지 실행 = 에너미S 4마리 출현 
    }
    public void InBoss()                        //게임중인상태 - 보스필드 상태
    {
        Debug.Log("보스켜짐");
        boss.SetActive(true);
        //bossManager.Invoke("Think", 3);
    }

    public void GameOver()                      //임시 게임오버 코드 - 다른코드에서 GameManager.instance.GameOver(); 로 호출됨
    {
        if (playerInfo._PlayerHp <= 0)
        {
            Time.timeScale = 0;
            SetGameState(GameState.gameOver);
        }
    }

    //----------------------버튼 입력에 따른 값들---------------------------

    public void StartGame()        //게임시작 버튼 눌리면 실행
    {
        Time.timeScale = 1;
        SetGameState(GameState.inGame);
    }
    public void QuitGame()         //게임 나가기버튼
    {
        Application.Quit();
    }

    public void StopGame()         // 일시정지 (ESC)
    {
        if (currentGameState == GameState.inGame)
        {
            if (Time.timeScale == 0)
            {
                stopUi.SetActive(false);
                Time.timeScale = 1;
            }
            else if (Time.timeScale == 1)
            {
                stopUi.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    
    public void ResetGame()        //다시하기
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //--------------------------------------------------------------------



}
