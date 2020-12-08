using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int currentLevel = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Restart(int currentLevel) {
        this.currentLevel = currentLevel;
        SceneManager.LoadScene(this.currentLevel);
    }

    public void GoToMenu() {
        SceneManager.LoadScene(0);
    }

    public void Play() {
        SceneManager.LoadScene(1);
    }
}
