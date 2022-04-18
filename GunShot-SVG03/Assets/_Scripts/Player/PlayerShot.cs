using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject projectilePrefabs;
    public GameObject firePrefabs;
    public Transform posGun;

    private float timer;
    private float timeDuration;


    protected virtual void Start()
    {
        timeDuration = 0.2f;
        timer = timeDuration;
    }
    protected virtual void Update()
    {
        Shot();
    }

    protected virtual void Shot()
    {
        if (Input.GetMouseButton(0))
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Instantiate(firePrefabs, posGun.position, posGun.rotation);
                Instantiate(projectilePrefabs, posGun.position, posGun.rotation);
                timer = timeDuration;
            }
        }
    }
}
