using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEnemy : MonoBehaviour
{
    public static StatusEnemy ins;

    Animator anim;
    UIManager ui;

    public int currentHealth;
    protected int maxHealth;
    //Spawn Coin
    public GameObject coinPrefabs;
    protected int randomCoinSpawn;
    protected float randXposCoin;
    protected float randYposCoin;
    //Spawn Cristal
    public GameObject CristalPrefabs;
    protected int randCristal;

    //Set CheckQuantilyCrab for MissionPlayer


    private void Awake()
    {
        ins = this;
        anim = GetComponent<Animator>();
        ui = FindObjectOfType<UIManager>();
    }
    protected virtual void Start()
    {
        //Random CrisTal 5/100%
        randCristal = Random.Range(1, 100);
        #region RanDomCoin
        //random Coin
        randomCoinSpawn = Random.Range(1, 5);
        #endregion

        if (this.gameObject.tag == "Crab")
        {
            maxHealth = 10;
            currentHealth = maxHealth;
        }
        if (this.gameObject.tag == "Bat")
        {
            maxHealth = 5;
            currentHealth = maxHealth;
        }
        if (this.gameObject.tag == "Golem")
        {
            maxHealth = 200;
            currentHealth = maxHealth;
        }
        if (this.gameObject.tag == "Rat")
        {
            maxHealth = 100;
            currentHealth = maxHealth;
        }
        if (this.gameObject.tag == "GolemUp")
        {
            maxHealth = 1000;
            currentHealth = maxHealth;
        }
        if (this.gameObject.tag == "Slime")
        {
            maxHealth = 200;
            currentHealth = maxHealth;
        }
    }
    protected virtual void Update()
    {
    }

    public virtual void receiveDame(int dame)
    {
        currentHealth -= dame;
        if (currentHealth <= 0)
        {
            dead();
        }
    }

    protected virtual void dead()
    {
        if (this.gameObject.tag == "Crab")
        {
            //Check Mission 1  - Map 1
            MissionPlayer.ins.checkQuantilyCrabDead += 1;
            MissionPlayer.ins.CheckQuantiylyCrabMission2 += 1;
            MissionPlayer.ins.CheckQuantiylyBatMission2 += 1;
            MissionPlayer.ins.TextMission1(""+ MissionPlayer.ins.checkQuantilyCrabDead);
            MissionPlayer.ins.TextMission2QuantilyCrab(""+ MissionPlayer.ins.CheckQuantiylyCrabMission2);
            MissionPlayer.ins.TextMission2QuantilyBat(""+ MissionPlayer.ins.CheckQuantiylyBatMission2);


            StatusPlayer.ins.Score += 1;
            ui.setScoreText("Score: " + StatusPlayer.ins.Score);
            spawnCoinCrab();
            spawnCristal();
            anim.SetBool("CrabDead", true);
            Destroy(gameObject, 3f);
        }
        if (this.gameObject.tag == "Bat")
        {
            StatusPlayer.ins.Score += 2;
            ui.setScoreText("Score: " + StatusPlayer.ins.Score);
            spawnCoinBat();
            spawnCristal();
            anim.SetBool("BatDead", true);
            Destroy(gameObject, 3f);
        }
        if (this.gameObject.tag == "Rat")
        {
            StatusPlayer.ins.Score += 3;
            ui.setScoreText("Score: " + StatusPlayer.ins.Score);
            spawnCoinRat();
            spawnCristal();
            anim.SetBool("RatDead", true);
            Destroy(gameObject, 3f);
        }
        if (this.gameObject.tag == "Golem")
        {
            StatusPlayer.ins.Score += 4;
            ui.setScoreText("Score: " + StatusPlayer.ins.Score);
            spawnCoinGolem();
            spawnCristal();
            anim.SetBool("GolemDead", true);
            Destroy(gameObject, 3f);
        }
        if (this.gameObject.tag == "GolemUp")
        {
            StatusPlayer.ins.Score += 20;
            ui.setScoreText("Score: "+ StatusPlayer.ins.Score);
            spawnCoinGolemUp();
            anim.SetBool("GolemUpDead", true);
            Destroy(gameObject, 3f);

            Instantiate(CristalPrefabs, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Instantiate(CristalPrefabs, new Vector2(transform.position.x + 1f, transform.position.y + 1f), Quaternion.identity);
            Instantiate(CristalPrefabs, new Vector2(transform.position.x - 1f, transform.position.y + 1f), Quaternion.identity);
            Instantiate(CristalPrefabs, new Vector2(transform.position.x + 1f, transform.position.y - 1f), Quaternion.identity);
            Instantiate(CristalPrefabs, new Vector2(transform.position.x - 1f, transform.position.y - 1f), Quaternion.identity);
            Instantiate(CristalPrefabs, new Vector2(transform.position.x + 2f, transform.position.y + 2f), Quaternion.identity);
            Instantiate(CristalPrefabs, new Vector2(transform.position.x + 2f, transform.position.y - 2f), Quaternion.identity);
            Instantiate(CristalPrefabs, new Vector2(transform.position.x - 2f, transform.position.y + 2f), Quaternion.identity);
            Instantiate(CristalPrefabs, new Vector2(transform.position.x - 2f, transform.position.y - 2f), Quaternion.identity);
            Instantiate(CristalPrefabs, new Vector2(transform.position.x + 2.3f, transform.position.y - 2.3f), Quaternion.identity);
        }
        if (this.gameObject.tag == "Slime")
        {
            anim.SetBool("SlimeDead", true);
            Destroy(gameObject, 3f);
        }
        GetComponent<Collider2D>().enabled = false;
    }
    public virtual void spawnCoinCrab()
    {
        #region Random Pos
        float randX = Random.Range(-1f, 1f);
        float randY = Random.Range(-1f, 1f);
        float randX2 = Random.Range(-1f, 1f);
        float randY2 = Random.Range(-1f, 1f);
        float randX3 = Random.Range(-1f, 1f);
        float randY3 = Random.Range(-1f, 1f);
        #endregion
        if (randomCoinSpawn == 1 || randomCoinSpawn == 3)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
        }
        else if (randomCoinSpawn == 2 || randomCoinSpawn == 5)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
        }
        else if (randomCoinSpawn == 4)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
        }
    }
    public virtual void spawnCoinBat()
    {
        #region Random Pos
        float randX = Random.Range(-1f, 1f);
        float randY = Random.Range(-1f, 1f);
        float randX2 = Random.Range(-1f, 1f);
        float randY2 = Random.Range(-1f, 1f);
        float randX3 = Random.Range(-1f, 1f);
        float randY3 = Random.Range(-1f, 1f);
        float randX4 = Random.Range(-1f, 1f);
        float randY4 = Random.Range(-1f, 1f);
        #endregion
        if (randomCoinSpawn == 1 || randomCoinSpawn == 3)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
        }
        else if (randomCoinSpawn == 2 || randomCoinSpawn == 5)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
        }
        else if (randomCoinSpawn == 4)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
        }
    }
    public virtual void spawnCoinRat()
    {
        #region Random Pos
        float randX = Random.Range(-1f, 1f);
        float randY = Random.Range(-1f, 1f);
        float randX2 = Random.Range(-1f, 1f);
        float randY2 = Random.Range(-1f, 1f);
        float randX3 = Random.Range(-1f, 1f);
        float randY3 = Random.Range(-1f, 1f);
        float randX4 = Random.Range(-1f, 1f);
        float randY4 = Random.Range(-1f, 1f);
        float randX5 = Random.Range(-1f, 1f);
        float randY5 = Random.Range(-1f, 1f);
        float randX6 = Random.Range(-1f, 1f);
        float randY6 = Random.Range(-1f, 1f);
        float randX7 = Random.Range(-1f, 1f);
        float randY7 = Random.Range(-1f, 1f);
        #endregion

        if (randomCoinSpawn == 1)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
        }
        else if (randomCoinSpawn == 2)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randY4), Quaternion.identity);
        }
        else if (randomCoinSpawn == 3)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX5, transform.position.y + randX5), Quaternion.identity);
        }
        else if (randomCoinSpawn == 4)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX5, transform.position.y + randX5), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX6, transform.position.y + randX6), Quaternion.identity);
        }
        else if (randomCoinSpawn == 5)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX5, transform.position.y + randX5), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX6, transform.position.y + randX6), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX7, transform.position.y + randX7), Quaternion.identity);
        }
    }
    public virtual void spawnCoinGolem()
    {
        #region Random Pos
        float randX = Random.Range(-1f, 1f);
        float randY = Random.Range(-1f, 1f);
        float randX2 = Random.Range(-1f, 1f);
        float randY2 = Random.Range(-1f, 1f);
        float randX3 = Random.Range(-1f, 1f);
        float randY3 = Random.Range(-1f, 1f);
        float randX4 = Random.Range(-1f, 1f);
        float randY4 = Random.Range(-1f, 1f);
        float randX5 = Random.Range(-1f, 1f);
        float randY5 = Random.Range(-1f, 1f);
        float randX6 = Random.Range(-1f, 1f);
        float randY6 = Random.Range(-1f, 1f);
        float randX7 = Random.Range(-1f, 1f);
        float randY7 = Random.Range(-1f, 1f);
        float randX8 = Random.Range(-1f, 1f);
        float randY8 = Random.Range(-1f, 1f);
        #endregion

        if (randomCoinSpawn == 1)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
        }
        else if (randomCoinSpawn == 2)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX5, transform.position.y + randX5), Quaternion.identity);
        }
        else if (randomCoinSpawn == 3)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX5, transform.position.y + randX5), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX6, transform.position.y + randX6), Quaternion.identity);
        }
        else if (randomCoinSpawn == 4)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX5, transform.position.y + randX5), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX6, transform.position.y + randX6), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX7, transform.position.y + randX7), Quaternion.identity);
        }
        else if (randomCoinSpawn == 5)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX5, transform.position.y + randX5), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX6, transform.position.y + randX6), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX7, transform.position.y + randX7), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX8, transform.position.y + randX8), Quaternion.identity);
        }
    }
    public virtual void spawnCoinGolemUp()
    {
        #region Random Pos
        float randX = Random.Range(-3f, 3f);
        float randY = Random.Range(-3f, 3f);
        float randX2 = Random.Range(-3f, 3f);
        float randY2 = Random.Range(-3f, 3f);
        float randX3 = Random.Range(-3f, 3f);
        float randY3 = Random.Range(-3f, 3f);
        float randX4 = Random.Range(-3f, 3f);
        float randY4 = Random.Range(-3f, 3f);
        float randX5 = Random.Range(-3f, 3f);
        float randY5 = Random.Range(-3f, 3f);
        float randX6 = Random.Range(-3f, 3f);
        float randY6 = Random.Range(-3f, 3f);
        float randX7 = Random.Range(-3f, 3f);
        float randY7 = Random.Range(-3f, 3f);
        float randX8 = Random.Range(-3f, 3f);
        float randY8 = Random.Range(-3f, 3f);
        float randX9 = Random.Range(-3f, 3f);
        float randY9 = Random.Range(-3f, 3f);
        float randX10 = Random.Range(-3f, 3f);
        float randY10 = Random.Range(-3f, 3f);
        float randX11 = Random.Range(-3f, 3f);
        float randY11 = Random.Range(-3f, 3f);
        float randX12 = Random.Range(-3f, 3f);
        float randY12 = Random.Range(-3f, 3f);
        float randX13 = Random.Range(-3f, 3f);
        float randY13 = Random.Range(-3f, 3f);
        float randX14 = Random.Range(-3f, 3f);
        float randY14 = Random.Range(-3f, 3f);
        float randX15 = Random.Range(-3f, 3f);
        float randY15 = Random.Range(-3f, 3f);
        float randX16 = Random.Range(-3f, 3f);
        float randY16 = Random.Range(-3f, 3f);
        float randX17 = Random.Range(-3f, 3f);
        float randY17 = Random.Range(-3f, 3f);
        float randX18 = Random.Range(-3f, 3f);
        float randY18 = Random.Range(-3f, 3f);
        float randX19 = Random.Range(-3f, 3f);
        float randY19 = Random.Range(-3f, 3f);
        float randX20 = Random.Range(-3f, 3f);
        float randY20 = Random.Range(-3f, 3f);
        float randX21 = Random.Range(-3f, 3f);
        float randY21 = Random.Range(-3f, 3f);
        float randX22 = Random.Range(-3f, 3f);
        float randY22 = Random.Range(-3f, 3f);
        float randX23 = Random.Range(-3f, 3f);
        float randY23 = Random.Range(-3f, 3f);
        float randX24 = Random.Range(-3f, 3f);
        float randY24 = Random.Range(-3f, 3f);
        float randX25 = Random.Range(-3f, 3f);
        float randY25 = Random.Range(-3f, 3f);
        float randX26 = Random.Range(-3f, 3f);
        float randY26 = Random.Range(-3f, 3f);
        float randX27 = Random.Range(-3f, 3f);
        float randY27 = Random.Range(-3f, 3f);
        float randX28 = Random.Range(-3f, 3f);
        float randY28 = Random.Range(-3f, 3f);
        float randX29 = Random.Range(-3f, 3f);
        float randY29 = Random.Range(-3f, 3f);
        float randX30 = Random.Range(-3f, 3f);
        float randY30 = Random.Range(-3f, 3f);
        float randX31 = Random.Range(-3f, 3f);
        float randY31 = Random.Range(-3f, 3f);
        float randX32 = Random.Range(-3f, 3f);
        float randY32 = Random.Range(-3f, 3f);
        float randX33 = Random.Range(-3f, 3f);
        float randY33 = Random.Range(-3f, 3f);
        float randX34 = Random.Range(-3f, 3f);
        float randY34 = Random.Range(-3f, 3f);
        float randX35 = Random.Range(-3f, 3f);
        float randY35 = Random.Range(-3f, 3f);
        float randX36 = Random.Range(-3f, 3f);
        float randY36 = Random.Range(-3f, 3f);
        float randX37 = Random.Range(-3f, 3f);
        float randY37 = Random.Range(-3f, 3f);
        float randX38 = Random.Range(-3f, 3f);
        float randY38 = Random.Range(-3f, 3f);
        float randX39 = Random.Range(-3f, 3f);
        float randY39 = Random.Range(-3f, 3f);
        float randX40 = Random.Range(-3f, 3f);
        float randY40 = Random.Range(-3f, 3f);
        float randX41 = Random.Range(-3f, 3f);
        float randY41 = Random.Range(-3f, 3f);
        float randX42 = Random.Range(-3f, 3f);
        float randY42 = Random.Range(-3f, 3f);
        float randX43 = Random.Range(-3f, 3f);
        float randY43 = Random.Range(-3f, 3f);
        float randX44 = Random.Range(-3f, 3f);
        float randY44 = Random.Range(-3f, 3f);
        float randX45 = Random.Range(-3f, 3f);
        float randY45 = Random.Range(-3f, 3f);
        float randX46 = Random.Range(-3f, 3f);
        float randY46 = Random.Range(-3f, 3f);
        float randX47 = Random.Range(-3f, 3f);
        float randY47 = Random.Range(-3f, 3f);
        float randX48 = Random.Range(-3f, 3f);
        float randY48 = Random.Range(-3f, 3f);
        float randX49 = Random.Range(-3f, 3f);
        float randY49 = Random.Range(-3f, 3f);
        float randX50 = Random.Range(-3f, 3f);
        float randY50 = Random.Range(-3f, 3f);
        #endregion


        if (randomCoinSpawn == 1)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX5, transform.position.y + randX5), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX6, transform.position.y + randX6), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX7, transform.position.y + randX7), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX8, transform.position.y + randX8), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX9, transform.position.y + randX9), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX10, transform.position.y + randX10), Quaternion.identity);
        }
        else if (randomCoinSpawn == 2)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX5, transform.position.y + randX5), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX6, transform.position.y + randX6), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX7, transform.position.y + randX7), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX8, transform.position.y + randX8), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX9, transform.position.y + randX9), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX10, transform.position.y + randX10), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX11, transform.position.y + randY11), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX12, transform.position.y + randY12), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX13, transform.position.y + randY13), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX14, transform.position.y + randX14), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX15, transform.position.y + randX15), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX16, transform.position.y + randX16), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX17, transform.position.y + randX17), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX18, transform.position.y + randX18), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX19, transform.position.y + randX19), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX20, transform.position.y + randX20), Quaternion.identity);

        }
        else if (randomCoinSpawn == 3)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX5, transform.position.y + randX5), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX6, transform.position.y + randX6), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX7, transform.position.y + randX7), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX8, transform.position.y + randX8), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX9, transform.position.y + randX9), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX10, transform.position.y + randX10), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX11, transform.position.y + randY11), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX12, transform.position.y + randY12), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX13, transform.position.y + randY13), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX14, transform.position.y + randX14), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX15, transform.position.y + randX15), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX16, transform.position.y + randX16), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX17, transform.position.y + randX17), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX18, transform.position.y + randX18), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX19, transform.position.y + randX19), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX20, transform.position.y + randX20), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX21, transform.position.y + randY21), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX22, transform.position.y + randY22), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX23, transform.position.y + randY23), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX24, transform.position.y + randX24), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX25, transform.position.y + randX25), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX26, transform.position.y + randX26), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX27, transform.position.y + randX27), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX28, transform.position.y + randX28), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX29, transform.position.y + randX29), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX30, transform.position.y + randX30), Quaternion.identity);
        }
        else if (randomCoinSpawn == 4)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX5, transform.position.y + randX5), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX6, transform.position.y + randX6), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX7, transform.position.y + randX7), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX8, transform.position.y + randX8), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX9, transform.position.y + randX9), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX10, transform.position.y + randX10), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX11, transform.position.y + randY11), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX12, transform.position.y + randY12), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX13, transform.position.y + randY13), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX14, transform.position.y + randX14), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX15, transform.position.y + randX15), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX16, transform.position.y + randX16), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX17, transform.position.y + randX17), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX18, transform.position.y + randX18), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX19, transform.position.y + randX19), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX20, transform.position.y + randX20), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX21, transform.position.y + randY21), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX22, transform.position.y + randY22), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX23, transform.position.y + randY23), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX24, transform.position.y + randX24), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX25, transform.position.y + randX25), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX26, transform.position.y + randX26), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX27, transform.position.y + randX27), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX28, transform.position.y + randX28), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX29, transform.position.y + randX29), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX30, transform.position.y + randX30), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX31, transform.position.y + randY31), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX32, transform.position.y + randY32), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX33, transform.position.y + randY33), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX34, transform.position.y + randX34), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX35, transform.position.y + randX35), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX36, transform.position.y + randX36), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX37, transform.position.y + randX37), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX38, transform.position.y + randX38), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX39, transform.position.y + randX39), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX40, transform.position.y + randX40), Quaternion.identity);
        }
        else if (randomCoinSpawn == 5)
        {
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX, transform.position.y + randY), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX2, transform.position.y + randY2), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX3, transform.position.y + randY3), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX4, transform.position.y + randX4), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX5, transform.position.y + randX5), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX6, transform.position.y + randX6), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX7, transform.position.y + randX7), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX8, transform.position.y + randX8), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX9, transform.position.y + randX9), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX10, transform.position.y + randX10), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX11, transform.position.y + randY11), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX12, transform.position.y + randY12), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX13, transform.position.y + randY13), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX14, transform.position.y + randX14), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX15, transform.position.y + randX15), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX16, transform.position.y + randX16), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX17, transform.position.y + randX17), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX18, transform.position.y + randX18), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX19, transform.position.y + randX19), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX20, transform.position.y + randX20), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX21, transform.position.y + randY21), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX22, transform.position.y + randY22), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX23, transform.position.y + randY23), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX24, transform.position.y + randX24), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX25, transform.position.y + randX25), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX26, transform.position.y + randX26), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX27, transform.position.y + randX27), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX28, transform.position.y + randX28), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX29, transform.position.y + randX29), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX30, transform.position.y + randX30), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX31, transform.position.y + randY31), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX32, transform.position.y + randY32), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX33, transform.position.y + randY33), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX34, transform.position.y + randX34), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX35, transform.position.y + randX35), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX36, transform.position.y + randX36), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX37, transform.position.y + randX37), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX38, transform.position.y + randX38), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX39, transform.position.y + randX39), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX40, transform.position.y + randX40), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX41, transform.position.y + randY41), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX42, transform.position.y + randY42), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX43, transform.position.y + randY43), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX44, transform.position.y + randX44), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX45, transform.position.y + randX45), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX46, transform.position.y + randX46), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX47, transform.position.y + randX47), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX48, transform.position.y + randX48), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX49, transform.position.y + randX49), Quaternion.identity);
            Instantiate(coinPrefabs, new Vector2(transform.position.x + randX50, transform.position.y + randX50), Quaternion.identity);
        }
    }

    public virtual void spawnCristal()
    {
        if (randCristal <= 5)
        {
            Instantiate(CristalPrefabs, transform.position, Quaternion.identity);
        }
    }
}
