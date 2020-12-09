using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntidoteController : MonoBehaviour
{
    float flag = 1f;
    
    void FixedUpdate()
    {
        if(transform.position.y >= 0.5f || transform.position.y <= -0.5f) {
            flag = flag * -1f;
        }

        transform.position += Vector3.up * Time.deltaTime * flag *0.7f;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            SoundManager.PlaySound("win");
            GameManager.levelPassed = true;
            Destroy(gameObject);
        }
    }
}
