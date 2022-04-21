using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSkill : MonoBehaviour
{
    public GameObject target;
    private float moveSpeed;

    protected int currentHealth;


    private void Awake()
    {
        this.gameObject.tag = "ProjectileEnemy";
        target = GameObject.Find("Player");
    }
    protected virtual void Start()    
    {
        Destroy(gameObject, 10f);
        currentHealth = 3;
        moveSpeed = 2f;
    }

    protected virtual void Update()
    {
        move();
    }
    protected virtual void move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

        if (transform.position.x < target.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (transform.position.x > target.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StatusPlayer hitPlayer = collision.gameObject.GetComponent<StatusPlayer>();
            hitPlayer.ReveiDame(10);
            Destroy(gameObject);
        }
    }
}
