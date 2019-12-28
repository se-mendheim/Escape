using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// booleans to check for certain aspects of the game
	bool startedJump = false;
	bool isGrounded = true;
	
	// rigidbody for the player
	Rigidbody2D rbody;
	// checking the player speed for the animation
	float playerSpeed;
	// animation for the player
	public Animator animation;
	// jumpspeed for the player
	public float jumpSpeed;
	// sprite renderer for the player
	public SpriteRenderer sr;
	// Start is called before the first frame update
	void Start()
    {
		// setting all
		rbody = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		playerSpeed = 0;
	}

    // Update is called once per frame
    void Update()
    {
		
	}

	private void FixedUpdate()
	{     
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
		{
            // set the jumping booleans to true
            startedJump = true;
            isGrounded = false;
            // if the player is jumping set the jumping animation
            animation.SetBool("IsJumping", true);
		}
		// set the rigidbody velocity to the player input
		rbody.velocity = new Vector2(10 * Input.GetAxis("Horizontal"), rbody.velocity.y);

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			// flip the sprite in the direction the player is running
			sr.flipX = true;
            animation.SetBool("IsMoving", true);
		}
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			// flip the sprite in the direction the player is running
			sr.flipX = false;
            animation.SetBool("IsMoving", true);
        }
        else if (rbody.velocity.x == 0)
        {
            animation.SetBool("IsMoving", false);
        }

		// getting the speed of a player
		playerSpeed = rbody.velocity.x;
		// setting the animation accordingly
		animation.SetFloat("Speed", Mathf.Abs(playerSpeed));

		if (startedJump == true)
		{
			// having the player jump
			rbody.velocity = new Vector2(rbody.velocity.x, jumpSpeed);
			startedJump = false;
		}

		if (rbody.velocity.y < -0.1)
		{
			// change the player animation to jumping
			animation.SetBool("IsFalling", true);
			animation.SetBool("IsJumping", false);
		}
		else
		{
			// setting the player animation to falling
			animation.SetBool("IsFalling", false);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			// making sure the player can only jump when grounded
			isGrounded = true;
            startedJump = false;
		}
	}
}
