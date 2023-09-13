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
        //currentGameState = GameState.menu;  //���� ���� �� �޴����·� ��ȯ
        //SetGameState(currentGameState);
        Menu();
        enemySpawnManager = GameObject.Find("EnemySpawnManager").GetComponent<EnemySpawnManager>();
        bossManager = GameObject.Find("Boss").GetComponent<BossManager>();
    }
    void Update()
    {
        CheckGameOver();  // ���ӿ���(Ŭ���� / ���ӿ��� ����)
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
        currentGameState = newGameState;         //�ܺο��� ���¹ޱ� - �Ⱦ��Ե�
    }

    //----------------------�ܺο����� ���º�ȭ---------------------------
    public void Menu()        //���� ����� ù ȭ��, ���� ��ư�� ����
    {
        menuUi.SetActive(true);   // �޴� Ȱ��ȭ - UI�޴��� �Ҵ�
        Time.timeScale = 0;         // ���ӽð� �Ͻ�����
        SetGameState(GameState.menu);
    }
    public void StartGame()   //���ӽ��� ��ư ������ ����
    {
        menuUi.SetActive(false);
        Time.timeScale = 1;
        SetGameState(GameState.inGame);
    }
    public void QuitGame()    //���� ������
    {
        Application.Quit();
    }
    //--------------------------------------------------------------------


    public void Ingame() //�������λ��� - ��ֻ��� �Ϲ� ��, ������
    {
        InBoss();  //���� ���ս� ���������� �̵�
    }
    public void InBoss() //�������λ��� - �����ʵ� ����
    {

    }

    public void CheckGameOver()   //��ð˻�, ���� ���� ���� �Ǻ�
    {
        //�÷��̾� ü�°˻�
        //�÷��̾� ä�� 0 �� ���� ����
        //�÷��̾� ���� ���� �ٿ� = ���� �¸� 
        SetGameState(GameState.gameOver);
    }
    public void GameOver()   //�ӽ��ڵ� (���� �������� �Ǵ� �Ұ��� ���� �ܺο��� ������������Լ�
    {
        Time.timeScale = 0;
        SetGameState(GameState.gameOver);
    }
    
    
    
}
