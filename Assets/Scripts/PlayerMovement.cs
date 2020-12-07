using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    float speed = 5f;

    Animator anim;
    GameObject camera;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        camera = GameObject.FindWithTag("MainCamera");
    }

    
    void Update()
    {
        anim.SetBool("GoingUp", false);
        anim.SetBool("GoingDown", false);

        float movementV = Input.GetAxis("Vertical");
        transform.position += Vector3.up * movementV * speed * Time.deltaTime;
        float movementH = Input.GetAxis("Horizontal");
        if(transform.position.x < camera.transform.position.x + 6) {
            transform.position += Vector3.right * movementH * speed * Time.deltaTime;
        }

        if(movementV > 0.1f) {
            anim.SetBool("GoingUp", true);
            anim.SetBool("GoingDown", false);
        }
        if(movementV < -0.1f) {
            anim.SetBool("GoingUp", false);
            anim.SetBool("GoingDown", true);
        }
    }
}
