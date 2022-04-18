using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float directionMove;
    [SerializeField] private float pressHorizontal;
    [SerializeField] private float pressVertical;
    Vector2 vertical = new Vector2();
    private bool facingRight;
    // Start is called before the first frame update
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

        if (pressHorizontal > 0 && !facingRight)
        {
            PlayerdirectionMove();
        }
        else if (pressHorizontal < 0 && facingRight)
        {
            PlayerdirectionMove();
        }


    }

    protected virtual void PlayerdirectionMove()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        facingRight = !facingRight;
        transform.localScale = theScale;
    }
}
