using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShot : MonoBehaviour
{
    public static PlayerShot ins;
    UIManager ui;
    AudioSource aus;
    public AudioClip soundPistol;
    public AudioClip soundGlock;
    public AudioClip soundFlame;
    public AudioClip soundMachineGun;
    public AudioClip soundRocket;
    public AudioClip soundGattlingGun;

    public GameObject projectilePrefabs;
    public GameObject projectileLazerPrefabs;
    public GameObject projectileRocketPrefabs;
    public GameObject firePrefabs;

    //Get Pos Head Gun
    public GameObject posGun;
    public bool Pistol;
    public GameObject posGlock;
    public GameObject posGlock1;
    public GameObject posGlock2;
    public bool Glock;
    public GameObject posFlame;
    public GameObject posFlame2;
    public GameObject posFlame3;
    public GameObject posFlame4;
    public GameObject posFlame5;
    public bool Flame;
    public GameObject posMachineGun;
    public bool MachineGun;
    public GameObject posRocket;
    public bool Rocket;
    public GameObject posGattlingGun;
    public GameObject posGattlingGun1;
    public GameObject posGattlingGun2;
    public GameObject posGattlingGun3;
    public GameObject posGattlingGun4;
    public GameObject posGattlingGun5;
    public GameObject posGattlingGun6;
    public GameObject posGattlingGun7;
    public GameObject posGattlingGun8;
    public bool GattlingGun;

    //time Shot Pistrol
    private float timerPistrol;
    public float timeDurationPistrol;

    //time Shot Glock
    private float timerGlock;
    public float timeDurationGlock;
    protected int randomShowGlock;

    //time Shot Flame
    private float timerFlame;
    public float timeDurationFlame;

    //time Shot MachineGun
    private float timerMachineGun;
    public float timeDurationMachineGun;
    protected int randomShot;

    //time Shot Rocket
    private float timerRocket;
    public float timeDurationRocket;
    public GameObject showTimeItem;

    //time Shot GattlingGun
    private float timerGattlingGun;
    public float timeDurationGattlingGun;
    protected int randomShotGattlingGun;


    //Set Time Item live
    protected float timeEndItem;
    protected bool checkTimeEndItem;


    private void Awake()
    {
        ins = this;
        aus = GetComponent<AudioSource>();
        ui = FindObjectOfType<UIManager>();
        showTimeItem.SetActive(false);

    }
    protected virtual void Start()
    {
        //time Shot Pistrol
        timeDurationPistrol = 0.2f;
        timerPistrol = timeDurationPistrol;

        //time Shot Glock
        timeDurationGlock = 0.1f;
        timerGlock = timeDurationGlock;
        randomShowGlock = Random.Range(1, 4);

        //time Shot Flame
        timeDurationFlame = 0.05f;
        timerFlame = timeDurationFlame;

        //time Shot MachineGun
        timeDurationMachineGun = 0.15f;
        timerMachineGun = timeDurationMachineGun;

        //time Shot Rocket
        timeDurationRocket = 0.4f;
        timerRocket = timeDurationRocket;

        //time Shot GattlingGun
        timeDurationGattlingGun = 0.01f;
        timerGattlingGun = timeDurationGattlingGun;
        randomShotGattlingGun = Random.Range(1, 10);
    }
    protected virtual void Update()
    {
        randomShot = Random.Range(1, 5);
        posGun = GameObject.Find("posGun");
        posGlock = GameObject.Find("posGlock");
        posGlock1 = GameObject.Find("posGlock1");
        posGlock2 = GameObject.Find("posGlock2");
        posFlame = GameObject.Find("posFlame");
        posFlame2 = GameObject.Find("posFlame2");
        posFlame3 = GameObject.Find("posFlame3");
        posFlame4 = GameObject.Find("posFlame4");
        posFlame5 = GameObject.Find("posFlame5");
        posMachineGun = GameObject.Find("posMachineGun");
        posRocket = GameObject.Find("posRocket");
        posGattlingGun = GameObject.Find("posGattlingGun");
        posGattlingGun1 = GameObject.Find("posGattlingGun1");
        posGattlingGun2 = GameObject.Find("posGattlingGun2");
        posGattlingGun3 = GameObject.Find("posGattlingGun3");
        posGattlingGun4 = GameObject.Find("posGattlingGun4");
        posGattlingGun5 = GameObject.Find("posGattlingGun5");
        posGattlingGun6 = GameObject.Find("posGattlingGun6");
        posGattlingGun7 = GameObject.Find("posGattlingGun7");
        posGattlingGun8 = GameObject.Find("posGattlingGun8");
        endTimeItem();
        Shot();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpeedShotItem"))
        {
            timeEndItem = 20f;
            checkTimeEndItem = true;
            showTimeItem.SetActive(true);
        }
    }
    protected virtual void endTimeItem()
    {
        if (checkTimeEndItem)
        {
            timeEndItem -= Time.deltaTime;
            ui.setTimeItemText(""+timeEndItem);
            if (timeEndItem <= 0)
            {
                timeDurationPistrol = 0.2f;
                timeDurationGlock = 0.1f;
                timeDurationFlame = 0.05f;
                timeDurationMachineGun = 0.15f;
                timeDurationRocket = 0.4f;
                timeDurationGattlingGun = 0.01f;
                showTimeItem.SetActive(false);
                checkTimeEndItem = false;
            }
        }
    }
    protected virtual void Shot()
    {
        //Gun Pistol
        if (Input.GetMouseButton(0) && Pistol)
        {
            timerPistrol -= Time.deltaTime;
            if (timerPistrol <= 0)
            {
                aus.PlayOneShot(soundPistol);
                Instantiate(firePrefabs, posGun.transform.position, posGun.transform.rotation);
                Instantiate(projectilePrefabs, posGun.transform.position, posGun.transform.rotation);
                timerPistrol = timeDurationPistrol;
            }
        }

        //Gun Glock
        if (Input.GetMouseButton(0) && Glock)
        {
            timerGlock -= Time.deltaTime;
            if (timerGlock <= 0)
            {
                if (randomShowGlock == 1)
                {
                    aus.PlayOneShot(soundGlock);
                    Instantiate(firePrefabs, posGlock.transform.position, posGlock.transform.rotation);
                    Instantiate(projectilePrefabs, posGlock.transform.position, posGlock.transform.rotation);
                    timerGlock = timeDurationGlock;
                    randomShowGlock = Random.Range(1, 4);
                    Debug.Log(randomShowGlock);
                }
                else if (randomShowGlock == 2)
                {
                    aus.PlayOneShot(soundGlock);
                    Instantiate(firePrefabs, posGlock1.transform.position, posGlock1.transform.rotation);
                    Instantiate(projectilePrefabs, posGlock1.transform.position, posGlock1.transform.rotation);
                    timerGlock = timeDurationGlock;
                    randomShowGlock = Random.Range(1, 4);
                    Debug.Log(randomShowGlock);
                }
                else if(randomShowGlock == 3)
                {
                    aus.PlayOneShot(soundGlock);
                    Instantiate(firePrefabs, posGlock2.transform.position, posGlock2.transform.rotation);
                    Instantiate(projectilePrefabs, posGlock2.transform.position, posGlock2.transform.rotation);
                    timerGlock = timeDurationGlock;
                    randomShowGlock = Random.Range(1, 4);
                    Debug.Log(randomShowGlock);
                }
            }
        }

        //Gun Flame
        if (Input.GetMouseButton(0) && Flame)
        {
            timerFlame -= Time.deltaTime;
            if (timerFlame <= 0)
            {
                if (randomShot == 1)
                {
                    Instantiate(projectilePrefabs, posFlame.transform.position, posFlame.transform.rotation);
                }
                else if (randomShot == 2)
                {
                    Instantiate(projectilePrefabs, posFlame2.transform.position, posFlame2.transform.rotation);
                }
                else if (randomShot == 3)
                {
                    Instantiate(projectilePrefabs, posFlame3.transform.position, posFlame3.transform.rotation);
                }
                else if (randomShot == 4)
                {
                    Instantiate(projectilePrefabs, posFlame4.transform.position, posFlame4.transform.rotation);
                }
                else
                {
                    Instantiate(projectilePrefabs, posFlame5.transform.position, posFlame5.transform.rotation);
                }
                aus.PlayOneShot(soundFlame);
                Instantiate(firePrefabs, posFlame.transform.position, posFlame.transform.rotation);
                timerFlame = timeDurationFlame;
            }
        }

        //Gun MachineGun
        if (Input.GetMouseButton(0) && MachineGun)
        {
            timerMachineGun -= Time.deltaTime;
            if (timerMachineGun <= 0)
            {
                aus.PlayOneShot(soundMachineGun);
                Instantiate(projectileLazerPrefabs, posMachineGun.transform.position, posMachineGun.transform.rotation);
                timerMachineGun = timeDurationMachineGun;
            }
        }

        //Gun Rocket
        if (Input.GetMouseButton(0) && Rocket)
        {
            timerRocket -= Time.deltaTime;
            if (timerRocket <= 0)
            {
                aus.PlayOneShot(soundRocket);
                Instantiate(projectileRocketPrefabs, posRocket.transform.position, posRocket.transform.rotation);
                timerRocket = timeDurationRocket;
            }
        }

        //Gun GattlingGun
        if (Input.GetMouseButton(0) && GattlingGun)
        {
            timerGattlingGun -= Time.deltaTime;
            if (timerGattlingGun <= 0)
            {
                if (randomShotGattlingGun == 1)
                {
                    aus.PlayOneShot(soundGattlingGun);
                    Instantiate(projectilePrefabs, posGattlingGun.transform.position, posGattlingGun.transform.rotation);
                    Instantiate(firePrefabs, posGattlingGun.transform.position, posGattlingGun.transform.rotation);
                    timerGattlingGun = timeDurationGattlingGun;
                    randomShotGattlingGun = Random.Range(1, 10);
                }
                else if (randomShotGattlingGun == 2)
                {
                    aus.PlayOneShot(soundGattlingGun);
                    Instantiate(projectilePrefabs, posGattlingGun1.transform.position, posGattlingGun1.transform.rotation);
                    Instantiate(firePrefabs, posGattlingGun1.transform.position, posGattlingGun1.transform.rotation);
                    timerGattlingGun = timeDurationGattlingGun;
                    randomShotGattlingGun = Random.Range(1, 10);
                }
                else if (randomShotGattlingGun == 3)
                {
                    aus.PlayOneShot(soundGattlingGun);
                    Instantiate(projectilePrefabs, posGattlingGun2.transform.position, posGattlingGun2.transform.rotation);
                    Instantiate(firePrefabs, posGattlingGun2.transform.position, posGattlingGun2.transform.rotation);
                    timerGattlingGun = timeDurationGattlingGun;
                    randomShotGattlingGun = Random.Range(1, 10);
                }
                else if (randomShotGattlingGun == 4)
                {
                    aus.PlayOneShot(soundGattlingGun);
                    Instantiate(projectilePrefabs, posGattlingGun3.transform.position, posGattlingGun3.transform.rotation);
                    Instantiate(firePrefabs, posGattlingGun3.transform.position, posGattlingGun3.transform.rotation);
                    timerGattlingGun = timeDurationGattlingGun;
                    randomShotGattlingGun = Random.Range(1, 10);
                }
                else if (randomShotGattlingGun == 5)
                {
                    aus.PlayOneShot(soundGattlingGun);
                    Instantiate(projectilePrefabs, posGattlingGun4.transform.position, posGattlingGun4.transform.rotation);
                    Instantiate(firePrefabs, posGattlingGun4.transform.position, posGattlingGun4.transform.rotation);
                    timerGattlingGun = timeDurationGattlingGun;
                    randomShotGattlingGun = Random.Range(1, 10);
                }
                else if (randomShotGattlingGun == 6)
                {
                    aus.PlayOneShot(soundGattlingGun);
                    Instantiate(projectilePrefabs, posGattlingGun5.transform.position, posGattlingGun5.transform.rotation);
                    Instantiate(firePrefabs, posGattlingGun5.transform.position, posGattlingGun5.transform.rotation);
                    timerGattlingGun = timeDurationGattlingGun;
                    randomShotGattlingGun = Random.Range(1, 10);
                }
                else if (randomShotGattlingGun == 7)
                {
                    aus.PlayOneShot(soundGattlingGun);
                    Instantiate(projectilePrefabs, posGattlingGun6.transform.position, posGattlingGun6.transform.rotation);
                    Instantiate(firePrefabs, posGattlingGun6.transform.position, posGattlingGun6.transform.rotation);
                    timerGattlingGun = timeDurationGattlingGun;
                    randomShotGattlingGun = Random.Range(1, 10);
                }
                else if (randomShotGattlingGun == 8)
                {
                    aus.PlayOneShot(soundGattlingGun);
                    Instantiate(projectilePrefabs, posGattlingGun7.transform.position, posGattlingGun7.transform.rotation);
                    Instantiate(firePrefabs, posGattlingGun7.transform.position, posGattlingGun7.transform.rotation);
                    timerGattlingGun = timeDurationGattlingGun;
                    randomShotGattlingGun = Random.Range(1, 10);
                }
                else
                {
                    aus.PlayOneShot(soundGattlingGun);
                    Instantiate(projectilePrefabs, posGattlingGun8.transform.position, posGattlingGun8.transform.rotation);
                    Instantiate(firePrefabs, posGattlingGun8.transform.position, posGattlingGun8.transform.rotation);
                    timerGattlingGun = timeDurationGattlingGun;
                    randomShotGattlingGun = Random.Range(1, 10);
                }
            }
        }
    }
}
