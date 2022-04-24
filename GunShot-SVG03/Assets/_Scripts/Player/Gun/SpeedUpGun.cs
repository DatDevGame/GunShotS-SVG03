using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpGun : MonoBehaviour
{
    
    protected virtual void Start()
    {
        Destroy(gameObject, 30f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(PlayerShot.ins.Pistol)
            {
                PlayerShot.ins.timeDurationPistrol = 0.05f;
            }
            else if (PlayerShot.ins.Glock)
            {
                PlayerShot.ins.timeDurationGlock = 0.03f;
            }
            else if (PlayerShot.ins.Flame)
            {
                PlayerShot.ins.timeDurationFlame = 0.01f;
            }
            else if (PlayerShot.ins.MachineGun)
            {
                PlayerShot.ins.timeDurationMachineGun = 0.1f;
            }
            else if (PlayerShot.ins.Rocket)
            {
                PlayerShot.ins.timeDurationRocket = 0.20f;
            }
            Destroy(gameObject);
        }
    }
}
