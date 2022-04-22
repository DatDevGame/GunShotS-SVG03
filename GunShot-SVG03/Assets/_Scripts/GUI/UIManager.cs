using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //Bag Player
    public GameObject PanelBagPlayer;
    protected bool checkShowPanelBag;
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


}
