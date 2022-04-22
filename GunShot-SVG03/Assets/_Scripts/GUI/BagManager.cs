using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    //Set Btn Buy
    public GameObject btnBuyPistol;
    public GameObject btnBuyGlock;
    public GameObject btnBuyFlame;
    public GameObject btnBuyLazer;
    public GameObject btnBuyRocket;
    //Set Btn Use
    public GameObject btnUsePistol;
    public GameObject btnUseGlock;
    public GameObject btnUseFlame;
    public GameObject btnUseLazer;
    public GameObject btnUseRocket;
    protected bool PistolBought;
    protected bool GlockBought;
    protected bool FlameBought;
    protected bool LazerBought;
    protected bool RocketBought;

    //Hiden Text Coin
    public GameObject textCoinPistol;
    public GameObject textCoinGlock;
    public GameObject textCoinFlame;
    public GameObject textCoinLazer;
    public GameObject textCoinRocket;

    //Set Active Gun
    public GameObject Pistol;
    public GameObject Glock;
    public GameObject FlameThrower;
    public GameObject Lazer;
    public GameObject Rocket;

    //Show Sound Not Buy Gun
    AudioSource aus;
    public AudioClip soundNotMoney;
    public AudioClip soundBoughtGun;

    private void Awake()
    {
        aus = GetComponent<AudioSource>();
    }
    protected virtual void Start()
    {
        btnUsePistol.SetActive(false);
        btnUseGlock.SetActive(false);
        btnUseFlame.SetActive(false);
        btnUseLazer.SetActive(false);
        btnUseRocket.SetActive(false);
    }
    //Set Button Buy GUI Bag Player
    public virtual void btnPistol()
    {
        if (StatusPlayer.ins.coin >= 0)
        {
            aus.PlayOneShot(soundBoughtGun);
            textCoinPistol.SetActive(false);
            PistolBought = true;
            btnBuyPistol.SetActive(false);
            btnUsePistol.SetActive(true);
        }
        else 
        {
            aus.PlayOneShot(soundNotMoney);
        }
    }
    public virtual void btnGlock()
    {
        if (StatusPlayer.ins.coin >= 50)
        {
            StatusPlayer.ins.coin -= 50;
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
        if (StatusPlayer.ins.coin >= 100)
        {
            StatusPlayer.ins.coin -= 100;
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
        if (StatusPlayer.ins.coin >= 200)
        {
            StatusPlayer.ins.coin -= 200;
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
        if (StatusPlayer.ins.coin >= 500)
        {
            StatusPlayer.ins.coin -= 500;
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

    //Set Button Use GUI Bag Player

    public virtual void UseBtnPistol()
    {
        //Set hiden Btn When Use
        btnUsePistol.SetActive(false);
        if(GlockBought) btnUseGlock.SetActive(true);
        if(FlameBought) btnUseFlame.SetActive(true);
        if(LazerBought) btnUseLazer.SetActive(true);
        if(RocketBought) btnUseRocket.SetActive(true);

        //Set Active Gun
        Pistol.SetActive(true);
        Glock.SetActive(false);
        FlameThrower.SetActive(false);
        Lazer.SetActive(false);
        Rocket.SetActive(false);

        //Set Gun For Player Use
        PlayerShot.ins.Pistol = true;
        PlayerShot.ins.Glock = false;
        PlayerShot.ins.Flame = false;
        PlayerShot.ins.MachineGun = false;
        PlayerShot.ins.Rocket = false;
    }

    public virtual void UseBtnGlock()
    {
        //Set hiden Btn When Use
        if (PistolBought) btnUsePistol.SetActive(true);
        btnUseGlock.SetActive(false);
        if (FlameBought) btnUseFlame.SetActive(true);
        if (LazerBought) btnUseLazer.SetActive(true);
        if (RocketBought) btnUseRocket.SetActive(true);

        //Set Active Gun
        Pistol.SetActive(false);
        Glock.SetActive(true);
        FlameThrower.SetActive(false);
        Lazer.SetActive(false);
        Rocket.SetActive(false);

        //Set Gun For Player Use
        PlayerShot.ins.Pistol = false;
        PlayerShot.ins.Glock = true;
        PlayerShot.ins.Flame = false;
        PlayerShot.ins.MachineGun = false;
        PlayerShot.ins.Rocket = false;
    }

    public virtual void UseBtnFlame()
    {
        //Set hiden Btn When Use
        if (PistolBought) btnUsePistol.SetActive(true);
        if (GlockBought) btnUseGlock.SetActive(true);
        btnUseFlame.SetActive(false);
        if (LazerBought) btnUseLazer.SetActive(true);
        if (RocketBought) btnUseRocket.SetActive(true);

        //Set Active Gun
        Pistol.SetActive(false);
        Glock.SetActive(false);
        FlameThrower.SetActive(true);
        Lazer.SetActive(false);
        Rocket.SetActive(false);

        //Set Gun For Player Use
        PlayerShot.ins.Pistol = false;
        PlayerShot.ins.Glock = false;
        PlayerShot.ins.Flame = true;
        PlayerShot.ins.MachineGun = false;
        PlayerShot.ins.Rocket = false;
    }

    public virtual void UseBtnLazer()
    {
        //Set hiden Btn When Use
        if (PistolBought) btnUsePistol.SetActive(true);
        if (GlockBought) btnUseGlock.SetActive(true);
        if (FlameBought) btnUseFlame.SetActive(true);
        btnUseLazer.SetActive(false);
        if (RocketBought) btnUseRocket.SetActive(true);

        //Set Active Gun
        Pistol.SetActive(false);
        Glock.SetActive(false);
        FlameThrower.SetActive(false);
        Lazer.SetActive(true);
        Rocket.SetActive(false);

        //Set Gun For Player Use
        PlayerShot.ins.Pistol = false;
        PlayerShot.ins.Glock = false;
        PlayerShot.ins.Flame = false;
        PlayerShot.ins.MachineGun = true;
        PlayerShot.ins.Rocket = false;
    }

    public virtual void UseBtnRocket()
    {
        //Set hiden Btn When Use
        if (PistolBought) btnUsePistol.SetActive(true);
        if (GlockBought) btnUseGlock.SetActive(true);
        if (FlameBought) btnUseFlame.SetActive(true);
        if (LazerBought) btnUseLazer.SetActive(true);
        btnUseRocket.SetActive(false);

        //Set Active Gun
        Pistol.SetActive(false);
        Glock.SetActive(false);
        FlameThrower.SetActive(false);
        Lazer.SetActive(false);
        Rocket.SetActive(true);

        //Set Gun For Player Use
        PlayerShot.ins.Pistol = false;
        PlayerShot.ins.Glock = false;
        PlayerShot.ins.Flame = false;
        PlayerShot.ins.MachineGun = false;
        PlayerShot.ins.Rocket = true;
    }
}
