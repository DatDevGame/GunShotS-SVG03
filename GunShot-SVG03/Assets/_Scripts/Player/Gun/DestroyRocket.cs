using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRocket : MonoBehaviour
{
    protected virtual void Start()
    {
        Destroy(gameObject, 1f);
    }
}
