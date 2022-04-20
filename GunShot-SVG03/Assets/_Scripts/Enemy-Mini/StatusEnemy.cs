using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEnemy : MonoBehaviour
{
    public static StatusEnemy ins;

    Animator anim;

    protected int currentHealth;
    protected int maxHealth;

    private void Awake()
    {
        ins = this;
        anim = GetComponent<Animator>();
    }
    protected virtual void Start()
    {
        if (this.gameObject.tag == "Crab")
        {
            maxHealth = 100;
            currentHealth = maxHealth;
        }

        if (this.gameObject.tag == "Bat")
        {
            maxHealth = 50;
            currentHealth = maxHealth;
        }
        if (this.gameObject.tag == "Golem")
        {
            maxHealth = 200;
            currentHealth = maxHealth;
        }
        if (this.gameObject.tag == "Rat")
        {
            maxHealth = 100;
            currentHealth = maxHealth;
        }
        if (this.gameObject.tag == "GolemUp")
        {
            maxHealth = 500;
            currentHealth = maxHealth;
        }
    }
    protected virtual void Update()
    {

    }

    public virtual void receiveDame(int dame)
    {
        currentHealth -= dame;
        if (currentHealth <= 0)
        {
            dead();
        }
    }

    protected virtual void dead()
    {
        if (this.gameObject.tag == "Crab")
        {
            anim.SetBool("CrabDead", true);
            Destroy(gameObject, 3f);
        }
        if (this.gameObject.tag == "Bat")
        {
            anim.SetBool("BatDead", true);
            Destroy(gameObject, 3f);
        }
        if (this.gameObject.tag == "Golem")
        {
            anim.SetBool("GolemDead", true);
            Destroy(gameObject, 3f);
        }
        if (this.gameObject.tag == "Rat")
        {
            anim.SetBool("RatDead", true);
            Destroy(gameObject, 3f);
        }
        if (this.gameObject.tag == "GolemUp")
        {
            anim.SetBool("GolemUpDead", true);
            Destroy(gameObject, 3f);
        }
        GetComponent<Collider2D>().enabled = false;


    }
}
