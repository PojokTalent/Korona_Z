using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.2f;
    float move_x, move_y;

    public Animator animator;
    new Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("move", false);  // idle default

        // input
        move_x = Input.GetAxis("Horizontal") * speed;
        move_y = Input.GetAxis("Vertical") * speed;
        
        // set animation if moving
        if (move_x != 0 || move_y != 0)
        {
            // Flip Character sprite if move left
            if(move_x < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            } else {
                transform.localScale = new Vector2(1, 1);
            }
            animator.SetBool("move", true);
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(move_x, move_y);
        transform.Translate(direction); 
    }
}
