using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    //privates to ref later in code - shortened names

    [SerializeField] private LayerMask jumpableGround;
    //

    private float dirX = 0f;
    //just in case

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    //serialzefield is used to edit the speeds in unity under the script
    //make sure the value is the same in unity!!!!

    private enum MovementState { idle, running, jumping, falling }
    //holds the different animation states and has assigned values in the animator

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        coll = GetComponent<BoxCollider2D>();

        sprite = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();/**/
        //set here to not have to type again
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");//horizontal here instead of writing if block for arrow keys and wasd keys.
        //default input manager should have this, cool thing i found also used if a joystick is attached. 
        //will it work ?
        //the getaxisraw means it gets back to zero immedately instead of gradually elimating friction

        //mostly used for joystick support, for checking in between the left and right like .5 and -.5
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        //used instead of an if block, if the firectionX is negative then the x velocity will be negative

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
        //calls the code below for moving 
    }


    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            //changes the state to running
            sprite.flipX = false;
            //flips the sprite on x axis
        }//going right
        else if (dirX < 0f)
        {
            state = MovementState.running;
            //changes the state to running
            sprite.flipX = true;
            //flips the sprite on x axis
        }//going left
        else
        {
            state = MovementState.idle;
        }// switches to idle

        if (rb.velocity.y > .1f)
            //going up on the y axis
        {
            state = MovementState.jumping;
            //changes the state to jumping
        }
        else if (rb.velocity.y < -.1f)
            //going down on the y axis
        {
            state = MovementState.falling;
            //changes the state to falling
        }

        anim.SetInteger("state", (int)state);
        //turns the states into int values . turs the enum above into the int values
    }

    private bool IsGrounded()
    {
        //to stop double jump along with making the terrain tiles a ground layer
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        //checks if theres ground underneat it
    }

}
