using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveGeneral : MonoBehaviour
{
    Animator anim;

    public GameObject target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float distance;

    //Move Random Enemy Slime
    protected int randMove;
    protected float randX;
    protected float randY;
    protected float timer;
    protected float timeDuration;
    protected float timer2;
    protected float time2Duration;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }
    protected virtual void Start()
    {
        if (this.gameObject.tag == "Crab")
        {
            moveSpeed = 1f;
        }

        if (this.gameObject.tag == "Bat")
        {
            moveSpeed = 3f;
        }

        if (this.gameObject.tag == "Golem")
        {
            moveSpeed = 2f;
        }

        if (this.gameObject.tag == "Rat")
        {
            moveSpeed = 2f;
        }

        if (this.gameObject.tag == "GolemUp")
        {
            moveSpeed = 0.5f;
        }

        if (this.gameObject.tag == "Slime")
        {
            moveSpeed = 1f;
        }


        //Random Pos Move Enemy Slime
        timeDuration = 1;
        timer = timeDuration;
        time2Duration = 2;
        timer2 = time2Duration; 
        randX = Random.Range(1, 5);
        randY = Random.Range(1, 5);
    }
    protected virtual void Update()
    {
        move();
        directionMove();
    }


    protected virtual void move()
    {
        this.distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance <= 0.7f)
        {
            //Anim Move Crab
            if (this.gameObject.tag == "Crab")
            {
                anim.SetBool("CrabWalk", false);
                return;
            }
            //Anim Move Bat
            if (this.gameObject.tag == "Bat")
            {
                return;
            }
            //Anim Move Golem
            if (this.gameObject.tag == "Golem")
            {
                anim.SetBool("GolemWalk", false);
                return;
            }
            //Anim Move Rat
            if (this.gameObject.tag == "Rat")
            {
                anim.SetBool("RatWalk", false);
                return;
            }
        }


        //Move Crab
        if (this.gameObject.tag == "Crab")
        {
            if (anim.GetBool("CrabDead")) return;
            anim.SetBool("CrabWalk", true);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
        //Move Bat
        if (this.gameObject.tag == "Bat")
        {
            if (anim.GetBool("BatDead")) return;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
        //Move Golem
        if (this.gameObject.tag == "Golem")
        {
            if (anim.GetBool("GolemDead")) return;
            anim.SetBool("GolemWalk", true);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
        //Move Rat
        if (this.gameObject.tag == "Rat")
        {
            if (anim.GetBool("RatDead")) return;
            anim.SetBool("RatWalk", true);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
        //Move Golem Up
        if (this.gameObject.tag == "GolemUp")
        {
            if (anim.GetBool("GolemUpDead")) return;

            if (distance > 6)
            {
                anim.SetBool("GolemUpWalk", true);
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            }
            else if (distance <= 6)
            {
                anim.SetBool("GolemUpWalk", false);
                return;
            }
        }

        //Move Slime Random
        if (this.gameObject.tag == "Slime")
        {

            if (anim.GetBool("SlimeDead")) return;

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                anim.SetBool("SlimeWalk", true);
                Vector2 moveSlime = new Vector2(target.transform.position.x + randX, target.transform.position.y + randY);
                transform.position = Vector2.MoveTowards(transform.position,
                    moveSlime,
                    moveSpeed * Time.deltaTime);


                timer2 -= Time.deltaTime;
                if (timer2 <= 0)
                {
                    anim.SetBool("SlimeWalk", false);
                    randX = Random.Range(1, 10);
                    randY = Random.Range(1, 10);
                    timer2 = time2Duration;
                    timer = timeDuration;
                }

            }
        }
    }

    protected virtual void directionMove()
    {
        if (this.gameObject.tag == "Golem")
        {
            if (anim.GetBool("GolemDead")) return;
        }
        else if (this.gameObject.tag == "Bat")
        {
            if (anim.GetBool("BatDead")) return;
        }
        else if (this.gameObject.tag == "Crab")
        {
            if (anim.GetBool("CrabDead")) return;
        }
        else if (this.gameObject.tag == "Rat")
        {
            if (anim.GetBool("RatDead")) return;
        }
        else if (this.gameObject.tag == "GolemUp")
        {
            if (anim.GetBool("GolemUpDead")) return;
        }

        if (transform.position.x < target.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (transform.position.x > target.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
}
