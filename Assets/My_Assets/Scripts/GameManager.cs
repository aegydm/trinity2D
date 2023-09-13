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
            instance = this;    //�̱� �� ����: �̷ν� ��� �ҷ����� �㰡
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
            //Menu();                     �����Լ������߻� ����
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
            //GameOver();;                �����Լ������߻� ����
            overUi.SetActive(true);
            menuUi.SetActive(false);
            stopUi.SetActive(false);
        }
        currentGameState = newGameState;  //���ӻ��� �˻��� ����ϸ� �Ǵ� ����
    }

    //----------------------���� �Է¿� ���� ����---------------------------
    public void Menu()                          //���� ����� ù ȭ��, ���� ��ư�� ����
    {
        Time.timeScale = 0;
        SetGameState(GameState.menu);
    }

    public void Ingame()                        //�������λ��� - ��ֻ��� �Ϲ� ��, ������
    {
        Debug.Log("�ΰ��� �����");
        enemySpawnManager.PullingEnemyS();      //���ʹ� Ǯ��
        enemySpawnManager.Stage1();             //�������� ���� = ���ʹ�S 4���� ���� 
    }
    public void InBoss()                        //�������λ��� - �����ʵ� ����
    {
        Debug.Log("��������");
        boss.SetActive(true);
        //bossManager.Invoke("Think", 3);
    }

    public void GameOver()                      //�ӽ� ���ӿ��� �ڵ� - �ٸ��ڵ忡�� GameManager.instance.GameOver(); �� ȣ���
    {
        if (playerInfo._PlayerHp <= 0)
        {
            Time.timeScale = 0;
            SetGameState(GameState.gameOver);
        }
    }

    //----------------------��ư �Է¿� ���� ����---------------------------

    public void StartGame()        //���ӽ��� ��ư ������ ����
    {
        Time.timeScale = 1;
        SetGameState(GameState.inGame);
    }
    public void QuitGame()         //���� �������ư
    {
        Application.Quit();
    }

    public void StopGame()         // �Ͻ����� (ESC)
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
    
    public void ResetGame()        //�ٽ��ϱ�
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //--------------------------------------------------------------------



}
