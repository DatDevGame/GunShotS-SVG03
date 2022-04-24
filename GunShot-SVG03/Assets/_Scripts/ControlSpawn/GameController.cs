using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Box check Player 
    public Transform posCheckCrab;
    public LayerMask layer;
    [SerializeField] private float PosXBox;
    [SerializeField] private float PosYBox;

    public GameObject target;

    public GameObject crabPrefabs;
    public Transform PosSpawnCrab;
    protected bool checkPlayerZoneCrab;
    protected int checkQuantity;
    public GameObject setActiveTrap;
    public GameObject setActiveTrap2;

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

    //Spawn Item Speed Up Shot
    public GameObject ItemSpeedUpPrefabs;
    public Transform posSpawnItemSpeedUp;
    protected float ranXposItemSpeedUp;
    protected float ranYposItemSpeedUp;
    protected float timerItemSpeedUp;
    protected float timeDurationItemSpeedUp;

    private void Awake()
    {
        target = GameObject.Find("Player");
        posCheckCrab = transform.Find("posCheckCrab");
        PosSpawnCrab = transform.Find("PosSpawnCrab");
        posSpawnItemSpeedUp = transform.Find("posSpawnItemSpeedUp");
    }

    protected virtual void Start()
    {
        //Spawn Item Speed Up Shot
        timeDurationItemSpeedUp = 100f;
        timerItemSpeedUp = timeDurationItemSpeedUp;
        ranXposItemSpeedUp = Random.Range(-3.5f, 3.5f);
        ranYposItemSpeedUp = Random.Range(-3.5f, 3.5f);

        setActiveTrap.SetActive(false);
        setActiveTrap2.SetActive(false);
        //Time Spawn Crab
        timeDurationCrab = 1.5f;
        timerCrab = timeDurationCrab;
        timeDurationBat = 8f;
        timerCrab = timeDurationBat;
        timeDurationRat = 15f;
        timerRat = timeDurationRat;
        timeDurationGolem = 20f;
        timerGolem = timeDurationGolem;

    }
    protected virtual void Update()
    {
        #region Set Spawn Time And Pos Random
        randomSpawn = Random.Range(1, 5);
        //Spawn Enemy
        SpawnEnemyCrabMap1();
        boxCheckSpawn();
        SpawnItemSpeedUp();
        #endregion
    }
    #region -------------------------Map-1 Game----------------------
    protected virtual void SpawnEnemyCrabMap1()
    {
        if (checkQuantity >= 300)
        {
            timeDurationCrab = 1.5f;
            setActiveTrap2.SetActive(false);
            checkPlayerZoneCrab = false;
            return;
        }
        if (checkQuantity >= 200)
        {
            timeDurationCrab = 0.5f;
        }
        if (checkPlayerZoneCrab)
        {
            timerCrab -= Time.deltaTime;
            if (timerCrab <= 0)
            {
                if (randomSpawn == 1)
                {
                    Instantiate(crabPrefabs, new Vector2(PosSpawnCrab.position.x, PosSpawnCrab.position.y + 1f), Quaternion.identity);
                    checkQuantity++;
                    timerCrab = timeDurationCrab;
                }
                else if (randomSpawn == 2)
                {
                    Instantiate(crabPrefabs, new Vector2(PosSpawnCrab.position.x, PosSpawnCrab.position.y + 0.5f), Quaternion.identity);
                    checkQuantity++;
                    timerCrab = timeDurationCrab;
                }
                else if (randomSpawn == 3)
                {
                    Instantiate(crabPrefabs, new Vector2(PosSpawnCrab.position.x, PosSpawnCrab.position.y - 0.5f), Quaternion.identity);
                    checkQuantity++;
                    timerCrab = timeDurationCrab;
                }
                else if (randomSpawn == 4)
                {
                    Instantiate(crabPrefabs, new Vector2(PosSpawnCrab.position.x, PosSpawnCrab.position.y - 1f), Quaternion.identity);
                    checkQuantity++;
                    timerCrab = timeDurationCrab;
                }
            }
        }
    }
    protected virtual void boxCheckSpawn()
    {
        RaycastHit2D CheckPlayer = Physics2D.BoxCast(posCheckCrab.position, new Vector2(PosXBox, PosYBox), 0f, Vector2.right, 0f, layer);
        if (CheckPlayer.collider != null)
        {
            checkPlayerZoneCrab = true;
            setActiveTrap.SetActive(true);
            setActiveTrap2.SetActive(true);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(posCheckCrab.position, new Vector2(PosXBox, PosYBox));
    }
    protected virtual void SpawnItemSpeedUp()
    {
        if (checkPlayerZoneCrab)
        {
            timerItemSpeedUp -= Time.deltaTime;
            Debug.Log(timerItemSpeedUp);
            if (timerItemSpeedUp <= 0)
            {
                Instantiate(ItemSpeedUpPrefabs, new Vector2(posSpawnItemSpeedUp.position.x + ranXposItemSpeedUp, posSpawnItemSpeedUp.position.y + ranYposItemSpeedUp), Quaternion.identity);
                ranXposItemSpeedUp = Random.Range(-3.5f, 3.5f);
                ranYposItemSpeedUp = Random.Range(-3.5f, 3.5f);
                timerItemSpeedUp = timeDurationItemSpeedUp;
            }
        }
    }
    #endregion

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

