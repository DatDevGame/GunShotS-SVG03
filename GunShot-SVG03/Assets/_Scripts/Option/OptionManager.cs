using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public GameObject showChosenMap;
    public GameObject showTutorial;
    public GameObject btnPlayer;
    public GameObject btnTutorial;

    public GameObject showPlayer;

    private void Awake()
    {
        showPlayer = GameObject.Find("====General====");
    }
    protected virtual void Start()
    {
        showChosenMap.SetActive(false);
        showTutorial.SetActive(false);
        btnPlayer.SetActive(true);
        btnTutorial.SetActive(true);
        showPlayer.SetActive(false);
    }

    public virtual void btnPlayGame()
    {
        showChosenMap.SetActive(true);
        btnPlayer.SetActive(false);
        btnTutorial.SetActive(false);
    }
    public virtual void closeChosenMap()
    {
        showChosenMap.SetActive(false);
        btnPlayer.SetActive(true);
        btnTutorial.SetActive(true);
    }


    public virtual void btnShowTutorial()
    {
        showTutorial.SetActive(true);
        btnPlayer.SetActive(false);
        btnTutorial.SetActive(false);
    }
    public virtual void closeTutorial()
    {
        showTutorial.SetActive(false);
        btnPlayer.SetActive(true);
        btnTutorial.SetActive(true);
    }



    //Btn map
    public virtual void btnMap1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LoadingScene");
    }
}
