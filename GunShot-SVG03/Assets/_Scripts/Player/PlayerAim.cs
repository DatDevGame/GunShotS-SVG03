using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update


    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        settingGun();
    }

    private void settingGun()
    {
        Vector3 mousePositon = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mousePositon.Normalize();

        float angle = Mathf.Atan2(mousePositon.y, mousePositon.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0f, 0f, angle);

        if (angle <= -90 || angle >= 90)
        {
            transform.eulerAngles = new Vector3(180f, 0f, -angle);
        }

        if (transform.eulerAngles.y == 0)
        {
            player.transform.localScale = new Vector3(-5f, 5f, 5);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (transform.eulerAngles.y == 180 || transform.eulerAngles.y == -180)
        {
            player.transform.localScale = new Vector3(5f, 5f, 5);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

    }
}
