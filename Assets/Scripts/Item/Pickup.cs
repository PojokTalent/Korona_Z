using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats stats = collision.GetComponent<PlayerStats>();
            if (stats)
            {
                bool picked = stats.PickupItem(gameObject);
                if (picked)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
