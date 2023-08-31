using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}


public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;
    void Start()
    {
        StartGame();
    }
    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu) { 
        } else if (newGameState == GameState.inGame) {
        } else if (newGameState == GameState.gameOver) { 
        }
        currentGameState = newGameState;
    }
    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }
    public void GameOver()
    {

    }

    public void Menu()
    {

    }
}
