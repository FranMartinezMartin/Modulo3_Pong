using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameState gameState = GameState.Ingame;
    [SerializeField] GameObject pauseScreen;

    private void Start() {
        gameState = GameState.Ingame;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            switch(gameState){
                case GameState.Ingame:
                    pauseGame();
                    break;
                case GameState.Pause:
                    resumeGame();
                    break;
            }
        }    
    }

    private void pauseGame(){
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        gameState = GameState.Pause;
    }

    public void resumeGame(){
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        gameState = GameState.Ingame;
    }

    public void mainMenu(){
        SceneManager.LoadScene("MainMenu");    
    }

    public void exitGame(){
        Application.Quit();
    }

    public enum GameState {
        Pause,
        Ingame
    }
}
