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
    public float time;
    public GameObject boss;

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
        //SetGameState(GameState.menu);  �����Լ������߻�~ ����
        Menu();
        enemySpawnManager = GameObject.Find("EnemySpawnManager").GetComponent<EnemySpawnManager>();
        bossManager = GameObject.Find("Boss").GetComponent<BossManager>();
        Debug.Log("�� ������ ������ ��Ȱ���Ǿ� ã�����ϴ� ����");
    }
    void Update()
    {
        //CheckGameOver();  // ���ӿ���(Ŭ���� / ���ӿ��� ����)
        time += Time.deltaTime;
        if (time > 15)
        {
            Debug.Log("������ȯ");
            InBoss();  //���� ���ս� ���������� �̵�
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
    public void QuitGame()    //���� �������ư
    {
        Application.Quit();
    }
    //--------------------------------------------------------------------


    public void Ingame() //�������λ��� - ��ֻ��� �Ϲ� ��, ������
    {
        Debug.Log("�ΰ��� �����");
        enemySpawnManager.PullingEnemyS();      //���ʹ� Ǯ��
        enemySpawnManager.Stage1();             //�������� ���� = ���ʹ�S 4���� ���� 

        while (currentGameState == GameState.inGame)
        {

        }
    }
    public void InBoss() //�������λ��� - �����ʵ� ����
    {
        boss.SetActive(true);
        bossManager.Invoke("Think", 3);
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
