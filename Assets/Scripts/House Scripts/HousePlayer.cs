using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePlayer : MonoBehaviour
{
	// GameObject for the closet key
	public GameObject ClosetKey;


	// booleans for all of the game logic
	bool hasClosetKey;
	bool hasPianoPiece;
	bool hasBeenPlayed;
	bool hasSword;
	bool hasWood;
	bool hasRope;
	bool balconyUnlocked;
	bool atticUnlocked;
	bool libraryUnlocked;
	bool greenBook, redBook, blueBook;
	bool c1, c2, c3, c4, c5;

    // Start is called before the first frame update
    void Start()
    {
		// setting all of the logic to false at the start of the game
		hasClosetKey = false;
		hasPianoPiece = false;
		hasSword = false;
		hasWood = false;
		hasRope = false;
		balconyUnlocked = false;
		atticUnlocked = false;
		libraryUnlocked = false;
		greenBook = redBook = blueBook = false;
		c1 = c2 = c3 = c4 = c5;
    }

    // Update is called once per frame
    void Update()
    {
		// if all of the books are active
		if (greenBook && redBook && blueBook)
		{
			if (atticUnlocked == false)
			{
				// open the balcony door
				HouseManager._instance.messageText.text = "The attic would be a good place to check next...";
				HouseManager._instance.ShowHint();

				// inventory now has a hint
				HouseManager._instance.ChangeInventory("hint");

				HouseManager._instance.SetActiveCandles();
			}
			// setting logic for the balcony door
			atticUnlocked = true;
		}

		if (c1 && c2 && c3 && c4 && c5)
		{
			if (balconyUnlocked == false)
			{
				// open the balcony door
				HouseManager._instance.messageText.text = "A door upstairs just opened...";
				HouseManager._instance.ShowHint();
			}
			balconyUnlocked = true;
		}
    }

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.CompareTag("Rope"))
		{
			// picking up an item
			HouseAudio.PlaySound("item");

			// inventory now has a rope
			HouseManager._instance.ChangeInventory("rope");

			// display message to screen
			HouseManager._instance.messageText.text = "Picked up some rope...";
			HouseManager._instance.ShowHint();
			// player now has the rope
			hasRope = true;
			// destroy the rope
			HouseManager._instance.DestroyRope();
		}
		if (coll.gameObject.CompareTag("Sword"))
		{
			// picking up an item
			HouseAudio.PlaySound("item");

			// inventory now has a sword
			HouseManager._instance.ChangeInventory("sword");

			// display message to screen
			HouseManager._instance.messageText.text = "Picked up a sword...";
			HouseManager._instance.ShowHint();
			// player now has a sword
			hasSword = true;
			// destroy the sword
			HouseManager._instance.DestroySword();
		}
		if (coll.gameObject.CompareTag("RopeLadderPlace"))
		{
			// display message to screen
			HouseManager._instance.messageText.text = "A rope ladder could be placed here...";
			HouseManager._instance.ShowHint();
		}
	}


	private void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.gameObject.CompareTag("Ladder1"))
		{

			// climb the ladder
			HouseManager._instance.ClimbLadder("Ladder1");
		}
		else if (coll.gameObject.CompareTag("Ladder2"))
		{

			// climb the ladder
			HouseManager._instance.ClimbLadder("Ladder2");
		}
		else if (coll.gameObject.CompareTag("Ladder3"))
		{
			
			// climb the ladder
			HouseManager._instance.ClimbLadder("Ladder3");
		}
		else if (coll.gameObject.CompareTag("Ladder4"))
		{
			

			// climb the ladder
			HouseManager._instance.ClimbLadder("Ladder4");
		}
		else if (coll.gameObject.CompareTag("AtticLadder"))
		{
			
			if (Input.GetKeyDown(KeyCode.W))
			{
				if (atticUnlocked == true)
				{
					HouseAudio.PlaySound("climb");

					HouseManager._instance.FadeOut();

					transform.position = new Vector3(28, -1, 0);
				}
				else
				{
					HouseManager._instance.messageText.text = "Need to unlock the attic first...";
					HouseManager._instance.ShowHint();
				}
			}

			else if (Input.GetKeyDown(KeyCode.S))
			{
				if (atticUnlocked == true)
				{
					HouseManager._instance.FadeOut();

					transform.position = new Vector3(28, -12, 0);
				}
				else
				{
					HouseManager._instance.messageText.text = "Need to unlock the attic first...";
					HouseManager._instance.ShowHint();
				}
			}
		}

		if (coll.gameObject.CompareTag("ClosetKey"))
		{
			// picking up an item
			HouseAudio.PlaySound("item");

			// inventory now has a closetKey
			HouseManager._instance.ChangeInventory("closetKey");

			// player now has the closet key
			hasClosetKey = true;
			// display message to screen
			HouseManager._instance.messageText.text = "Found closet key...";
			HouseManager._instance.ShowHint();
			// destroy the closet key
			Destroy(ClosetKey);
		}
		if (coll.gameObject.CompareTag("LockedCloset"))
		{
			if (hasClosetKey)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					// open the closet and pick up piano piece
					HouseAudio.PlaySound("closet");

					// display message to screen
					HouseManager._instance.messageText.text = "Unlocked Closet and found piano piece...";
					HouseManager._instance.ShowHint();
					// player now has piano piece
					hasPianoPiece = true;
				}
			}
		}

		if (coll.gameObject.CompareTag("Piano"))
		{
			if (hasPianoPiece)
			{
				if (Input.GetKeyDown(KeyCode.E) && !hasBeenPlayed)
				{
					// play the piano
					HouseManager._instance.PlayPiano();

					// display message to screen
					HouseManager._instance.messageText.text = "A loud crash can be heard downstairs...";
					HouseManager._instance.ShowHint();
					// piano has been played
					hasBeenPlayed = true;
					// drop the rope
					HouseManager._instance.DropRope();
				}
			}
			else
			{
				// display message to screen
				HouseManager._instance.messageText.text = "The piano seems to be broken...";
				HouseManager._instance.ShowHint();
			}
		}
		
		if (coll.gameObject.CompareTag("BreakableWood"))
		{
			if (hasSword)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					// destroy the wooden shelf
					HouseManager._instance.DestroyWood();

					HouseAudio.PlaySound("break");
					

					// dislay message to screen
					HouseManager._instance.messageText.text = "Picked up some wood...";
					HouseManager._instance.ShowHint();
					// player now has wood
					hasWood = true;
				}
			}
		}

		if (coll.gameObject.CompareTag("Toilet"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				// flush the toilet
				HouseAudio.PlaySound("toilet");

				// display message to screen
				HouseManager._instance.messageText.text = "Found a library key...";
				HouseManager._instance.ShowHint();
				// library is now unlocked
				libraryUnlocked = true;
			}
		}

		if (coll.gameObject.CompareTag("GreenBook"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				if (!redBook && !blueBook)
				{
					// open a book
					HouseAudio.PlaySound("book");

					// if password is correct open the green book
					greenBook = true;
					HouseManager._instance.OpenBook('G');
				}
				else
				{
					// otherwise reset the books
					greenBook = redBook = blueBook = false;
					HouseManager._instance.ResetBooks();
				}
			}
		}
		if (coll.gameObject.CompareTag("RedBook"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				if (greenBook && blueBook)
				{
					// open a book
					HouseAudio.PlaySound("book");

					// if password is correct open the red book
					redBook = true;
					HouseManager._instance.OpenBook('R');
				}
				else
				{
					// otherwise reset the books
					greenBook = redBook = blueBook = false;
					HouseManager._instance.ResetBooks();
				}
			}
		}
		if (coll.gameObject.CompareTag("BlueBook"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				if (greenBook && !redBook)
				{
					// open a book
					HouseAudio.PlaySound("book");

					// if the password is correct open the blue book
					blueBook = true;
					HouseManager._instance.OpenBook('B');
				}
				else
				{
					// otherwise reset the books
					greenBook = redBook = blueBook = false;
					HouseManager._instance.ResetBooks();
				}
			}
		}
		if (coll.gameObject.CompareTag("RopeLadderPlace"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				if (hasWood && hasRope)
				{
					// display message to screen
					HouseManager._instance.messageText.text = "You have escaped!";
					HouseManager._instance.ShowHint();
					// activate the rope ladder
					HouseManager._instance.ActivateRopeLadder();
					// end the game
					HouseManager._instance.EndGame();
				}
			}
		}


		if (coll.gameObject.CompareTag("S"))
		{
			if (atticUnlocked == true)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{

					if (!c1 && !c2 && !c3 && !c4 && !c5)
					{
						c1 = true;
						HouseAudio.PlaySound("active");
						HouseManager._instance.SetCandleS();
					}

					else
					{
						c1 = c2 = c3 = c4 = c5 = false;
						HouseAudio.PlaySound("deactive");
						HouseManager._instance.SetActiveCandles();
					}
				}
			}
		}
		
		if (coll.gameObject.CompareTag("T"))
		{
			if (atticUnlocked == true)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{

					if (c1 && !c2 && !c3 && !c4 && !c5)
					{
						c2 = true;
						HouseAudio.PlaySound("active");
						HouseManager._instance.SetCandleT();
					}

					else
					{
						c1 = c2 = c3 = c4 = c5 = false;
						HouseAudio.PlaySound("deactive");
						HouseManager._instance.SetActiveCandles();
					}
				}
			}
		}
		if (coll.gameObject.CompareTag("V"))
		{
			if (atticUnlocked == true)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{

					if (c1 && c2 && c3 && !c4 && !c5)
					{
						c4 = true;
						HouseAudio.PlaySound("active");
						HouseManager._instance.SetCandleV();
						HouseManager._instance.SetCandleActiveE();
					}

					else
					{
						c1 = c2 = c3 = c4 = c5 = false;
						HouseAudio.PlaySound("deactive");
						HouseManager._instance.SetActiveCandles();
					}
				}
			}
		}
		if (coll.gameObject.CompareTag("E"))
		{
			if (atticUnlocked == true)
			{
				if (Input.GetKey(KeyCode.E))
				{

					if (c1 && c2 && !c3 && !c4 && !c5)
					{
						c3 = true;
						HouseAudio.PlaySound("active");
						HouseManager._instance.SetCandleE();
					}

					else if (c1 && c2 && c3 && c4 && !c5)
					{
						c5 = true;
						HouseAudio.PlaySound("active");
						HouseManager._instance.SetCandleE();
					}

					
				}
			}
		}
	}

	private void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag("BalconyDoor"))
		{
			if (balconyUnlocked)
			{
				// destroy the balcony door if the book passcode has been entered
				HouseManager._instance.DestroyBalconyDoor();
			}
			else
			{
				// display message to screen
				HouseManager._instance.messageText.text = "The door is locked...";
				HouseManager._instance.ShowHint();
			}
		}
		if (coll.gameObject.CompareTag("LibraryDoor"))
		{
			if (libraryUnlocked)
			{
				// display message to screen
				HouseManager._instance.messageText.text = "Used the library key, the door opened easily...";
				HouseManager._instance.ShowHint();
				// open the lobrary door
				HouseManager._instance.DestroyLibraryDoor();
			}
			else
			{
				// display message to screen
				HouseManager._instance.messageText.text = "The door is locked...";
				HouseManager._instance.ShowHint();
			}
		}
		if (coll.gameObject.CompareTag("BigJump"))
		{
			// display message to screen if the player tries to jump off
			HouseManager._instance.messageText.text = "That is way to big of a drop...";
			HouseManager._instance.ShowHint();
		}
	}
}
