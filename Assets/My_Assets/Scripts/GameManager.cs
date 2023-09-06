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
        currentGameState = GameState.menu;  //게임 시작 전 메뉴상태로 전환
    }
    void Update()
    {
        CheckGameOver();  // 게임오버(클리어 / 게임오버 통일)
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
        menuUi.SetActive(true);   // 메뉴 활성화
        Time.timeScale = 0;       // 게임시간 일시정지
        SetGameState(GameState.menu);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
