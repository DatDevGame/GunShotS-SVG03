using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionPlayer : MonoBehaviour
{
    public static MissionPlayer ins;

    //General
    public GameObject btnMission;
    public GameObject showMissionTable;
    public bool TableMissionShowing;


    //Mission 0 - Map 1
    public GameObject Mission0;
    public GameObject btnMission0;
    public bool checkClickBtnMission0;

    //Mission 1 - Map 1
    public Text Mission1;
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
        showMissionTable.SetActive(false);
    }
    protected virtual void Update()
    {
        //General
        btnShowMission1FalseKeyboard();

        //Mission 0 - Map 1

        //Mission 1 - Map 1
        showBtnRewardMission1();
    }


    //Set Table Mission==================================
    public virtual void btnShowMission1True()
    {
        //Bag showing not open Mission
        if (UIManager.ins.checkShowPanelBag) return;

        TableMissionShowing = true;
        showMissionTable.SetActive(true);
        Mouse.ins.checkMission1 = true;
        Time.timeScale = 0f;
    }
    public virtual void btnShowMission1False()
    {
        TableMissionShowing = false;
        Mouse.ins.checkMission1 = false;
        showMissionTable.SetActive(false);
        Time.timeScale = 1f;
    }
    public virtual void btnShowMission1FalseKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Mouse.ins.checkMission1)
        {
            //Bag showing not open Mission
            if (UIManager.ins.checkShowPanelBag) return;

            TableMissionShowing = false;
            Mouse.ins.checkMission1 = false;
            showMissionTable.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    //====================Mission==========================
    #region Mission 0 - Map 1
    public virtual void btnGetRewardMission0()
    {
        //Reward Mission 0 - Disable Mission 0 and Show Mission 1
        StatusPlayer.ins.Cristal += 5;
        UIManager.ins.setCristalText(""+ StatusPlayer.ins.Cristal);
        Mouse.ins.checkMission1 = true;
        Mission0.SetActive(false);
        checkClickBtnMission0 = true;
        //Show Mission 1
        Mission1Close.SetActive(true);
    }
    #endregion

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
        Mouse.ins.checkMission1 = true;
        checkQuantilyCrabDead = 0;
        Mission1Close.SetActive(false);
        StatusPlayer.ins.Cristal += 20;
        UIManager.ins.setCristalText(""+StatusPlayer.ins.Cristal);
    }
    protected virtual void showBtnRewardMission1()
    {
        if (checkQuantilyCrabDead >= 500)
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
