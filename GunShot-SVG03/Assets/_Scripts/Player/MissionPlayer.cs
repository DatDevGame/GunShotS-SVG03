using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionPlayer : MonoBehaviour
{
    public static MissionPlayer ins;

    //Mission 1 - Map 1
    public Text Mission1;
    public GameObject btnMission1;
    public GameObject showMission1;
    public Text setTextMission1;
    public int checkQuantilyCrabDead;
    public GameObject CheckbtnRewardMission1;
    public GameObject Mission1Close;


    private void Awake()
    {
        ins = this;
    }
    protected virtual void Start()
    {
        showMission1.SetActive(false);
    }
    protected virtual void Update()
    {
        btnShowMission1FalseKeyboard();


        //Mission 1 - Map 1
        showBtnRewardMission1();
    }


    //Set Table Mission==================================
    public virtual void btnShowMission1True()
    {
        showMission1.SetActive(true);
        Mouse.ins.checkMission1 = true;
        Time.timeScale = 0f;
    }
    public virtual void btnShowMission1False()
    {
        Mouse.ins.checkMission1 = false;
        showMission1.SetActive(false);
        Time.timeScale = 1f;
    }
    public virtual void btnShowMission1FalseKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Mouse.ins.checkMission1)
        {
            Mouse.ins.checkMission1 = false;
            showMission1.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    //====================Mission==========================
    #region Mission 1 - Map 1
    public virtual void TextMission1(string txt)
    {
        if (setTextMission1)
        {
            setTextMission1.text = txt;
        }
    }
    public virtual void btnGetRewardMission1()
    {
        checkQuantilyCrabDead = 0;
        Mission1Close.SetActive(false);
        StatusPlayer.ins.Cristal += 20;
        UIManager.ins.setCristalText(""+StatusPlayer.ins.Cristal);
    }
    protected virtual void showBtnRewardMission1()
    {
        if (checkQuantilyCrabDead >= 300)
        {
            CheckbtnRewardMission1.SetActive(true);
        }
        else
        {
            CheckbtnRewardMission1.SetActive(false);
        }
    }
    #endregion
}
