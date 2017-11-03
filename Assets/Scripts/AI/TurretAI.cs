using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {

    //public Transform target, aim, head;
    //public float reloadTime = 1f, turnSpeed = 5f, firePauseTime = 0.25f, range = 3f;
    //public Transform[] muzzlePos;
    //public bool canSee;


    public Transform player;

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var lookDir = player.position - transform.position;
            lookDir.y = 0;
            transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }

    //   float nextFireTime, nextMoveTime;

    //void Start ()
    //   {

    //}


    //void Update ()
    //   {
    //	if (target)
    //       {
    //           if (Time.time >= nextMoveTime)
    //           {
    //               aim.LookAt(target);
    //               aim.eulerAngles = new Vector3(0, aim.eulerAngles.y, 0);
    //               head.rotation = Quaternion.Lerp(head.rotation, aim.rotation, Time.deltaTime * turnSpeed);
    //           }
    //           if (Time.time >= nextFireTime && canSee == true) 
    //           {
    //               Fire();
    //           }
    //       }

    //}

    //   void Fire()
    //   {
    //       nextFireTime = Time.time + reloadTime;
    //       nextMoveTime = Time.time + firePauseTime;
    //   }


}
