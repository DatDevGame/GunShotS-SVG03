using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    protected float timeLoading;
    public Slider LoadingSlider;

    protected int randomTime;


    public GameObject showPlayer;

    protected virtual void Awake()
    {
        randomTime = Random.Range(1, 4);
        Debug.Log(randomTime);
        showPlayer = GameObject.Find("====General====");
    }
    protected virtual void Start()
    {
        timeLoading = 0f;
        if (randomTime == 1)
        {
            LoadingSlider.maxValue = 7f;
            LoadingSlider.value = timeLoading;
        }
        else if (randomTime == 2)
        {
            LoadingSlider.maxValue = 5f;
            LoadingSlider.value = timeLoading;
        }
        else if (randomTime == 3)
        {
            LoadingSlider.maxValue = 3f;
            LoadingSlider.value = timeLoading;
        }
        
    }

    protected virtual void Update()
    {
        if (randomTime == 1)
        {
            timeLoading += Time.deltaTime;
            LoadingSlider.value = timeLoading;
            if (timeLoading >= 7f)
            {
                SceneManager.LoadScene("Map-1");
                showPlayer.SetActive(true);
            }
        }
        else if (randomTime == 2)
        {
            timeLoading += Time.deltaTime;
            LoadingSlider.value = timeLoading;
            if (timeLoading >= 5f)
            {
                SceneManager.LoadScene("Map-1");
                showPlayer.SetActive(true);
            }
        }
        else if (randomTime == 3)
        {
            timeLoading += Time.deltaTime;
            LoadingSlider.value = timeLoading;
            if (timeLoading >= 3f)
            {
                SceneManager.LoadScene("Map-1");
                showPlayer.SetActive(true);
            }
        }
       
    }
}
