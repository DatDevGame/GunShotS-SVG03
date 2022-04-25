using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionPlayer : MonoBehaviour
{
    public static MissionPlayer ins;

    public Text Mission1;
    public GameObject btnMission1;
    public GameObject showMission1;


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
    }
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
}
