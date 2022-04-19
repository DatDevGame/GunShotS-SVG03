using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveGeneral : MonoBehaviour
{
    Animator anim;

    public GameObject target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float distance;


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
            //Anim Move Bat
            if (this.gameObject.tag == "Golem")
            {
                anim.SetBool("GolemWalk", false);
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
    }

    protected virtual void directionMove()
    {
        //if (anim.GetBool("CrabDead") || anim.GetBool("BatDead") || anim.GetBool("GolemDead")) return;

        if (this.gameObject.tag == "Golem")
        {
            if (anim.GetBool("GolemDead")) return;
        }
        else if (this.gameObject.tag == "Bat")
        {
            if (anim.GetBool("BatDead")) return;
        }
        else if (anim.GetBool("CrabDead"))
        {
            if (anim.GetBool("CrabDead")) return;
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
