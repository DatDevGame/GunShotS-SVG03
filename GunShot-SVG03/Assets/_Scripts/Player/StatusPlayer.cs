using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPlayer : MonoBehaviour
{
    public static StatusPlayer ins;

    //Component
    AudioSource aus;
    UIManager ui;

    //Health Player
    [SerializeField] public int currentHealth;
    [SerializeField] private int maxHealth;
    public Slider healthSlider;

    //Status Item - Score
    public int coin;
    public AudioClip soundCoin;
    public int Score;
    public int Cristal;
    public int Medical;

    //Receive Dame Anim
    public GameObject receiveDameAnim;

    private void Awake()
    {
        aus = GetComponent<AudioSource>();
        ui = FindObjectOfType<UIManager>();
    }
    protected virtual void Start()
    {
        transform.localScale = new Vector3(-1f, 1f, 1f);

        //SingleTon
        ins = this;

        //Status Player
        maxHealth = 100;
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

       

        //Set UIManager
        ui.setCoinText("Coin: " + coin);
        ui.setScoreText("Score: " + Score);
        ui.setCristalText("" + Cristal);
        ui.setMedicalText("X: "+Medical);
    }

    public void ReveiDame(int dame)
    {
        currentHealth -= dame;
        healthSlider.value = currentHealth;
        Instantiate(receiveDameAnim, new Vector2(transform.position.x - 0.4f, transform.position.y), Quaternion.identity);
        if (currentHealth <= 0)
        {
            playerDead();
        }
    }
    protected virtual void playerDead()
    {
        Destroy(gameObject);
    }

    //Receive Coin
    public void ReceiveCoin(int Recoin)
    {
        coin += Recoin;
        ui.setCoinText("Coin: " + coin);
        aus.PlayOneShot(soundCoin);
    }
}

