using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    //Set UIManager
    UIManager ui;

    //Get Pos Player
    public GameObject target;

    //Set Btn Buy
    public GameObject btnBuyPistol;
    public GameObject btnBuyGlock;
    public GameObject btnBuyFlame;
    public GameObject btnBuyLazer;
    public GameObject btnBuyRocket;
    public GameObject btnBuyGattling;
    //Set Btn Use
    public GameObject btnUsePistol;
    public GameObject btnUseGlock;
    public GameObject btnUseFlame;
    public GameObject btnUseLazer;
    public GameObject btnUseRocket;
    public GameObject btnUseGattlingGun;
    protected bool PistolBought;
    protected bool GlockBought;
    protected bool FlameBought;
    protected bool LazerBought;
    protected bool RocketBought;
    protected bool GattlingGunBought;

    //Hiden Text Coin
    public GameObject textCoinPistol;
    public GameObject textCoinGlock;
    public GameObject textCoinFlame;
    public GameObject textCoinLazer;
    public GameObject textCoinRocket;
    public GameObject textCoinGattlingGun;

    //Set Active Gun
    public GameObject Pistol;
    public GameObject Glock;
    public GameObject FlameThrower;
    public GameObject Lazer;
    public GameObject Rocket;
    public GameObject GattlingGun;

    //Show Sound Not Buy Gun
    AudioSource aus;
    public AudioClip soundNotMoney;
    public AudioClip soundBoughtGun;

    //SpeedItem Prefabs When Use
    public GameObject itemSpeedUpPrefabs;
    protected int QuantilyItemSpeedup;


    private void Awake()
    {
        aus = GetComponent<AudioSource>();
        ui = FindObjectOfType<UIManager>();
        target = GameObject.Find("Player");
    }
    protected virtual void Start()
    {
        btnUsePistol.SetActive(false);
        btnUseGlock.SetActive(false);
        btnUseFlame.SetActive(false);
        btnUseLazer.SetActive(false);
        btnUseRocket.SetActive(false);
        btnUseGattlingGun.SetActive(false);
    }
    //Set Button Buy GUI Bag Player
    public virtual void btnPistol()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;


        if (StatusPlayer.ins.coin >= 0)
        {
            aus.PlayOneShot(soundBoughtGun);
            textCoinPistol.SetActive(false);
            PistolBought = true;
            btnBuyPistol.SetActive(false);
            btnUsePistol.SetActive(true);

            //Mission 0 - Map 1
            MissionPlayer.ins.btnMission0.SetActive(true);
        }
        else 
        {
            aus.PlayOneShot(soundNotMoney);
        }
    }
    public virtual void btnGlock()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;


        if (StatusPlayer.ins.coin >= 350)
        {
            StatusPlayer.ins.coin -= 350;
            ui.setCoinText("Coin: " + StatusPlayer.ins.coin);
            aus.PlayOneShot(soundBoughtGun);
            textCoinGlock.SetActive(false);
            GlockBought = true;
            btnBuyGlock.SetActive(false);
            btnUseGlock.SetActive(true);
        }
        else
        {
            aus.PlayOneShot(soundNotMoney);
        }
    }
    public virtual void btnFlame()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;


        if (StatusPlayer.ins.coin >= 100)
        {
            StatusPlayer.ins.coin -= 100;
            ui.setCoinText("Coin: " + StatusPlayer.ins.coin);
            aus.PlayOneShot(soundBoughtGun);
            textCoinFlame.SetActive(false);
            FlameBought = true;
            btnBuyFlame.SetActive(false);
            btnUseFlame.SetActive(true);
            
        }
        else
        {
            aus.PlayOneShot(soundNotMoney);
        }
    }
    public virtual void btnLazer()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;


        if (StatusPlayer.ins.coin >= 200)
        {
            StatusPlayer.ins.coin -= 200;
            ui.setCoinText("Coin: " + StatusPlayer.ins.coin);
            aus.PlayOneShot(soundBoughtGun);
            textCoinLazer.SetActive(false);
            LazerBought = true;
            btnBuyLazer.SetActive(false);
            btnUseLazer.SetActive(true);
        }
        else
        {
            aus.PlayOneShot(soundNotMoney);
        }
    }
    public virtual void btnRocket()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;


        if (StatusPlayer.ins.coin >= 500)
        {
            StatusPlayer.ins.coin -= 500;
            ui.setCoinText("Coin: " + StatusPlayer.ins.coin);
            aus.PlayOneShot(soundBoughtGun);
            textCoinRocket.SetActive(false);
            RocketBought = true;
            btnBuyRocket.SetActive(false);
            btnUseRocket.SetActive(true);
        }
        else
        {
            aus.PlayOneShot(soundNotMoney);
        }
    }

    public virtual void btnGattlingGun()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;

        if (StatusPlayer.ins.coin >= 10000)
        {
            StatusPlayer.ins.coin -= 10000;
            ui.setCoinText("Coin: " + StatusPlayer.ins.coin);
            aus.PlayOneShot(soundBoughtGun);
            textCoinGattlingGun.SetActive(false);
            GattlingGunBought = true;
            btnBuyGattling.SetActive(false);
            btnUseGattlingGun.SetActive(true);
        }
        else
        {
            aus.PlayOneShot(soundNotMoney);
        }
    }

    //Set Button Use GUI Bag Player

    public virtual void UseBtnPistol()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;


        //Set hiden Btn When Use
        btnUsePistol.SetActive(false);
        if(GlockBought) btnUseGlock.SetActive(true);
        if(FlameBought) btnUseFlame.SetActive(true);
        if(LazerBought) btnUseLazer.SetActive(true);
        if(RocketBought) btnUseRocket.SetActive(true);
        if (GattlingGunBought) btnUseGattlingGun.SetActive(true);

        //Set Active Gun
        Pistol.SetActive(true);
        Glock.SetActive(false);
        FlameThrower.SetActive(false);
        Lazer.SetActive(false);
        Rocket.SetActive(false);
        GattlingGun.SetActive(false);

        //Set Gun For Player Use
        PlayerShot.ins.Pistol = true;
        PlayerShot.ins.Glock = false;
        PlayerShot.ins.Flame = false;
        PlayerShot.ins.MachineGun = false;
        PlayerShot.ins.Rocket = false;
        PlayerShot.ins.GattlingGun = false;
    }

    public virtual void UseBtnGlock()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;


        //Set hiden Btn When Use
        if (PistolBought) btnUsePistol.SetActive(true);
        btnUseGlock.SetActive(false);
        if (FlameBought) btnUseFlame.SetActive(true);
        if (LazerBought) btnUseLazer.SetActive(true);
        if (RocketBought) btnUseRocket.SetActive(true);
        if (GattlingGunBought) btnUseGattlingGun.SetActive(true);

        //Set Active Gun
        Pistol.SetActive(false);
        Glock.SetActive(true);
        FlameThrower.SetActive(false);
        Lazer.SetActive(false);
        Rocket.SetActive(false);
        GattlingGun.SetActive(false);

        //Set Gun For Player Use
        PlayerShot.ins.Pistol = false;
        PlayerShot.ins.Glock = true;
        PlayerShot.ins.Flame = false;
        PlayerShot.ins.MachineGun = false;
        PlayerShot.ins.Rocket = false;
        PlayerShot.ins.GattlingGun = false;
    }

    public virtual void UseBtnFlame()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;


        //Set hiden Btn When Use
        if (PistolBought) btnUsePistol.SetActive(true);
        if (GlockBought) btnUseGlock.SetActive(true);
        btnUseFlame.SetActive(false);
        if (LazerBought) btnUseLazer.SetActive(true);
        if (RocketBought) btnUseRocket.SetActive(true);
        if (GattlingGunBought) btnUseGattlingGun.SetActive(true);

        //Set Active Gun
        Pistol.SetActive(false);
        Glock.SetActive(false);
        FlameThrower.SetActive(true);
        Lazer.SetActive(false);
        Rocket.SetActive(false);
        GattlingGun.SetActive(false);

        //Set Gun For Player Use
        PlayerShot.ins.Pistol = false;
        PlayerShot.ins.Glock = false;
        PlayerShot.ins.Flame = true;
        PlayerShot.ins.MachineGun = false;
        PlayerShot.ins.Rocket = false;
        PlayerShot.ins.GattlingGun = false;
    }

    public virtual void UseBtnLazer()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;


        //Set hiden Btn When Use
        if (PistolBought) btnUsePistol.SetActive(true);
        if (GlockBought) btnUseGlock.SetActive(true);
        if (FlameBought) btnUseFlame.SetActive(true);
        btnUseLazer.SetActive(false);
        if (RocketBought) btnUseRocket.SetActive(true);
        if (GattlingGunBought) btnUseGattlingGun.SetActive(true);

        //Set Active Gun
        Pistol.SetActive(false);
        Glock.SetActive(false);
        FlameThrower.SetActive(false);
        Lazer.SetActive(true);
        Rocket.SetActive(false);
        GattlingGun.SetActive(false);

        //Set Gun For Player Use
        PlayerShot.ins.Pistol = false;
        PlayerShot.ins.Glock = false;
        PlayerShot.ins.Flame = false;
        PlayerShot.ins.MachineGun = true;
        PlayerShot.ins.Rocket = false;
        PlayerShot.ins.GattlingGun = false;
    }

    public virtual void UseBtnRocket()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;



        //Set hiden Btn When Use
        if (PistolBought) btnUsePistol.SetActive(true);
        if (GlockBought) btnUseGlock.SetActive(true);
        if (FlameBought) btnUseFlame.SetActive(true);
        if (LazerBought) btnUseLazer.SetActive(true);
        if (GattlingGunBought) btnUseGattlingGun.SetActive(true);
        btnUseRocket.SetActive(false);

        //Set Active Gun
        Pistol.SetActive(false);
        Glock.SetActive(false);
        FlameThrower.SetActive(false);
        Lazer.SetActive(false);
        Rocket.SetActive(true);
        GattlingGun.SetActive(false);

        //Set Gun For Player Use
        PlayerShot.ins.Pistol = false;
        PlayerShot.ins.Glock = false;
        PlayerShot.ins.Flame = false;
        PlayerShot.ins.MachineGun = false;
        PlayerShot.ins.Rocket = true;
        PlayerShot.ins.GattlingGun = false;
    }

    public virtual void UseBtnGattling()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;

        //Set hiden Btn When Use
        if (PistolBought) btnUsePistol.SetActive(true);
        if (GlockBought) btnUseGlock.SetActive(true);
        if (FlameBought) btnUseFlame.SetActive(true);
        if (LazerBought) btnUseLazer.SetActive(true);
        if (RocketBought) btnUseRocket.SetActive(true);
        btnUseGattlingGun.SetActive(false);

        //Set Active Gun
        Pistol.SetActive(false);
        Glock.SetActive(false);
        FlameThrower.SetActive(false);
        Lazer.SetActive(false);
        Rocket.SetActive(false);
        GattlingGun.SetActive(true);

        //Set Gun For Player Use
        PlayerShot.ins.Pistol = false;
        PlayerShot.ins.Glock = false;
        PlayerShot.ins.Flame = false;
        PlayerShot.ins.MachineGun = false;
        PlayerShot.ins.Rocket = false;
        PlayerShot.ins.GattlingGun = true;
    }

    public virtual void BuyBtnMedical()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;

        if (StatusPlayer.ins.Cristal >= 10)
        {
            StatusPlayer.ins.Cristal -= 10;
            StatusPlayer.ins.Medical += 1;
            ui.setMedicalText("X: " + StatusPlayer.ins.Medical);
            ui.setCristalText(" " + StatusPlayer.ins.Cristal);
        }
        else
        {
            aus.PlayOneShot(soundNotMoney);
        }
    }
    public virtual void UseBtnMedical()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;

        if (StatusPlayer.ins.currentHealth >= 100)
        {
            aus.PlayOneShot(soundNotMoney);
            return;
        }

        if (StatusPlayer.ins.Medical >= 1)
        {
            StatusPlayer.ins.Medical -= 1;
            StatusPlayer.ins.currentHealth += 50;
            if (StatusPlayer.ins.currentHealth >= 100)
            {
                StatusPlayer.ins.currentHealth = 100;
            }
            StatusPlayer.ins.healthSlider.value = StatusPlayer.ins.currentHealth;
            ui.setMedicalText("X: " + StatusPlayer.ins.Medical);
        }
        else
        {
            aus.PlayOneShot(soundNotMoney);
        }
    }

    public virtual void UseBtnSpeedUp()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;

        if (QuantilyItemSpeedup >= 1)
        {
            QuantilyItemSpeedup -= 1;
            Instantiate(itemSpeedUpPrefabs, target.transform.position, Quaternion.identity);
            UIManager.ins.setItemSpeedText("X: " + QuantilyItemSpeedup);
        }
        else
        {
            aus.PlayOneShot(soundNotMoney);
        }
    }
    public virtual void BuyBtnSpeedUp()
    {
        if (StatusPlayer.ins.currentHealth <= 0) return;

        if (StatusPlayer.ins.Cristal >= 25)
        {
            StatusPlayer.ins.Cristal -= 25;
            QuantilyItemSpeedup += 1;
            UIManager.ins.setItemSpeedText("X: "+QuantilyItemSpeedup);
            UIManager.ins.setCristalText(""+ StatusPlayer.ins.Cristal);
        }
        else
        {
            aus.PlayOneShot(soundNotMoney);
        }
    }
}
