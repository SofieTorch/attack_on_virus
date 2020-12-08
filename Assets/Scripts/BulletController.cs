using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if(GameObject.FindWithTag("Player")) {
            rb.velocity = new Vector2(+speed * Time.deltaTime, 0);
            Destroy(gameObject, 5f);
        }
    }
}
