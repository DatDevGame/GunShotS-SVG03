using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFollowPlayer : MonoBehaviour
{
    public GameObject target;
    protected float distance;
    protected float speed;
    protected virtual void Start()
    {
        target = GameObject.Find("Player");
        speed = 5f;
    }
    protected virtual void Update()
    {
        move();
    }

    protected virtual void move()
    {
        this.distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance <= 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StatusPlayer ReCoin = collision.gameObject.GetComponent<StatusPlayer>();
            ReCoin.ReceiveCoin(1);
            Destroy(gameObject);
        }
    }
}
