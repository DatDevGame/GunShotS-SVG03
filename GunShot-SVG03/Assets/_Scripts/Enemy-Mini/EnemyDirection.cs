using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirection : MonoBehaviour
{
    public GameObject target;
    public Transform enemyTarget;


    protected virtual void Start()
    {
        target = GameObject.Find("Player");
        enemyTarget = transform.Find("Enemy-Mini");
    }
    protected virtual void Update()
    {
        direction();
    }
    protected virtual void direction()
    {
        if (target.transform.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0);
        }
        else if(target.transform.position.x > transform.position.x)
            transform.eulerAngles = new Vector3(0f, 0f, 0);
    }
}
