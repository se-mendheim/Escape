using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficePlayer : MonoBehaviour
{
	// checking things throughout the level
	bool hasKey;
	bool hasGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("MainDoor"))
		{
			// if the player has the gun
			if (hasGun)
			{
				// make the screen go black for dramatic effect
				OfficeManager._instance.FadeOut();
				
				// play the gunshot sound
				OfficeAudio.PlaySound("gunshot");

				// open up the main door
				OfficeManager._instance.OpenMainDoor();

				// send message to the player
				OfficeManager._instance.messageText.text = "Escaped the office building";
				OfficeManager._instance.ShowHint();

				// end the game
				OfficeManager._instance.EndGame();
			}

			else
			{
				// send message to the user
				OfficeManager._instance.messageText.text = "There are chains holding the door together...";
				OfficeManager._instance.ShowHint();
			}
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Door"))
		{
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			{
				// go up the elevator
				OfficeManager._instance.UpElevator();
			}
			else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
			{
				// go down the elevator
				OfficeManager._instance.DownElevator();
			}
		}
		else if (collision.gameObject.CompareTag("Power"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// if the player has the key
				if (hasKey == true)
				{
					// display the breaker box to the user
					OfficeManager._instance.DisplayBreakerBox();
				}
				else
				{
					// send a message to the screen
					OfficeManager._instance.messageText.text = "Need a key to open the breaker box...";
					OfficeManager._instance.ShowHint();
				}
			}
		}

		else if (collision.gameObject.CompareTag("OfficeWire"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// if the player doesnt have the key
				if (!hasKey)
				{
					// play the sound of picking up the key
					OfficeAudio.PlaySound("item");

					// change the inventory
					OfficeManager._instance.ChangeInventory("key");

					// the user now has a key
					hasKey = true;

					// send emssage to screen
					OfficeManager._instance.messageText.text = "Aquired a key...";
					OfficeManager._instance.ShowHint();
				}
			}
		}

		else if (collision.gameObject.CompareTag("USBPlant"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// if the user does not have the USB
				if (!OfficeManager._instance.hasUSB)
				{
					// play the sound of picking up the USB
					OfficeAudio.PlaySound("item");

					// change the inventory
					OfficeManager._instance.ChangeInventory("USB");

					// set the hasUSB bool
					OfficeManager._instance.HasUSB();

					// display message to the user
					OfficeManager._instance.messageText.text = "Aquired a USB...";
					OfficeManager._instance.ShowHint();
				}

			}
		}

		else if (collision.gameObject.CompareTag("Printer"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// display the printer to the screen
				OfficeManager._instance.DisplayPrinter();
			}
		}

		else if (collision.gameObject.CompareTag("Vending Machine"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// display the vending machine to the screen
				OfficeManager._instance.DisplayVendingMachine();
			}
		}

		else if (collision.gameObject.CompareTag("GunDesk"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// picking up item sound
				OfficeAudio.PlaySound("item");

				// the player now has a gun
				hasGun = true;

				// change the inventory to have a gun
				OfficeManager._instance.ChangeInventory("gun");

				// send message to the user
				OfficeManager._instance.messageText.text = "Picked up a gun?...";
				OfficeManager._instance.ShowHint();
			}
		}

		else if (collision.gameObject.CompareTag("Computer 2"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// display the computer to the screen
				OfficeManager._instance.DisplayComputer();
			}
		}

		else if (collision.gameObject.CompareTag("WaterCooler"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// send message to the user 
				OfficeManager._instance.messageText.text = "The water looks disgusting...";
				OfficeManager._instance.ShowHint();
			}
		}

		else if (collision.gameObject.CompareTag("Computer 1"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// send message to the user
				OfficeManager._instance.messageText.text = "The computer seems to be dead...";
				OfficeManager._instance.ShowHint();
			}
		}

		else if (collision.gameObject.CompareTag("Couch"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// send message to the user
				OfficeManager._instance.messageText.text = "Nothing but dust in the couch...";
				OfficeManager._instance.ShowHint();
			}
		}

		else if (collision.gameObject.CompareTag("empty"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// send message to the user
				OfficeManager._instance.messageText.text = "Drawers were empty...";
				OfficeManager._instance.ShowHint();
			}
		}

		else if (collision.gameObject.CompareTag("Shelf"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// send message to the user
				OfficeManager._instance.messageText.text = "The shelves are empty...";
				OfficeManager._instance.ShowHint();
			}
		}
	}
}
