using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigBdy;
    private Animator anm;
    private BoxCollider2D bxc;
    [SerializeField] private LayerMask jumpableGround;
    private float dirX = 0f;
    private SpriteRenderer playerSprite;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpForce = 7f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;




    // Start is called before the first frame update
    private void Start()
    {
        rigBdy = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
        bxc = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rigBdy.velocity = new Vector2(dirX * moveSpeed, rigBdy.velocity.y);
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSoundEffect.Play();
            rigBdy.velocity = new Vector2(rigBdy.velocity.x, jumpForce);
        }

        // creating a func for running animation movement;
        UpdateAnimationState();

    }

    private void UpdateAnimationState() // creating a func for running animation movement;
    {
        MovementState state;
        if (dirX > 0f) // +ve - right direction
        {
            state = MovementState.running;
            playerSprite.flipX = false;
        }

        else if (dirX < 0f) // -ve - left direction
        {
            state = MovementState.running;
            playerSprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rigBdy.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rigBdy.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anm.SetInteger("state", ((int)state));
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(bxc.bounds.center, bxc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
