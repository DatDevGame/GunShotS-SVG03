using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject PrefabsEnemy1;
    public GameObject target;

    private float randPosX;
    private float randPosY;

    private float timer;
    private float timeDuration;

    protected virtual void Start()
    {
        target = GameObject.Find("Player");

        timeDuration = 2f;
        timer = timeDuration;
    }
    protected virtual void Update()
    {
        SpawnEnemy();
    }

    protected virtual void SpawnEnemy()
    {
        randPosX = Random.Range(-5f, 5f);
        randPosY = Random.Range(-5f, 5f);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(PrefabsEnemy1, new Vector2(target.transform.position.x + randPosX, target.transform.position.y + randPosY), Quaternion.identity);
            timer = timeDuration;
        }
        
    }
}
