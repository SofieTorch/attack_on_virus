using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject panel, btnRestartGO, btnToMenuGO, btnPause, btnResume, btnRestartP, btnToMenuP, btnNextLevel;

    [SerializeField]
    Text gameOverTxt, pauseTxt, levelPassTxt01, levelPassTxt02;

    [SerializeField]
    CounterController counterCtrl = default;

    [SerializeField]
    int currentScene = 0;

    public static bool levelPassed = false;

    void Start()
    {
        Time.timeScale = 1f;

        if(currentScene != 0) {
            panel.SetActive(false);
            gameOverTxt.enabled = false;
            btnRestartGO.SetActive(false);
            btnToMenuGO.SetActive(false);

            pauseTxt.enabled = false;
            btnResume.SetActive(false);
            btnRestartP.SetActive(false);
            btnToMenuP.SetActive(false);

            levelPassTxt01.enabled = false;
            levelPassTxt02.enabled = false;
            btnNextLevel.SetActive(false);
        }
    }

    
    void FixedUpdate()
    {
        if(currentScene != 0){
            if(counterCtrl.lifeCount <= 0) {
                this.GameOver();
            }

            if(levelPassed) {
                Time.timeScale = 0f;
                panel.SetActive(true);
                btnPause.SetActive(false);
                levelPassTxt01.enabled = true;
                levelPassTxt02.enabled = true;
                btnRestartP.SetActive(true);
                btnToMenuP.SetActive(true);
                btnNextLevel.SetActive(true);
                levelPassed = false;
            }
        }
    }

    void GameOver() {
        gameOverTxt.enabled = true;
        panel.SetActive(true);
        btnRestartGO.SetActive(true);
        btnToMenuGO.SetActive(true);
        btnPause.GetComponent<Button>().interactable = false;

        Time.timeScale = 0f;
    }

    public void Restart() {
        SceneManager.LoadScene(this.currentScene);
        btnPause.GetComponent<Button>().interactable = true;
    }

    public void GoToMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void Pause() {
        Time.timeScale = 0f;

        panel.SetActive(true);
        pauseTxt.enabled = true;
        btnResume.SetActive(true);
        btnRestartP.SetActive(true);
        btnToMenuP.SetActive(true);
    }

    public void Resume() {
        Time.timeScale = 1f;

        panel.SetActive(false);
        pauseTxt.enabled = false;
        btnResume.SetActive(false);
        btnRestartP.SetActive(false);
        btnToMenuP.SetActive(false);
    }
}
