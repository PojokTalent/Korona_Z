using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 5);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(collision.collider.gameObject);

        Destroy(gameObject);
    }
}
