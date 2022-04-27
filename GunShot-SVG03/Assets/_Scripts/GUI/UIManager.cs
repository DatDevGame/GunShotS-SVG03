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

    private void Awake()
    {
        ins = this;
    }
    protected virtual void Start()
    {
        //Bag Player
        PanelBagPlayer.SetActive(false);
        checkShowPanelBag = false;
    }
    protected virtual void Update()
    {
        //Bag Player
        ShowPanelBagPlayerKey();
    }
    #region Btn Show and Close Bag Player
    //Use Button
    public void showPanelBagPlayer()
    {
        //Table Mission showing not open Bag
        if (MissionPlayer.ins.TableMissionShowing) return;

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

    public void loadcene()
    {
        SceneManager.LoadScene("Map-2");
    }
}
