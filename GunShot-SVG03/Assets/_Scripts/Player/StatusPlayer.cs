using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPlayer : MonoBehaviour
{
    public static StatusPlayer ins;

    //Health Player
    [SerializeField] public int currentHealth;
    [SerializeField] private int maxHealth;
    //Status Item
    public int coin;

    protected virtual void Start()
    {
        //SingleTon
        ins = this;

        //Status Player
        maxHealth = 100;
        currentHealth = maxHealth;

        //Status Item
        coin = 100;

    }

    public void ReveiDame(int dame)
    {
        currentHealth -= dame;
        if (currentHealth <= 0)
        {
            playerDead();
        }
    }

    protected virtual void playerDead()
    {
        Destroy(gameObject);
    }
}
