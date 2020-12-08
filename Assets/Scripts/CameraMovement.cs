using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    GameObject gmobj = default;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(GameObject.FindWithTag("Player")) {
            if(gmobj.tag == "Stars"){
                transform.position += Vector3.left * Time.deltaTime * 0.2f;
            }
            else if(gmobj.tag == "Planets"){
                transform.position += Vector3.left * Time.deltaTime * 0.4f;
            }
            else {
                transform.position += Vector3.right * Time.deltaTime * 0.6f;
            }
        }
    }
}
