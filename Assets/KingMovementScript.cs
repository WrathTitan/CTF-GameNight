using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMovementScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spr;
    private Animator anim;
    public float moveSpeed = 2.0f;
    public float jumpHeight = 5.0f;
    private bool isFacingRight;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isFacingRight = true;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if ((moveHorizontal > 0)&& !isFacingRight) 
        {
            spr.flipX = false;
            isFacingRight = !isFacingRight;
            anim.SetBool("isWalking", true);
        }
        if ((moveHorizontal < 0) && isFacingRight)
        {
            spr.flipX = true;
            isFacingRight = !isFacingRight;
            anim.SetBool("isWalking", true);
        }
        if (moveHorizontal == 0)
        {
            anim.SetBool("isWalking", false);
        }
        transform.Translate(new Vector3(moveHorizontal, 0.0f, 0.0f) * Time.deltaTime * moveSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = new Vector2(0.0f, jumpHeight);
            anim.SetTrigger("isJumping");
        }
    }
}
