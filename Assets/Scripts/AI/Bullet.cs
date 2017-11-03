using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timer;
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("hit");
            Destroy(gameObject);
        }

    }

    void Awake()
    {
        Destroy(gameObject, timer);
    }

}
