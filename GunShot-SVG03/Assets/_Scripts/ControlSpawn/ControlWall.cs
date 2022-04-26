using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWall : MonoBehaviour
{
    protected virtual void Update()
    {
        DisableWall();
    }
    protected virtual void DisableWall()
    {
        if (MissionPlayer.ins.checkClickBtnMission0)
        {
            Destroy(gameObject, 2f);
        }
    }
}
