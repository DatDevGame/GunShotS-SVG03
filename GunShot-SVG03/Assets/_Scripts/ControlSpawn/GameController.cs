using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController ins;
    AudioSource aus;

    //Box check Player 
    public Transform posCheckCrab;
    public LayerMask layer;
    [SerializeField] private float PosXBox;
    [SerializeField] private float PosYBox;

    public Transform boxCheckBatAndCrab;
    [SerializeField] private float PosXBox2;
    [SerializeField] private float PosYBox2;

    //General
    public GameObject target;
    public GameObject setActiveTrap;
    public GameObject setActiveTrap2;
    public GameObject setActiveTrap3;

    //Enemy Crab - Enemy Bat
    protected int randomSpawn;
    public GameObject crabPrefabs;
    public Transform PosSpawnCrab;
    protected bool checkPlayerZoneCrab;
    protected int checkQuantilyCrab;

    protected int triggerQuantily;
    protected bool setTrigerBat;
    public GameObject batPrefabs;
    protected int checkQuantilyBatMission2;
    protected int checkQuantilyCrabMission2;
    protected bool checkPlayerZoneBatAndCrab;
    public Transform posSpawnBatAndCrab1;
    public Transform posSpawnBatAndCrab2;
    protected int randSpawnBatAndCrab;
    protected int spawnRandom;
    protected float randXposSpawnItemSpeedAndMedical;
    protected float randYposSpawnItemSpeedAndMedical;


    //Spawn Boss Mission 2
    public GameObject BossPrefabs;
    protected bool bossShow;



    //Time Spawn Crab - Bat
    protected float timerCrab;
    protected float timeDurationCrab;
    protected float timerBat;
    protected float timeDurationBat;


    //Spawn Item Speed Up Shot
    public GameObject ItemSpeedUpPrefabs;
    public Transform posSpawnItemSpeedUp;
    protected float ranXposItemSpeedUp;
    protected float ranYposItemSpeedUp;
    protected float timerItemSpeedUp;
    protected float timeDurationItemSpeedUp;
    public AudioClip soundHelicopterDropItem;

    //Spawn Item Medical
    public GameObject MedicalPrefabs;
    public Transform posSpawnMedical;
    protected float randXPosMedical;
    protected float randYPosMedical;
    protected float timeSpawnMedical;


    //Set NPC
    public GameObject effectMission;
    private void Awake()
    {
        ins = this;
        target = GameObject.Find("Player");
        posCheckCrab = transform.Find("posCheckCrab");
        aus = GetComponent<AudioSource>();
    }

    protected virtual void Start()
    {
        //Spawn Item Medical
        timeSpawnMedical = Random.Range(200f, 250f);
        randXPosMedical = Random.Range(-3.5f, 3.5f);
        randYPosMedical = Random.Range(-3.5f, 3.5f);

        //Spawn Item Speed Up Shot
        timeDurationItemSpeedUp = 100f;
        timerItemSpeedUp = timeDurationItemSpeedUp;
        ranXposItemSpeedUp = Random.Range(-3.5f, 3.5f);
        ranYposItemSpeedUp = Random.Range(-3.5f, 3.5f);

        setActiveTrap.SetActive(false);
        setActiveTrap2.SetActive(false);
        setActiveTrap3.SetActive(true);
        //Time Spawn Crab
        timeDurationCrab = 1.5f;
        timerCrab = timeDurationCrab;
        timeDurationBat = 1f;
        timerBat = timeDurationBat;

        //Spawn Bat
        setTrigerBat = true;
        spawnRandom = Random.Range(1, 5);
        randSpawnBatAndCrab = Random.Range(1, 3);
        randXposSpawnItemSpeedAndMedical = Random.Range(35f, 65f);
        randYposSpawnItemSpeedAndMedical = Random.Range(-66f, -59f);
    }
    protected virtual void Update()
    {
        #region Set Spawn Time And Pos Random Map - 1
        randomSpawn = Random.Range(1, 5);
        //Spawn Enemy
        SpawnEnemyCrabMap1();
        boxCheckSpawn();
        SpawnItemSpeedUp();
        SpawnItemMedical();
        DisableIconNpc();
        SpawnEnemyBatAndCrab();
        boxCheckSpawn2();
        SpawnRandomPosItemSpeedAndMedical();
        SpawnBossMission2();
        #endregion
    }
    #region -------------------------Map-1 Game----------------------
    //General Mission
    protected virtual void SpawnItemSpeedUp()
    {
        if (checkPlayerZoneBatAndCrab) return;

            if (checkPlayerZoneCrab && !checkPlayerZoneBatAndCrab)
        {
            timerItemSpeedUp -= Time.deltaTime;
            if (timerItemSpeedUp <= 0)
            {
                aus.PlayOneShot(soundHelicopterDropItem);
                Instantiate(ItemSpeedUpPrefabs, new Vector2(posSpawnItemSpeedUp.position.x + ranXposItemSpeedUp, posSpawnItemSpeedUp.position.y + ranYposItemSpeedUp), Quaternion.identity);
                ranXposItemSpeedUp = Random.Range(-3.5f, 3.5f);
                ranYposItemSpeedUp = Random.Range(-3.5f, 3.5f);
                timerItemSpeedUp = timeDurationItemSpeedUp;
            }
        }
    }
    protected virtual void SpawnItemMedical()
    {
        if (checkPlayerZoneBatAndCrab) return;

        if (checkPlayerZoneCrab && !checkPlayerZoneBatAndCrab || !checkPlayerZoneCrab && checkPlayerZoneBatAndCrab)
        {
            timeSpawnMedical -= Time.deltaTime;
            if (timeSpawnMedical <= 0)
            {
                aus.PlayOneShot(soundHelicopterDropItem);
                Instantiate(MedicalPrefabs, new Vector2(posSpawnMedical.position.x + randXPosMedical, posSpawnMedical.position.y + randYPosMedical), Quaternion.identity);
                timeSpawnMedical = Random.Range(200f, 250f);
            }
        }
    }

    //Mission - 1 Spawn Crab
    protected virtual void SpawnEnemyCrabMap1()
    {
        if (checkQuantilyCrab >= 500)
        {
            timeDurationCrab = 1.5f;
            setActiveTrap2.SetActive(false);
            checkPlayerZoneCrab = false;
            return;
        }
        if (MissionPlayer.ins.checkQuantilyCrabDead >= 200)
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
                    checkQuantilyCrab++;
                    timerCrab = timeDurationCrab;
                }
                else if (randomSpawn == 2)
                {
                    Instantiate(crabPrefabs, new Vector2(PosSpawnCrab.position.x, PosSpawnCrab.position.y + 0.5f), Quaternion.identity);
                    checkQuantilyCrab++;
                    timerCrab = timeDurationCrab;
                }
                else if (randomSpawn == 3)
                {
                    Instantiate(crabPrefabs, new Vector2(PosSpawnCrab.position.x, PosSpawnCrab.position.y - 0.5f), Quaternion.identity);
                    checkQuantilyCrab++;
                    timerCrab = timeDurationCrab;
                }
                else if (randomSpawn == 4)
                {
                    Instantiate(crabPrefabs, new Vector2(PosSpawnCrab.position.x, PosSpawnCrab.position.y - 1f), Quaternion.identity);
                    checkQuantilyCrab++;
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
            checkPlayerZoneBatAndCrab = false;
            setActiveTrap.SetActive(true);
            setActiveTrap2.SetActive(true);
        }
    }
    protected virtual void DisableIconNpc()
    {
        if (MissionPlayer.ins.checkClickBtnMission0)
        {
            effectMission.SetActive(false);
        }

    }

    //Mission - 2 Spawn Crab and Bat
    

    protected virtual void SpawnEnemyBatAndCrab()
    {
        if (checkPlayerZoneBatAndCrab)
        {
            timerBat -= Time.deltaTime;
            if (timerBat <= 0)
            {
                if (randSpawnBatAndCrab == 1)
                {
                    if (spawnRandom == 1)
                    {
                        spawnRandom = Random.Range(1, 5);
                        randSpawnBatAndCrab = Random.Range(1, 3);
                        timerBat = timeDurationBat;
                        if (checkQuantilyCrabMission2 < 300)
                        {
                            if (checkQuantilyCrabMission2 >= 300) return;
                            Instantiate(crabPrefabs, new Vector2(posSpawnBatAndCrab1.position.x, posSpawnBatAndCrab1.position.y - 2f), Quaternion.identity);
                            checkQuantilyCrabMission2++;
                        }
                        if(checkQuantilyBatMission2 <= 500)
                        {
                            if (checkQuantilyBatMission2 > 500) return;
                            Instantiate(batPrefabs, new Vector2(posSpawnBatAndCrab1.position.x, posSpawnBatAndCrab1.position.y + 2f), Quaternion.identity);
                            checkQuantilyBatMission2++;
                        }
                    }
                    else if (spawnRandom == 2)
                    {
                        spawnRandom = Random.Range(1, 5);
                        randSpawnBatAndCrab = Random.Range(1, 3);
                        timerBat = timeDurationBat;
                        if (checkQuantilyCrabMission2 < 300)
                        {
                            if (checkQuantilyCrabMission2 >= 300) return;
                            Instantiate(crabPrefabs, new Vector2(posSpawnBatAndCrab1.position.x, posSpawnBatAndCrab1.position.y - 1f), Quaternion.identity);
                            checkQuantilyCrabMission2++;
                        }
                        if (checkQuantilyBatMission2 <= 500)
                        {
                            if (checkQuantilyBatMission2 > 500) return;
                            Instantiate(batPrefabs, new Vector2(posSpawnBatAndCrab1.position.x, posSpawnBatAndCrab1.position.y + 1f), Quaternion.identity);
                            checkQuantilyBatMission2++;
                        }
                    }
                    else if (spawnRandom == 3)
                    {
                        spawnRandom = Random.Range(1, 5);
                        randSpawnBatAndCrab = Random.Range(1, 3);
                        timerBat = timeDurationBat;
                        if (checkQuantilyCrabMission2 < 300)
                        {
                            if (checkQuantilyCrabMission2 >= 300) return;
                            Instantiate(crabPrefabs, new Vector2(posSpawnBatAndCrab1.position.x, posSpawnBatAndCrab1.position.y), Quaternion.identity);
                            checkQuantilyCrabMission2++;
                        }
                        if (checkQuantilyBatMission2 <= 500)
                        {
                            if (checkQuantilyBatMission2 > 500) return;
                            Instantiate(batPrefabs, new Vector2(posSpawnBatAndCrab1.position.x, posSpawnBatAndCrab1.position.y), Quaternion.identity);
                            checkQuantilyBatMission2++;
                        }
                    }
                    else if (spawnRandom == 4)
                    {
                        spawnRandom = Random.Range(1, 5);
                        randSpawnBatAndCrab = Random.Range(1, 3);
                        timerBat = timeDurationBat;
                        if (checkQuantilyCrabMission2 < 300)
                        {
                            if (checkQuantilyCrabMission2 >= 300) return;
                            Instantiate(crabPrefabs, new Vector2(posSpawnBatAndCrab1.position.x, posSpawnBatAndCrab1.position.y + 1f), Quaternion.identity);
                            checkQuantilyCrabMission2++;
                        }
                        if (checkQuantilyBatMission2 <= 500)
                        {
                            if (checkQuantilyBatMission2 > 500) return;
                            Instantiate(batPrefabs, new Vector2(posSpawnBatAndCrab1.position.x, posSpawnBatAndCrab1.position.y - 1f), Quaternion.identity);
                            checkQuantilyBatMission2++;
                        }
                    }
                    else
                    {
                        spawnRandom = Random.Range(1, 5);
                        randSpawnBatAndCrab = Random.Range(1, 3);
                        timerBat = timeDurationBat;
                        if (checkQuantilyCrabMission2 < 300)
                        {
                            if (checkQuantilyCrabMission2 >= 300) return;
                            Instantiate(crabPrefabs, new Vector2(posSpawnBatAndCrab1.position.x, posSpawnBatAndCrab1.position.y + 2f), Quaternion.identity);
                            checkQuantilyCrabMission2++;
                        }
                        if (checkQuantilyBatMission2 <= 500)
                        {
                            if (checkQuantilyBatMission2 > 500) return;
                            Instantiate(batPrefabs, new Vector2(posSpawnBatAndCrab1.position.x, posSpawnBatAndCrab1.position.y - 2f), Quaternion.identity);
                            checkQuantilyBatMission2++;
                        }
                    }
                }
                else if(randSpawnBatAndCrab == 2)
                {
                    if (spawnRandom == 1)
                    {
                        spawnRandom = Random.Range(1, 5);
                        randSpawnBatAndCrab = Random.Range(1, 3);
                        timerBat = timeDurationBat;
                        if (checkQuantilyCrabMission2 < 300)
                        {
                            if (checkQuantilyCrabMission2 >= 300) return;
                            Instantiate(crabPrefabs, new Vector2(posSpawnBatAndCrab2.position.x, posSpawnBatAndCrab2.position.y - 2f), Quaternion.identity);
                            checkQuantilyCrabMission2++;
                        }
                        if (checkQuantilyBatMission2 <= 500)
                        {
                            if (checkQuantilyBatMission2 > 500) return;
                            Instantiate(batPrefabs, new Vector2(posSpawnBatAndCrab2.position.x, posSpawnBatAndCrab2.position.y + 2f), Quaternion.identity);
                            checkQuantilyBatMission2++;
                        }

                    }
                    else if (spawnRandom == 2)
                    {
                        spawnRandom = Random.Range(1, 5);
                        randSpawnBatAndCrab = Random.Range(1, 3);
                        timerBat = timeDurationBat;
                        if (checkQuantilyCrabMission2 < 300)
                        {
                            if (checkQuantilyCrabMission2 >= 300) return;
                            Instantiate(crabPrefabs, new Vector2(posSpawnBatAndCrab2.position.x, posSpawnBatAndCrab2.position.y - 1f), Quaternion.identity);
                            checkQuantilyCrabMission2++;
                        }
                        if (checkQuantilyBatMission2 <= 500)
                        {
                            if (checkQuantilyBatMission2 > 500) return;
                            Instantiate(batPrefabs, new Vector2(posSpawnBatAndCrab2.position.x, posSpawnBatAndCrab2.position.y + 1f), Quaternion.identity);
                            checkQuantilyBatMission2++;
                        }
                    }
                    else if (spawnRandom == 3)
                    {
                        spawnRandom = Random.Range(1, 5);
                        randSpawnBatAndCrab = Random.Range(1, 3);
                        timerBat = timeDurationBat;
                        if (checkQuantilyCrabMission2 < 300)
                        {
                            if (checkQuantilyCrabMission2 >= 300) return;
                            Instantiate(crabPrefabs, new Vector2(posSpawnBatAndCrab2.position.x, posSpawnBatAndCrab2.position.y), Quaternion.identity);
                            checkQuantilyCrabMission2++;
                        }
                        if (checkQuantilyBatMission2 <= 500)
                        {
                            if (checkQuantilyBatMission2 > 500) return;
                            Instantiate(batPrefabs, new Vector2(posSpawnBatAndCrab2.position.x, posSpawnBatAndCrab2.position.y), Quaternion.identity);
                            checkQuantilyBatMission2++;
                        }
                    }
                    else if (spawnRandom == 4)
                    {
                        spawnRandom = Random.Range(1, 5);
                        randSpawnBatAndCrab = Random.Range(1, 3);
                        timerBat = timeDurationBat;
                        if (checkQuantilyCrabMission2 < 300)
                        {
                            if (checkQuantilyCrabMission2 >= 300) return;
                            Instantiate(crabPrefabs, new Vector2(posSpawnBatAndCrab2.position.x, posSpawnBatAndCrab2.position.y + 1f), Quaternion.identity);
                            checkQuantilyCrabMission2++;
                        }
                        if (checkQuantilyBatMission2 <= 500)
                        {
                            if (checkQuantilyBatMission2 > 500) return;
                            Instantiate(batPrefabs, new Vector2(posSpawnBatAndCrab2.position.x, posSpawnBatAndCrab2.position.y - 1f), Quaternion.identity);
                            checkQuantilyBatMission2++;
                        }
                    }
                    else
                    {
                        spawnRandom = Random.Range(1, 5);
                        randSpawnBatAndCrab = Random.Range(1, 3);
                        timerBat = timeDurationBat;
                        if (checkQuantilyCrabMission2 < 300)
                        {
                            if (checkQuantilyCrabMission2 >= 300) return;
                            Instantiate(crabPrefabs, new Vector2(posSpawnBatAndCrab2.position.x, posSpawnBatAndCrab2.position.y + 2f), Quaternion.identity);
                            checkQuantilyCrabMission2++;
                        }
                        if (checkQuantilyBatMission2 <= 500)
                        {
                            if (checkQuantilyBatMission2 > 500) return;
                            Instantiate(batPrefabs, new Vector2(posSpawnBatAndCrab2.position.x, posSpawnBatAndCrab2.position.y - 2f), Quaternion.identity);
                            checkQuantilyBatMission2++;
                        }
                    }
                }
            }
        }
    }

    protected virtual void SpawnBossMission2()
    {
        if (bossShow) return;

        if (checkQuantilyCrabMission2 > 200)
        {
            Instantiate(BossPrefabs, new Vector2(49.2f, -63f), Quaternion.identity);
            bossShow = true;
        }
        
    }
    protected virtual void boxCheckSpawn2()
    {
        RaycastHit2D CheckPlayer = Physics2D.BoxCast(boxCheckBatAndCrab.position, new Vector2(PosXBox2, PosYBox2), 0f, Vector2.right, 0f, layer);
        if (CheckPlayer.collider != null)
        {
            checkPlayerZoneCrab = false;
            checkPlayerZoneBatAndCrab = true;
            setActiveTrap3.SetActive(true);
            Debug.Log("Box Mission 2 true");
        }
    }
    protected virtual void SpawnRandomPosItemSpeedAndMedical()
    {
        if (checkPlayerZoneBatAndCrab)
        {
            if (StatusEnemy.ins.checkBossMap1Dead) return;
            timerItemSpeedUp -= Time.deltaTime;
            Debug.Log(timerItemSpeedUp);
            if (timerItemSpeedUp <= 0)
            {
                aus.PlayOneShot(soundHelicopterDropItem);
                Instantiate(ItemSpeedUpPrefabs, new Vector2(randXposSpawnItemSpeedAndMedical, randYposSpawnItemSpeedAndMedical), Quaternion.identity);
                randXposSpawnItemSpeedAndMedical = Random.Range(35f, 65f);
                randYposSpawnItemSpeedAndMedical = Random.Range(-66f, -59f);
                timerItemSpeedUp = timeDurationItemSpeedUp;
            }

            timeSpawnMedical -= Time.deltaTime;
            if(timeSpawnMedical <= 0)
            {
                aus.PlayOneShot(soundHelicopterDropItem);
                Instantiate(MedicalPrefabs, new Vector2(randXposSpawnItemSpeedAndMedical, randYposSpawnItemSpeedAndMedical), Quaternion.identity);
                randXposSpawnItemSpeedAndMedical = Random.Range(35f, 65f);
                randYposSpawnItemSpeedAndMedical = Random.Range(-66f, -59f);
                checkQuantilyCrabMission2++;
                timeSpawnMedical = Random.Range(200f, 250f);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(boxCheckBatAndCrab.position, new Vector2(PosXBox2, PosYBox2));
        Gizmos.DrawWireCube(boxCheckBatAndCrab.position, new Vector2(PosXBox2, PosYBox2));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && setTrigerBat)
        {
            if (triggerQuantily >= 4)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                return;
            }
            triggerQuantily++;
            Instantiate(batPrefabs, new Vector2(49f, -50f), Quaternion.identity);
            Instantiate(batPrefabs, new Vector2(48f, -50f), Quaternion.identity);
            Instantiate(batPrefabs, new Vector2(47f, -50f), Quaternion.identity);
            Instantiate(batPrefabs, new Vector2(50f, -50f), Quaternion.identity);
            Instantiate(batPrefabs, new Vector2(51f, -50f), Quaternion.identity);
            Instantiate(batPrefabs, new Vector2(52f, -50f), Quaternion.identity);
            Instantiate(crabPrefabs, new Vector2(48f, -50f), Quaternion.identity);
            Instantiate(crabPrefabs, new Vector2(47f, -50f), Quaternion.identity);
            Instantiate(crabPrefabs, new Vector2(50f, -50f), Quaternion.identity);
            GetComponent<BoxCollider2D>().offset = new Vector2(48.8f, -33f);
            if (triggerQuantily == 2)
            {
                GetComponent<BoxCollider2D>().offset = new Vector2(48.8f, -37f);
            }
            else if (triggerQuantily == 3)
            {
                GetComponent<BoxCollider2D>().offset = new Vector2(48.8f, -42f);
            }
        }
    }
    #endregion
}

