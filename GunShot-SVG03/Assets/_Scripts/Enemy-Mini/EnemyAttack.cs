using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Animator anim;

    public Transform checkCircle;
    public Transform attackPoint;
    [SerializeField] private float radiusCheck;
    [SerializeField] private float radiusAttack;
    [SerializeField] private int damePlayer;
    public LayerMask layer;
    public bool hitCircle;

    private float timer;
    private float timeDuration;


    protected virtual void Start()
    {
        anim = GetComponent<Animator>();

        timeDuration = 2f;
        timer = timeDuration;
    }
    protected virtual void Update()
    {
        timeAttack();
    }
    protected virtual void attack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, radiusAttack, layer);
        foreach (Collider2D hitPlayer in hit)
        {
            if (hitPlayer.tag == "Player")
            {
                hitPlayer.GetComponent<StatusPlayer>().ReveiDame(damePlayer);
            }
        }
    }


    protected virtual void timeAttack()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            checkCirleAttack();
        }
    }
    protected virtual void checkCirleAttack()
    {
        hitCircle = Physics2D.OverlapCircle(checkCircle.position, radiusCheck, layer);
        if (hitCircle)
        {
            anim.SetTrigger("Enemy-Mini-Attack");
            timer = timeDuration;
        }
        else return;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radiusAttack);
        Gizmos.DrawWireSphere(checkCircle.position, radiusCheck);
    }
}
