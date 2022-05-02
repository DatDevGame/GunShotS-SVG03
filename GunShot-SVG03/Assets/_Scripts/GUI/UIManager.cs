using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager ins;
    
    //Bag Player
    public GameObject PanelBagPlayer;
    public bool checkShowPanelBag;

    //Item text - Score
    public Text scoreText;
    public Text coinText;
    public Text cristalText;
    public Text timeItemSpeedUp;
    public Text MedicalText;
    public Text SpeedUpText;


    //Menu Player
    public GameObject ShowPanelMenu;
    public Slider volumeSlider;
    public GameObject showVolume;
    protected bool checkMusic;
    public bool checkMenuShow;


    private void Awake()
    {
        ins = this;
    }
    protected virtual void Start()
    {
        //Bag Player
        PanelBagPlayer.SetActive(false);
        checkShowPanelBag = false;

        //menu
        ShowPanelMenu.SetActive(false);
        showVolume.SetActive(false);
        checkMusic = true;
        checkMenuShow = false;
    }
    protected virtual void Update()
    {
        //Bag Player
        ShowPanelBagPlayerKey();

        //Menu - Volume
        setVolumeMusic();

        setMenuKeyboard();
    }
    #region Btn Show and Close Bag Player
    //Use Button
    public void showPanelBagPlayer()
    {
        //Table Mission showing not open Bag
        if (MissionPlayer.ins.TableMissionShowing) return;

        if (checkMenuShow) return;

        checkShowPanelBag = true;
        PanelBagPlayer.SetActive(true);
        Time.timeScale = 0f;
    }
    public void closePanelBagPlayer()
    {
        checkShowPanelBag = false;
        PanelBagPlayer.SetActive(false);
        Time.timeScale = 1f;
    }
    //Use Keyboard
    protected virtual void ShowPanelBagPlayerKey()
    {
        if (checkMenuShow) return;

        if (Input.GetKeyDown(KeyCode.B) && !checkShowPanelBag)
        {
            //Table Mission showing not open Bag
            if (MissionPlayer.ins.TableMissionShowing) return;

            checkShowPanelBag = true;
            PanelBagPlayer.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.B) && checkShowPanelBag)
        {
            checkShowPanelBag = false;
            PanelBagPlayer.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    #endregion

    //Set Item - Score Text
    public virtual void setScoreText(string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt;
        }
    }
    public virtual void setCoinText(string txt)
    {
        if (coinText)
        {
            coinText.text = txt;
        }
    }
    public virtual void setCristalText(string txt)
    {
        if (cristalText)
        {
            cristalText.text = txt;
        }
    }
    public virtual void setMedicalText(string txt)
    {
        if (MedicalText)
        {
            MedicalText.text = txt;
        }
    }
    public virtual void setTimeItemText(string txt)
    {
        if (timeItemSpeedUp)
        {
            timeItemSpeedUp.text = txt;
        }
    }
    public virtual void setItemSpeedText(string txt)
    {
        if (SpeedUpText)
        {
            SpeedUpText.text = txt;
        }
    }

    //Menu Player
    public virtual void showMenu()
    {
        checkMenuShow = true;
        ShowPanelMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public virtual void btnResume()
    {
        checkMenuShow = false;
        ShowPanelMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public virtual void btnOption()
    {
        SceneManager.LoadScene("OptionScene");
        Time.timeScale = 1f;
    }
    public virtual void btnMusic()
    {
        if (checkMusic)
        {
            showVolume.SetActive(true);
            checkMusic = false;
        }
        else 
        {
            showVolume.SetActive(false);
            checkMusic = true;
        }
    }
    public virtual void setVolumeMusic()
    {
        AudioListener.volume = volumeSlider.value;
    }
    public virtual void setMenuKeyboard()
    {
        if (!checkMenuShow && Input.GetKeyDown(KeyCode.Escape))
        {
            checkMenuShow = true;
            ShowPanelMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        else if (checkMenuShow && Input.GetKeyDown(KeyCode.Escape))
        {
            checkMenuShow = false;
            ShowPanelMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
