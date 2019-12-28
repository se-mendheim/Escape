using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPlayer : MonoBehaviour
{
	// booleans to check if the player has certain objects
	bool hasCrowbar = false;
	bool hasKeyCard = false;
	bool hasWire = false;
	

	
	
	// Start is called before the first frame update
	void Start()
	{
	
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		// if the player collides with the crowbar
		if (coll.gameObject.CompareTag("Crowbar"))
		{
			// picking up crowbar sound
			FactoryAudio.PlaySound("item");

			// changing the inventory
			FactoryManager._instance.ChangeInventory("crowbar");

			// the player now has a crowbar
			hasCrowbar = true;
			// message displayed to screen
			FactoryManager._instance.messageText.text = "Crowbar aquired";
			FactoryManager._instance.ShowHint();
		}
		// if the player collides with the keycard
		else if (coll.gameObject.CompareTag("KeyCard"))
		{
			// picking up keycard sound
			FactoryAudio.PlaySound("item");

			// changing the inventory
			FactoryManager._instance.ChangeInventory("keyCard");

			// the player now has a keycard
			hasKeyCard = true;
			// message displayed to screen
			FactoryManager._instance.messageText.text = "KeyCard aquired";
			FactoryManager._instance.ShowHint();
		}
		// if the player collides with the wire
		else if (coll.gameObject.CompareTag("Wire"))
		{
			// picking up wire sound
			FactoryAudio.PlaySound("item");

			// changing the inventory
			FactoryManager._instance.ChangeInventory("wire");

			// the player now has a wire
			hasWire = true;
			// message displayed to screen
			FactoryManager._instance.messageText.text = "Wire aquired";
			FactoryManager._instance.ShowHint();
		}
		// if the player collides with the finish game object
		else if (coll.gameObject.CompareTag("FinishGame"))
		{
			// message displayed to screen
			FactoryManager._instance.messageText.text = "You have escaped!";
			FactoryManager._instance.ShowHint();
			// end the game and return to the main screen
			FactoryManager._instance.EndGame();
		}
	}

	private void OnTriggerStay2D(Collider2D coll)
	{
		// comparison for the first ladder to move the player
		if (coll.gameObject.CompareTag("Ladder1"))
		{
			// calling method to check for player input
			FactoryManager._instance.ClimbLadder("Ladder1");
		}
		// comparison for the second ladder to move the player
		else if (coll.gameObject.CompareTag("Ladder2"))
		{
			// calling method to check for player input
			FactoryManager._instance.ClimbLadder("Ladder2");
		}
		// comparison for the third ladder to move the player
		else if (coll.gameObject.CompareTag("Ladder3"))
		{
			// calling method to check for player input
			FactoryManager._instance.ClimbLadder("Ladder3");
		}
		// comparison for the fourth ladder to move the player
		else if (coll.gameObject.CompareTag("Ladder4"))
		{
			// calling method to check for player input
			FactoryManager._instance.ClimbLadder("Ladder4");
		}
		else if (coll.gameObject.CompareTag("Ladder5"))
		{
			FactoryManager._instance.ClimbLadder("Ladder5");
		}
		
		
		// collision with the lever to drop the wrecking ball
		else if (coll.gameObject.CompareTag("HoldBallLever"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				FactoryAudio.PlaySound("lever");

				// release the ball from the cieling
				FactoryManager._instance.ReleaseBall();
				// message is displayed to screen
				FactoryManager._instance.messageText.text = "Wrecking ball has been dropped";
				FactoryManager._instance.ShowHint();
			}
		}
		// collision for the red lever
		else if (coll.gameObject.CompareTag("LeverRed"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// flick the lever if E is clicked
				FactoryManager._instance.FlickLever('R');
			}
		}
		// collision for the blue lever
		else if (coll.gameObject.CompareTag("LeverBlue"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// flick the lever if E is clicked
				FactoryManager._instance.FlickLever('B');
			}
		}
		// collision for the green lever
		else if (coll.gameObject.CompareTag("LeverGreen"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// flick the lever if E is clicked
				FactoryManager._instance.FlickLever('G');
			}
		}
		// collision for the yellow lever
		else if (coll.gameObject.CompareTag("LeverYellow"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// flick the lever if E is clicked
				FactoryManager._instance.FlickLever('Y');
			}
		}
		// collision for the generator
		else if (coll.gameObject.CompareTag("Generator"))
		{
			if (hasWire)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					// picking up crowbar sound
					FactoryAudio.PlaySound("generator");

					// turn on the colored lights in the factory
					FactoryManager._instance.SetActiveLights();
					// message is displayed to screen
					FactoryManager._instance.messageText.text = "Power has been turned on";
					FactoryManager._instance.ShowHint();
				}
			}
			else
			{
				FactoryManager._instance.messageText.text = "Need a wire to power on the generator";
				FactoryManager._instance.ShowHint();
			}
			
		}
		
	}

	private void OnCollisionStay2D(Collision2D coll)
	{
		// door for the locker room
		if (coll.gameObject.CompareTag("LockerDoor"))
		{
			if (hasCrowbar)
			{
				// open door sound
				FactoryAudio.PlaySound("door");
				// open the locker door if the player has a crowbar
				FactoryManager._instance.OpenLockerDoor();
			}
			else
			{
				// otherwise display that the player needs a crowbar to the screen
				FactoryManager._instance.messageText.text = "Need a crowbar to open this door";
				FactoryManager._instance.ShowHint();
			}
		}
		// door for the outside
		if (coll.gameObject.CompareTag("KeyCardDoor"))
		{
			if (hasKeyCard)
			{
				// open door sound
				FactoryAudio.PlaySound("door");
				// open the locker door if the player has a keycard
				FactoryManager._instance.OpenKeyCardDoor();
			}
			else
			{
				// otherwise display that the player needs a keycard to the screen
				FactoryManager._instance.messageText.text = "Need a keycard to open this door";
				FactoryManager._instance.ShowHint();
			}
		}
	}
}
