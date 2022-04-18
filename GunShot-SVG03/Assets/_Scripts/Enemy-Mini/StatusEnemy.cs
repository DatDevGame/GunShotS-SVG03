using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEnemy : MonoBehaviour
{
    public static StatusEnemy ins;
    public Animator anim;

    protected virtual void Start()
    {
        ins = this;
        anim = GetComponent<Animator>();
    }
}
