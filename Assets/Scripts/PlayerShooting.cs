using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    Transform bulletPoint = default;
    [SerializeField]
    GameObject bullet = default;

    void Start() { }

    
    void Update()
    {
        if(Input.GetKeyDown("x")) {
            Instantiate(bullet, bulletPoint.position, Quaternion.identity);
        }
    }
}
