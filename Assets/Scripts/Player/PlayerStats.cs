using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    // This script for Player stats (Ammo, HP, etc)
    public int ammo = 30;  // inital ammo
    public int Health = 100;  // initial health
    public Text AmmoDisplay;
    //public GameObject myPlayer;

    private float starttime;

    void Start ()
    { 
        starttime = Time.time;
    }

    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Ammo_Pack":
                ammo += 10;
                return true;
            case "Health_Pack":
                Health += 10;
                if (Health > 100) Health = 100;
                return true;
            default:
                Debug.LogWarning("No Pickup handler for obj tag " + obj.name);
                return false;
        }
    }
    
    void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy" && Time.time - starttime >= 2)
        {
            Health -= 5;
            //Debug.Log("Enemy touch you");
            starttime = Time.time;
        }
    }

    private void Update()
    {
        AmmoDisplay.text = ammo.ToString();
    }

}
