using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {

    public Transform player, body, head;
    public float damping = 3f;

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //the body needs to do this
            var lookPos = player.position - body.transform.position;
            lookPos.y = 0;
            var rotationY = Quaternion.LookRotation(lookPos);
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation, rotationY, Time.deltaTime * damping);

            ////the head needs to do it, but on the x axis.
            //var lookDir = player.position - head.transform.position;
            //lookDir.x = 0;
            //var rotationX = Quaternion.LookRotation(lookDir);
            //head.transform.rotation = Quaternion.Slerp(head.transform.rotation, rotationX, Time.deltaTime * damping);
        }
    }
}