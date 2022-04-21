using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExlosion : MonoBehaviour
{
    protected virtual void Start()
    {
        Destroy(gameObject, 0.2f);
    }
}
