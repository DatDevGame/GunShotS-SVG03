using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject target;
    public GameObject crabPrefabs;
    public GameObject batPrefabs;
    public GameObject ratPrefabs;
    public GameObject golemPrefabs;
    public GameObject golemUpPrefabs;

    protected float timerCrab;
    protected float timeDurationCrab;
    protected float timerBat;
    protected float timeDurationBat;
    protected float timerRat;
    protected float timeDurationRat;
    protected float timerGolem;
    protected float timeDurationGolem;

    //Set Random Spawn
    protected int randomSpawn;
    protected float randXSpawn;
    protected float randXSpawn2;
    protected float randYSpawn;
    protected float randYSpawn2;
    protected float randXSpawn3;
    protected float randXSpawn4;
    protected float randYSpawn3;
    protected float randYSpawn4;

    private void Awake()
    {
        target = GameObject.Find("Player");
    }

    protected virtual void Start()
    {
        //Time Spawn Crab
        timeDurationCrab = 1f;
        timerCrab = timeDurationCrab;
        timeDurationBat = 8f;
        timerCrab = timeDurationBat;
        timeDurationRat = 5f;
        timerRat = timeDurationRat;

    }
    protected virtual void Update()
    {
        #region Set Spawn Time And Pos Random
        randomSpawn = Random.Range(1, 5);
        randXSpawn = Random.Range(-20f, -10f);
        randXSpawn2 = Random.Range(10f, 20f);
        randYSpawn = Random.Range(-20f, -10f);
        randYSpawn2 = Random.Range(10f, 20f);

        randXSpawn3 = Random.Range(-20f, -10f);
        randXSpawn4 = Random.Range(10f, 20f);
        randYSpawn3 = Random.Range(20f,10f);
        randYSpawn4 = Random.Range(-10f, -20f);

        //Spawn Enemy
        SpawnEnemyCrab();
        SpawnEnemyBat();
        SpawnEnemyRat();
        SpawnEnemyGolem();
        #endregion
    }

    protected virtual void SpawnEnemyCrab()
    {
        timerCrab -= Time.deltaTime;
        if (timerCrab <= 0)
        {
            if (randomSpawn == 1)
            {
                Instantiate(crabPrefabs, new Vector2(target.transform.position.x + randXSpawn, target.transform.position.y + randYSpawn), Quaternion.identity);
                timerCrab = timeDurationCrab;
            }
            else if(randomSpawn == 2)
            {
                Instantiate(crabPrefabs, new Vector2(target.transform.position.x + randXSpawn2, target.transform.position.y + randYSpawn2), Quaternion.identity);
                timerCrab = timeDurationCrab;
            }
            else if (randomSpawn == 3)
            {
                Instantiate(crabPrefabs, new Vector2(target.transform.position.x + randXSpawn3, target.transform.position.y + randYSpawn3), Quaternion.identity);
                timerCrab = timeDurationCrab;
            }
            else if (randomSpawn == 4)
            {
                Instantiate(crabPrefabs, new Vector2(target.transform.position.x + randXSpawn4, target.transform.position.y + randYSpawn4), Quaternion.identity);
                timerCrab = timeDurationCrab;
            }
        }
    }
    protected virtual void SpawnEnemyBat()
    {
        if (StatusPlayer.ins.Score < 50) return;
        timerBat -= Time.deltaTime;
        if (timerBat <= 0)
        {
            if (randomSpawn == 1)
            {
                Instantiate(batPrefabs, new Vector2(target.transform.position.x + randXSpawn, target.transform.position.y + randYSpawn), Quaternion.identity);
                timerBat = timeDurationBat;
            }
            else if (randomSpawn == 2)
            {
                Instantiate(batPrefabs, new Vector2(target.transform.position.x + randXSpawn2, target.transform.position.y + randYSpawn2), Quaternion.identity);
                timerBat = timeDurationBat;
            }
            else if (randomSpawn == 3)
            {
                Instantiate(batPrefabs, new Vector2(target.transform.position.x + randXSpawn3, target.transform.position.y + randYSpawn3), Quaternion.identity);
                timerBat = timeDurationBat;
            }
            else if (randomSpawn == 4)
            {
                Instantiate(batPrefabs, new Vector2(target.transform.position.x + randXSpawn4, target.transform.position.y + randYSpawn4), Quaternion.identity);
                timerBat = timeDurationBat;
            }
        }
    }
    protected virtual void SpawnEnemyRat()
    {
        if (StatusPlayer.ins.Score < 100) return;
        timerRat -= Time.deltaTime;
        if (timerRat <= 0)
        {
            if (randomSpawn == 1)
            {
                Instantiate(ratPrefabs, new Vector2(target.transform.position.x + randXSpawn, target.transform.position.y + randYSpawn), Quaternion.identity);
                timerRat = timeDurationRat;
            }
            else if (randomSpawn == 2)
            {
                Instantiate(ratPrefabs, new Vector2(target.transform.position.x + randXSpawn2, target.transform.position.y + randYSpawn2), Quaternion.identity);
                timerRat = timeDurationRat;
            }
            else if (randomSpawn == 3)
            {
                Instantiate(ratPrefabs, new Vector2(target.transform.position.x + randXSpawn3, target.transform.position.y + randYSpawn3), Quaternion.identity);
                timerRat = timeDurationRat;
            }
            else if (randomSpawn == 4)
            {
                Instantiate(ratPrefabs, new Vector2(target.transform.position.x + randXSpawn4, target.transform.position.y + randYSpawn4), Quaternion.identity);
                timerRat = timeDurationRat;
            }
        }
    }
    protected virtual void SpawnEnemyGolem()
    {
        if (StatusPlayer.ins.Score < 200) return;
        timerGolem -= Time.deltaTime;
        if (timerGolem <= 0)
        {
            if (randomSpawn == 1)
            {
                Instantiate(golemPrefabs, new Vector2(target.transform.position.x + randXSpawn, target.transform.position.y + randYSpawn), Quaternion.identity);
                timerGolem = timeDurationGolem;
            }
            else if (randomSpawn == 2)
            {
                Instantiate(golemPrefabs, new Vector2(target.transform.position.x + randXSpawn2, target.transform.position.y + randYSpawn2), Quaternion.identity);
                timerRat = timeDurationRat;
            }
            else if (randomSpawn == 3)
            {
                Instantiate(golemPrefabs, new Vector2(target.transform.position.x + randXSpawn3, target.transform.position.y + randYSpawn3), Quaternion.identity);
                timerRat = timeDurationRat;
            }
            else if (randomSpawn == 4)
            {
                Instantiate(golemPrefabs, new Vector2(target.transform.position.x + randXSpawn4, target.transform.position.y + randYSpawn4), Quaternion.identity);
                timerRat = timeDurationRat;
            }
        }
    }
    protected virtual void SpawnEnemyGolemUp()
    {
        if (randomSpawn == 1)
        {
            Instantiate(golemUpPrefabs, new Vector2(target.transform.position.x + randXSpawn, target.transform.position.y + randYSpawn), Quaternion.identity);
            timerGolem = timeDurationGolem;
        }
        else if (randomSpawn == 2)
        {
            Instantiate(golemUpPrefabs, new Vector2(target.transform.position.x + randXSpawn2, target.transform.position.y + randYSpawn2), Quaternion.identity);
            timerRat = timeDurationRat;
        }
        else if (randomSpawn == 3)
        {
            Instantiate(golemUpPrefabs, new Vector2(target.transform.position.x + randXSpawn3, target.transform.position.y + randYSpawn3), Quaternion.identity);
            timerRat = timeDurationRat;
        }
        else if (randomSpawn == 4)
        {
            Instantiate(golemUpPrefabs, new Vector2(target.transform.position.x + randXSpawn4, target.transform.position.y + randYSpawn4), Quaternion.identity);
            timerRat = timeDurationRat;
        }
    }
}

