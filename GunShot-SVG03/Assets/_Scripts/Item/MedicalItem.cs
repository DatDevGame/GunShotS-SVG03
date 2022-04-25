using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalItem : MonoBehaviour
{

    public GameObject target;
    UIManager ui;

    protected virtual void Start()
    {
        target = GameObject.Find("Player");
        ui = FindObjectOfType<UIManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StatusPlayer.ins.Medical += 1;
            ui.setMedicalText("X: "+ StatusPlayer.ins.Medical);
            Destroy(gameObject);
        }
    }
}
