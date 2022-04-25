using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public static Mouse ins;
    //Mission 1 - Map-1
    [SerializeField]private float radius;
    public LayerMask layer;
    public bool checkMission1;
    public GameObject target;
    protected float distance;
    private void Awake()
    {
        ins = this;
        target = GameObject.Find("Player");
    }
    protected virtual void Start()
    {
       
    }
    protected virtual void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CheckMission();
    }


    protected virtual void CheckMission()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        RaycastHit2D check = Physics2D.CircleCast(transform.position, radius, Vector2.left, layer);
        if (Input.GetMouseButtonDown(0))
        {
            if (check.collider != null)
            {
                if (check.collider.tag == "Mission1")
                {
                    if (distance <= 0.5f)
                    {
                        checkMission1 = true;
                        MissionPlayer.ins.btnMission1.SetActive(true);
                        MissionPlayer.ins.showMission1.SetActive(true);
                        GameController.ins.effectMission.SetActive(false);
                        Time.timeScale = 0f;
                    }     
                }
            }
            else if(check.collider == null)
            {
                Debug.Log("Check Mission false");
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }



}
