using UnityEngine;
using System.Collections;

public class Test_Enemy : MonoBehaviour {

    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemySpeed;
    public float damping;
    public Transform fpsTarget;
    Rigidbody theRigidBody;
    Renderer myRender;




	// Use this for initialization
	void Start () {
        myRender = GetComponent<Renderer>();
        theRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position,transform.position);
        if (fpsTargetDistance<enemyLookDistance)
        {
            //myRender.material.color = Color.red; (changes the cubes colour)
            lookAtPlayer();
        }
        if (fpsTargetDistance<attackDistance)
        {
            attackPlease();
        }

    }
    
    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position- transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*damping);
    }

    void attackPlease()
    {
        theRigidBody.AddForce(transform.forward * enemySpeed);
    }
}
