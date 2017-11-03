using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timer;
    public float speed;

    public string objTag;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == objTag)
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
