using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public Transform point;
    public GameObject bullet;
    public float tBS = 4f;
    float timestamp;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(Input.GetButtonDown("Fire1") && Time.time >= timestamp)
        {
            Shoot();
            timestamp = Time.time + tBS;
        }
    }

    void Shoot()
    {
        Instantiate(bullet, point.position, point.rotation);
    }
}
