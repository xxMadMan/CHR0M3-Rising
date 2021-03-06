﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_Test : MonoBehaviour {

    public float playerDistance;
    public float aimingDistance;
    public Transform _player;
    public float damping = 3f;
    public Transform point;
    public GameObject bullet;

    public GameObject head, body;

    public float tBS = 4f;
    float timestamp;

    void FixedUpdate()
    {
        playerDistance = Vector3.Distance(_player.position, transform.position);
        if (playerDistance < aimingDistance)
        {
            BodyRotation();
            Aiming();
        }
    }

    void BodyRotation()
    {
        var lookPos = _player.position - body.transform.position;
        lookPos.y = 0;
        var rotationY = Quaternion.LookRotation(lookPos);
        body.transform.rotation = Quaternion.Slerp(body.transform.rotation, rotationY, Time.deltaTime * damping);
    }

    void Aiming()
    {
        Quaternion rotation = Quaternion.LookRotation(_player.position - head.transform.position);
        head.transform.rotation = Quaternion.Slerp(head.transform.rotation, rotation, Time.deltaTime * damping);

        if(Time.time >= timestamp)
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
