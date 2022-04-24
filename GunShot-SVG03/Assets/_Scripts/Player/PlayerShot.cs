using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShot : MonoBehaviour
{
    public static PlayerShot ins;

    AudioSource aus;
    public AudioClip soundPistol;
    public AudioClip soundGlock;
    public AudioClip soundFlame;
    public AudioClip soundMachineGun;
    public AudioClip soundRocket;

    public GameObject projectilePrefabs;
    public GameObject projectileLazerPrefabs;
    public GameObject projectileRocketPrefabs;
    public GameObject firePrefabs;

    //Get Pos Head Gun
    public GameObject posGun;
    public bool Pistol;
    public GameObject posGlock;
    public bool Glock;
    public GameObject posFlame;
    public bool Flame;
    public GameObject posMachineGun;
    public bool MachineGun;
    public GameObject posRocket;
    public bool Rocket;

    //time Shot Pistrol
    private float timerPistrol;
    public float timeDurationPistrol;

    //time Shot Pistrol
    private float timerGlock;
    public float timeDurationGlock;

    //time Shot Flame
    private float timerFlame;
    public float timeDurationFlame;

    //time Shot MachineGun
    private float timerMachineGun;
    public float timeDurationMachineGun;

    //time Shot MachineGun
    private float timerRocket;
    public float timeDurationRocket;
    public Text timeItemSpeedUp;
    public GameObject showTimeItem;


    //Set Time Item live
    protected float timeEndItem;
    protected bool checkTimeEndItem;


    private void Awake()
    {
        ins = this;
        aus = GetComponent<AudioSource>();
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

        //time Shot Flame
        timeDurationFlame = 0.05f;
        timerFlame = timeDurationFlame;

        //time Shot MachineGun
        timeDurationMachineGun = 0.15f;
        timerMachineGun = timeDurationMachineGun;

        //time Shot Rocket
        timeDurationRocket = 0.4f;
        timerRocket = timeDurationRocket;
    }
    protected virtual void Update()
    {
        posGun = GameObject.Find("posGun");
        posGlock = GameObject.Find("posGlock");
        posFlame = GameObject.Find("posFlame");
        posMachineGun = GameObject.Find("posMachineGun");
        posRocket = GameObject.Find("posRocket");

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
            timeItemSpeedUp.text = "" + timeEndItem;
            Debug.Log(timeEndItem);
            if (timeEndItem <= 0)
            {
                timeDurationPistrol = 0.2f;
                timeDurationGlock = 0.1f;
                timeDurationFlame = 0.05f;
                timeDurationMachineGun = 0.15f;
                timeDurationRocket = 0.4f;
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
                aus.PlayOneShot(soundGlock);
                Instantiate(firePrefabs, posGlock.transform.position, posGlock.transform.rotation);
                Instantiate(projectilePrefabs, posGlock.transform.position, posGlock.transform.rotation);
                timerGlock = timeDurationGlock;
            }
        }

        //Gun Flame
        if (Input.GetMouseButton(0) && Flame)
        {
            timerFlame -= Time.deltaTime;
            if (timerFlame <= 0)
            {
                aus.PlayOneShot(soundFlame);
                Instantiate(firePrefabs, posFlame.transform.position, posFlame.transform.rotation);
                Instantiate(projectilePrefabs, posFlame.transform.position, posFlame.transform.rotation);
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
    }
}
