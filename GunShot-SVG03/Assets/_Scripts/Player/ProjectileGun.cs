using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    [SerializeField] private float speed;

    protected int shotDame;

    private void Awake()
    {
        shotDame = 10;
    }
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        Vector2 move = Vector2.right * speed * Time.deltaTime;
        transform.Translate(move);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crab"))
        {
            StatusEnemy hitEnemy = collision.gameObject.GetComponent<StatusEnemy>();
            hitEnemy.receiveDame(shotDame);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bat"))
        {
            StatusEnemy hitEnemy = collision.gameObject.GetComponent<StatusEnemy>();
            hitEnemy.receiveDame(shotDame);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Golem"))
        {
            StatusEnemy hitEnemy = collision.gameObject.GetComponent<StatusEnemy>();
            hitEnemy.receiveDame(shotDame);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Rat"))
        {
            StatusEnemy hitEnemy = collision.gameObject.GetComponent<StatusEnemy>();
            hitEnemy.receiveDame(shotDame);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("GolemUp"))
        {
            StatusEnemy hitEnemy = collision.gameObject.GetComponent<StatusEnemy>();
            hitEnemy.receiveDame(shotDame);
            Destroy(gameObject);
        }
    }
}
