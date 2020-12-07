using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour
{
    [SerializeField]
    GameObject life1, life2, life3;

    [SerializeField]
    Text antCountder  = default, virCounter = default;
    
    Animator anim;
    private int lifeCount;
    public int virusCount, antidoteCount;


    void Start()
    {
        antidoteCount = 0;
        virusCount = 0;
        lifeCount = 3;
        anim = GetComponent<Animator>();
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
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Virus") {
            lifeCount -= 1;
            anim.SetTrigger("Exploting");
        }
    }

}
