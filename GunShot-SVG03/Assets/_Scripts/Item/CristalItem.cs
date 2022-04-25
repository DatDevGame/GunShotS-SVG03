using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalItem : MonoBehaviour
{
    public GameObject target;
    protected float speed;
   protected virtual void Start()
    {
        target = GameObject.Find("Player");
        speed = 5f;
    }

    protected virtual void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StatusPlayer reCristal = collision.gameObject.GetComponent<StatusPlayer>();
            reCristal.ReceiveCristal(1);
            Destroy(gameObject);
        }
    }
}
