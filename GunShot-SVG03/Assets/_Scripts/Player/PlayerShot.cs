using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    AudioSource aus;
    public AudioClip soundPistol;

    public GameObject projectilePrefabs;
    public GameObject firePrefabs;
    public Transform posGun;

    private float timer;
    private float timeDuration;


    protected virtual void Start()
    {
        aus = GetComponent<AudioSource>();
        timeDuration = 0.3f;
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
                aus.PlayOneShot(soundPistol);
                Instantiate(firePrefabs, posGun.position, posGun.rotation);
                Instantiate(projectilePrefabs, posGun.position, posGun.rotation);
                timer = timeDuration;
            }
        }
    }
}
