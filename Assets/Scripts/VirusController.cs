using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VirusController : MonoBehaviour
{
    [SerializeField]
    float rotSpeed = 5f;

    [SerializeField]
    float velocity = 2f;

    [SerializeField]
    float margin = 1.2f;

    [SerializeField]
    CounterController counterCtrl = default;

    float rotZ = 0f;
    Vector3 pos;
    Animator anim;
    GameObject camera;

    void Start()
    {
        pos = transform.position;
        anim = GetComponent<Animator>();
        camera = GameObject.FindWithTag("MainCamera");
    }

    
    void FixedUpdate()
    {
        rotZ += Time.deltaTime * rotSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(transform.position.y >= pos.y + margin || transform.position.y <= pos.y - margin) {
            velocity = velocity * -1;
        }

        transform.position += Vector3.up * Time.deltaTime * velocity;
        transform.position += Vector3.left * Time.deltaTime * 2f;

        if(transform.position.x < camera.transform.position.x - 10) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet") {
            anim.SetBool("Healed", true);
            GetComponent<Collider2D>().enabled = false;
            counterCtrl.virusCount += 1;
            Destroy(collision.gameObject);
        }
    }
}
