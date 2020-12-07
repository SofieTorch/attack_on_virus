using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    Transform bulletPoint = default;
    [SerializeField]
    GameObject bullet = default;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("x")) {
            Instantiate(bullet, bulletPoint.position, Quaternion.identity);
        }
    }
}
