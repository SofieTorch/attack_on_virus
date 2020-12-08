using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour
{
    [SerializeField]
    GameObject life1, life2, life3, gameOverPanel, btnRestart, btnBackToMenu;

    [SerializeField]
    Text antCountder  = default,
         virCounter = default,
         gameOverTxt = default;
    
    Animator anim;
    private int lifeCount;
    public int virusCount, antidoteCount;


    void Start()
    {
        antidoteCount = 0;
        virusCount = 0;
        lifeCount = 3;
        anim = GetComponent<Animator>();
        gameOverTxt.enabled = false;
        gameOverPanel.SetActive(false);
        btnRestart.SetActive(false);
        btnBackToMenu.SetActive(false);
    }

    
    void Update()
    {
        virCounter.text = $"x{virusCount}";

        switch(lifeCount) {
            case 1:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                break;
            case 2:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(false);
                break;
            case 3:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                break;
            default:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                break;
        }

        if(lifeCount <= 0) {
            Destroy(gameObject, 0.5f);
            gameOverTxt.enabled = true;
            gameOverPanel.SetActive(true);
            btnRestart.SetActive(true);
            btnBackToMenu.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Virus") {
            lifeCount -= 1;
            anim.SetTrigger("Exploting");
        }
    }

}
