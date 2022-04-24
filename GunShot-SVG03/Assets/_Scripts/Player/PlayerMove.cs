using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator anim;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float directionMove;
    [SerializeField] private float pressHorizontal;
    [SerializeField] private float pressVertical;
    Vector2 vertical = new Vector2();
    private bool facingRight;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        this.pressHorizontal = Input.GetAxis("Horizontal");
        this.pressVertical = Input.GetAxis("Vertical");
        this.vertical.x = pressHorizontal * moveSpeed * Time.deltaTime;
        this.vertical.y = pressVertical * moveSpeed * Time.deltaTime;
        transform.Translate(vertical);
    }
}
