using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireGun : MonoBehaviour
{

    float rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(1f, 50f);

        transform.eulerAngles = new Vector3(rand, transform.eulerAngles.y, transform.eulerAngles.z);
        Destroy(gameObject, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
