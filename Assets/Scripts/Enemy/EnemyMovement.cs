using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public Animator animator;
    private SpriteRenderer sprite;

    // chase player
    public float range_stop;
    public float range;
    private Transform target;

    // patrol
    public float PatrolRange;
    public float time;
    private Vector2 patrol_to;
    private float WaitTime;
    private bool move = true;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        this.sprite = this.GetComponent<SpriteRenderer>();
        WaitTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        //  Move towards player within range
        if (Vector2.Distance(transform.position, target.position) > range_stop && Vector2.Distance(transform.position, target.position) < range)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            this.sprite.flipX = target.transform.position.x < this.transform.position.x;
            animator.SetBool("move", true);
            
        }
        else
        {
            // only call within a range of time
            if (move)
            {
                patrol_to = _Patrol_to();
                move = false;
                
            }

            transform.position = Vector2.MoveTowards(transform.position, patrol_to, speed * Time.deltaTime);
            this.sprite.flipX = patrol_to.x < this.transform.position.x;

            // TODO: add a check so it won't move to same direction consecutively

            // check if obj already on the randomize position
            if (Vector2.Distance(transform.position, patrol_to) <= 0.2f)
            {
                if(WaitTime <= 0)
                {
                    move = true;
                    WaitTime = time;
                    animator.SetBool("move", true);
                }
                else
                {
                    move = false;
                    WaitTime -= Time.deltaTime;
                    animator.SetBool("move", false);
                }
            }
        }
    }


    // randomize a point for the enemy to patrol
    private Vector2 _Patrol_to()
    {
        float Objx = gameObject.transform.position.x;
        float Objy = gameObject.transform.position.y;

        float goX = Objx + Random.Range(Objx - PatrolRange, Objx + PatrolRange);
        float goY = Objy + Random.Range(Objy - PatrolRange, Objy + PatrolRange);

        patrol_to = new Vector2(goX, goY);
        return patrol_to;
    }
}
