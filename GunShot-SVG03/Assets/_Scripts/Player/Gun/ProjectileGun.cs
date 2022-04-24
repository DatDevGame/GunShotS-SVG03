using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject explosion;
    protected int shotDame;

    private void Awake()
    {
        this.gameObject.tag = "ProjectilePlayer";
        shotDame = 1;
    }
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        Vector2 move = Vector2.right * speed * Time.deltaTime;
        transform.Translate(move);
        setDameWeapons();
    }

    protected virtual void setDameWeapons()
    {
        //Script - PlayerShot Singleton
        if (PlayerShot.ins.Pistol || PlayerShot.ins.Glock || PlayerShot.ins.Flame)
        {
            shotDame = 1;
        }
        else if (PlayerShot.ins.MachineGun)
        {
            shotDame = 5;
        }
        else if (PlayerShot.ins.Rocket)
        {
            shotDame = 20;
        }
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Crab"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            StatusEnemy hitEnemy = collision.gameObject.GetComponent<StatusEnemy>();
            hitEnemy.receiveDame(shotDame);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bat"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            StatusEnemy hitEnemy = collision.gameObject.GetComponent<StatusEnemy>();
            hitEnemy.receiveDame(shotDame);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Golem"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            StatusEnemy hitEnemy = collision.gameObject.GetComponent<StatusEnemy>();
            hitEnemy.receiveDame(shotDame);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Rat"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            StatusEnemy hitEnemy = collision.gameObject.GetComponent<StatusEnemy>();
            hitEnemy.receiveDame(shotDame);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("GolemUp"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            StatusEnemy hitEnemy = collision.gameObject.GetComponent<StatusEnemy>();
            hitEnemy.receiveDame(shotDame);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Slime"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            StatusEnemy hitEnemy = collision.gameObject.GetComponent<StatusEnemy>();
            hitEnemy.receiveDame(shotDame);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
