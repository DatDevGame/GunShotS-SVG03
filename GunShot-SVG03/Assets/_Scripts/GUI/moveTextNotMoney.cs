using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTextNotMoney : MonoBehaviour
{
    protected float speed;


    protected virtual void Start()
    {
        Destroy(gameObject, 1f);
        speed = 0.001f;
    }
    protected virtual void Update()
    {
        transform.position = Vector2.up * speed * Time.deltaTime;
    }
}
