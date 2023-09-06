using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        currentGameState = GameState.menu;  //���� ���� �� �޴����·� ��ȯ
    }
    void Update()
    {
        CheckGameOver();  // ���ӿ���(Ŭ���� / ���ӿ��� ����)
    }
    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu) 
        { 

        } 
        else if (newGameState == GameState.inGame) 
        {

        } 
        else if (newGameState == GameState.gameOver) 
        { 

        }
        currentGameState = newGameState;
    }
    

    public void StartGame()
    {
        Time.timeScale = 1;
        SetGameState(GameState.inGame);
    }

    public void CheckGameOver()
    {
        SetGameState(GameState.gameOver);
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        SetGameState(GameState.gameOver);
    }
    
    public void Menu()
    {
        menuUi.SetActive(true);   // �޴� Ȱ��ȭ
        Time.timeScale = 0;       // ���ӽð� �Ͻ�����
        SetGameState(GameState.menu);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
