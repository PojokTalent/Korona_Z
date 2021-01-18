using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public int hp = 2;

    public void TakeDamage()
    {
        hp--;
        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }
}
