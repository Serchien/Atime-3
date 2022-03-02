using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(1,20)] float speed;
    [SerializeField, Range(5f, 20f)] float jump;
    Rigidbody2D rb;
    float movHorizontal;


    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;


    public float fallMultiplier = 5.5f;
    public float lowJumpMultiplier = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movHorizontal = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Jump") > 0)
        {
            //RaycastHit2D hit = Physics2D.Raycast(rayOrigin.transform.position, Vector2.down, rayCheckDistance);
            if (isGrounded)
            {
                Jump();
                BetterJump();
            }
        }
    }

    void FixedUpdate()
    {
        CheckIfGrounded();
        rb.velocity = new Vector3(movHorizontal * speed, rb.velocity.y, 0);

    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void Jump()
    {
        //rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        rb.velocity = new Vector2(rb.velocity.x, jump);

    }

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void GetHit()
    {
        Debug.Log("YOYOYOOY");
    }
}

