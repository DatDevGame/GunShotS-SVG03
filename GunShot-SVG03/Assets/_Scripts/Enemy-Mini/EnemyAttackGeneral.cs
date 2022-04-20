using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackGeneral : MonoBehaviour
{
    public static EnemyAttackGeneral ins;

    Animator anim;

    //Attack Point
    public Transform attackPoint;
    public LayerMask layer;
    [SerializeField] private float attackRadius;

    //Time Next Attack
    protected float timer;
    protected float timeDuration;

    //Boxcast Check
    public Transform posBoxCast;
    [SerializeField] private float boxcastX;
    [SerializeField] private float boxcastY;
    public bool checkPlayerOnBox;


    //type Dame Enemy
    protected int dameCrab;
    protected int dameBat;
    protected int dameGolem;
    protected int dameRat;
    protected int dameGolemUp;

    //Skill GolemUp



    private void Awake()
    {
        ins = this;
        anim = GetComponent<Animator>();

        attackPoint = transform.Find("attackPoint");
        posBoxCast = transform.Find("boxPoint");
    }
    protected virtual void Start()
    {
        //Dame Enemy
        dameCrab = 1;
        dameBat = 2;
        dameGolem = 3;
        dameRat = 2;
        dameGolemUp = 10;

        timeDuration = 2f;
        timer = timeDuration;
    }
    protected virtual void Update()
    {
        boxAttack();
    }

    protected virtual void Attack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, layer);
        foreach (Collider2D hitPlayer in hit)
        {
            if (this.gameObject.tag == "Crab")
            {
                hitPlayer.GetComponent<StatusPlayer>().ReveiDame(dameCrab);
            }
            if (this.gameObject.tag == "Bat")
            {
                hitPlayer.GetComponent<StatusPlayer>().ReveiDame(dameBat);
            }
            if (this.gameObject.tag == "Golem")
            {
                hitPlayer.GetComponent<StatusPlayer>().ReveiDame(dameGolem);
            }
            if (this.gameObject.tag == "Rat")
            {
                hitPlayer.GetComponent<StatusPlayer>().ReveiDame(dameRat);
            }
        }
    }
    protected virtual void boxAttack()
    {
        RaycastHit2D hitbox = Physics2D.BoxCast(posBoxCast.position, new Vector2(boxcastX, boxcastY), 0f, Vector2.right, 0f, layer);
        if (hitbox.collider != null)
        {
            if (hitbox.collider.tag == "Player")
            {
                timeAttack();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        Gizmos.DrawWireCube(posBoxCast.position, new Vector2(boxcastX, boxcastY));
    }


    private void timeAttack()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (this.gameObject.tag == "Crab")
            {
                anim.SetTrigger("CrabAttack");
                timer = timeDuration;
            }

            if (this.gameObject.tag == "Bat")
            {
                anim.SetTrigger("BatAttack");
                timer = timeDuration;
            }

            if (this.gameObject.tag == "Golem")
            {
                anim.SetTrigger("GolemAttack");
                timer = timeDuration;
            }

            if (this.gameObject.tag == "Rat")
            {
                anim.SetTrigger("RatAttack");
                timer = timeDuration;
            }

            if (this.gameObject.tag == "GolemUp")
            {
                if (anim.GetBool("GolemUpDead")) return;

                anim.SetTrigger("GolemUpAttack");
                timer = 5f;
            }

        }
    }
}
