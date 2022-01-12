using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Rigidbody2D objectrb2D;
    public float moveSpeed = 50f;
    public float jumpSpeed = 20f;
    public float groundedDistance = 1f;
    public LayerMask groundedMask;

    private GameObject objectToMakeAppear;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (IsGrounded())
        {
            Jump();
        }

    }


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            objectrb2D.velocity = new Vector2(objectrb2D.velocity.x, jumpSpeed);
        }
    }

    private void Move()
    {
        float currentMoveSpeed = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentMoveSpeed = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            currentMoveSpeed = moveSpeed;
        }
        objectrb2D.velocity = new Vector2(currentMoveSpeed, objectrb2D.velocity.y);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(objectrb2D.position, Vector2.down, groundedDistance, groundedMask);
        Debug.DrawRay(objectrb2D.position, Vector2.down * groundedDistance, Color.green);
        return hit.collider != null;
    }

}