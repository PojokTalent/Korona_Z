using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public PlayerStats stats;
    private int ammo_stats;

    public float bulletForce = 10f;

    // Update is called once per frame
    void Update()
    {
        ammo_stats = stats.GetComponent<PlayerStats>().ammo;
        if (Input.GetButtonDown("Fire1") && ammo_stats > 0)
        {
            Shoot();
            stats.GetComponent<PlayerStats>().ammo--;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
