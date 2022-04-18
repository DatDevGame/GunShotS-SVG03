using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public static EnemyMove ins;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float distance;
    public  GameObject target;

    protected bool stopMoveAttack;

    public virtual void Start()
    {
        ins = this;

        target = GameObject.Find("Player");
    }
    protected virtual void Update()
    {
        move();
        directionMove();
    }
    protected virtual void move()
    {
        if (StatusPlayer.ins.currentHealth <= 0)
        {
            StatusEnemy.ins.anim.SetBool("Enemy-Mini-Move", false);
            return;
        }


        if (!stopMoveAttack)
        {
            distance = Vector2.Distance(transform.position, target.transform.position);
            if (distance <= 1.5f)
            {
                StatusEnemy.ins.anim.SetBool("Enemy-Mini-Move", false);
                return;
            }
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            StatusEnemy.ins.anim.SetBool("Enemy-Mini-Move", true);
        }
    }
    protected virtual void directionMove()
    {
        if (target.transform.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (target.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0);
        }
    }


    //Set AnimAtion
    protected void stopMoveAttackTrue()
    {
        stopMoveAttack = true;
    }
    protected void stopMoveAttackFalse()
    {
        stopMoveAttack = false;
    }
}
