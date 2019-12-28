using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FactoryManager : MonoBehaviour
{
	// instantiate the singleton of the game
	public static FactoryManager _instance = null;

	// booleans for all of the different puzzles
	bool redLever, blueLever, greenLever, yellowLever;
	bool generatorOn;
	bool escapeMessageDisplayed;
	bool openInv = false;

	public Text timerText;
	float lastTime;
	int timeCount;
	const int BEST_TIME = 180;

	// GameObjects used throughout the game
	public GameObject player;
	public GameObject Crowbar;
	public GameObject LockerDoor;
	public GameObject KeyCard;
	public GameObject KeyCardDoor;
	public GameObject HoldBallPlatform;
	public GameObject box;
	public GameObject wire;

	// lights used for the lever puzzle
	public GameObject RedLight;
	public GameObject GreenLight;
	public GameObject BlueLight;
	public GameObject YellowLight;

	// levers used for the main door puzzle
	public GameObject LeverRed;
	public GameObject LeverGreen;
	public GameObject LeverBlue;
	public GameObject LeverYellow;
	public GameObject LeverOrange;

	// active and disabled sprites for flicking the levers
	public Sprite activeSpriteLever;
	public Sprite disabledSpriteLever;

	// text shown throughout the scene
	public Text messageText;
	public Image FadeBlack;
	public Image inventory;
	public Canvas inventoryCanvas;


	// return the instance of the singleton
	public static FactoryManager Instance
	{
		get
		{
			return _instance;
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		lastTime = Time.time;
		timeCount = 0;
		timerText.text = "Time: " + timeCount;
		// set all of the boolean checks to false
		messageText.enabled = false;
		escapeMessageDisplayed = false;
		redLever = blueLever = greenLever = yellowLever = false;
		generatorOn = false;
		FadeBlack.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.time - lastTime >= 1) {
			lastTime = Time.time;
			timeCount++;
			timerText.text = "Time: " + timeCount;
		}

		if (Input.GetKeyDown(KeyCode.I))
		{
			if (openInv == false)
			{
				// give the player back their controls
				player.GetComponent<PlayerMovement>().enabled = false;
				// open the inventory
				inventoryCanvas.GetComponent<Canvas>().enabled = true;
				// inventory is now open
				openInv = true;
			}

			else
			{
				// give the player back their controls
				player.GetComponent<PlayerMovement>().enabled = true;
				// close the inventory
				inventoryCanvas.GetComponent<Canvas>().enabled = false;
				// inventory is now closed
				openInv = false;
			}
		}

		// making sure the box is pushable
		if (box.transform.position.x > 16 || box.transform.position.x < -16)
		{
			// reset the box so the player cannot move it into a corner
			box.transform.position = new Vector2(0,-7.1f);
		}


		// checking to see if the main door is unlocked
		if (redLever == true && blueLever == true && greenLever == true && yellowLever == true)
		{
			// if the escape message has not been shown
			if (escapeMessageDisplayed == false)
			{
				// message displayed to screen
				messageText.text = "Main door has been opened";
				ShowHint();
				// the message has now been displayed
				escapeMessageDisplayed = true;
			}
			// unlock the main door
			Destroy(GameObject.FindGameObjectWithTag("MainDoor"));
		}
	}

	// checking if the singleton instance already exists
	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			// if so destroy the current instance and instatiate a new one
			Destroy(this.gameObject);
			return;
		}
		// otherwise this instance is of itself
		_instance = this;
	}


	public void FlickLever(char c)
	{
		// if the generator is currently on
		if (generatorOn)
		{
			// the red lever
			if (c == 'R')
			{
				// checking to assure the correct password
				if (blueLever == false && greenLever == false && yellowLever == false)
				{
					FactoryAudio.PlaySound("lever");

					// flick the red lever and animate the lever
					LeverRed.GetComponent<SpriteRenderer>().sprite = activeSpriteLever;
					redLever = true;
				}
				else
				{
					// otherwise reset the levers
					ResetLevers();
				}
			}
			// the green lever
			else if (c == 'G')
			{
				// checking to assure the correct password
				if (redLever == true && blueLever == false && yellowLever == false)
				{
					FactoryAudio.PlaySound("lever");

					// flick the green lever and animate the lever
					LeverGreen.GetComponent<SpriteRenderer>().sprite = activeSpriteLever;
					greenLever = true;
				}
				else
				{
					// otherwise reset the levers
					ResetLevers();
				}
			}
			// the blue lever
			else if (c == 'B')
			{
				// checking to assure the correct password
				if (redLever == true && greenLever == true && yellowLever == false)
				{
					FactoryAudio.PlaySound("lever");


					// flick the blue lever and animate the lever
					LeverBlue.GetComponent<SpriteRenderer>().sprite = activeSpriteLever;
					blueLever = true;
				}
				else
				{
					// otherwise reset the levers
					ResetLevers();
				}
			}
			// the yellow lever
			else
			{
				

				// check to assure the correct password
				if (redLever == true && greenLever == true && blueLever == true)
				{
					FactoryAudio.PlaySound("lever");

					// flick the yellow lever and animate the lever
					LeverYellow.GetComponent<SpriteRenderer>().sprite = activeSpriteLever;
					yellowLever = true;
				}
				else
				{
					// otherwise reset the levers
					ResetLevers();
				}
			}
		}
		else
		{
			// otherwise display message to screen
			messageText.text = "Need to turn on a generator";
			ShowHint();
		}
	}

	public void ClimbLadder(string ladder)
	{
		// if statements to check for the correct ladder
		if (ladder.Equals("Ladder1"))
		{
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				// Fade the screen when the player moves in a ladder
				FadeOut();

				// move the player up the ladder
				player.transform.position = new Vector3(-14, -9, 0);
			}
			else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				// Fade the screen when the player moves in a ladder
				FadeOut();

				// move the player down the ladder
				player.transform.position = new Vector3(-14, -19, 0);
			}
		}
		else if (ladder.Equals("Ladder2"))
		{
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				// Fade the screen when the player moves in a ladder
				FadeOut();

				// move the player up the ladder
				player.transform.position = new Vector3(-5, -19, 0);
			}
			else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				// Fade the screen when the player moves in a ladder
				FadeOut();

				// move the player down the ladder
				player.transform.position = new Vector3(-5, -29, 0);
			}
		}
		else if (ladder.Equals("Ladder3"))
		{
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				// Fade the screen when the player moves in a ladder
				FadeOut();

				// move the player up the ladder
				player.transform.position = new Vector3(10, 4.5f, 0);
			}
			else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				// Fade the screen when the player moves in a ladder
				FadeOut();

				// move the player down the ladder
				player.transform.position = new Vector3(10, -6, 0);
			}
		}
		else if (ladder.Equals("Ladder4"))
		{
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				// Fade the screen when the player moves in a ladder
				FadeOut();

				// move the player up the ladder
				player.transform.position = new Vector3(-13, 11, 0);
			}
			else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				// Fade the screen when the player moves in a ladder
				FadeOut();

				// move the player down the ladder
				player.transform.position = new Vector3(-13, 4, 0);
			}
		}
		else if (ladder.Equals("Ladder5"))
		{
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				// Fade the screen when the player moves in a ladder
				FadeOut();

				// move the player up the ladder
				player.transform.position = new Vector3(-62, 10, 0);
			}
			else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				// Fade the screen when the player moves in a ladder
				FadeOut();

				// move the player down the ladder
				player.transform.position = new Vector3(-62, 4, 0);
			}
		}
	}


	public void ChangeInventory(string item)
	{
		switch (item)
		{
			case "crowbar":
				inventory.transform.GetChild(0).GetComponent<Image>().enabled = true;
				Destroy(Crowbar);
				break;
			case "keyCard":
				inventory.transform.GetChild(1).GetComponent<Image>().enabled = true;
				Destroy(KeyCard);
				break;
			case "wire":
				inventory.transform.GetChild(2).GetComponent<Image>().enabled = true;
				Destroy(wire);
				break;
		}
	}

	public void FadeOut()
	{
		// play the ladder climbing sound
		FactoryAudio.PlaySound("climb");
		// remove controls from the player
		player.GetComponent<PlayerMovement>().enabled = false;
		// make the screen go black
		FadeBlack.enabled = true;
		// call the fade in method
		Invoke("FadeIn", 1.5f);
	}

	public void FadeIn()
	{
		// fade the screen back in
		FadeBlack.enabled = false;
		// give the player back their controls
		player.GetComponent<PlayerMovement>().enabled = true;
	}


	public void ResetLevers()
	{
		// set all of the boolean logic of the levers back to false
		redLever = blueLever = greenLever = yellowLever = false;
		// reset all of the sprites to the disabled 
		LeverRed.GetComponent<SpriteRenderer>().sprite = disabledSpriteLever;
		LeverGreen.GetComponent<SpriteRenderer>().sprite = disabledSpriteLever;
		LeverBlue.GetComponent<SpriteRenderer>().sprite = disabledSpriteLever;
		LeverYellow.GetComponent<SpriteRenderer>().sprite = disabledSpriteLever;
	}

	public void SetActiveLights()
	{
		// set all of the lights to active
		RedLight.SetActive(true);
		GreenLight.SetActive(true);
		BlueLight.SetActive(true);
		YellowLight.SetActive(true);
		// set the generator to on so the levers can be used
		generatorOn = true;
	}

	public void ReleaseBall()
	{
		// release the ball from the ceiling
		LeverOrange.GetComponent<SpriteRenderer>().sprite = disabledSpriteLever;
		Destroy(HoldBallPlatform);
	}

	public void OpenLockerDoor()
	{
		// open the locker door
		Destroy(LockerDoor);
	}

	public void OpenKeyCardDoor()
	{
		// open the KeyCardDoor
		Destroy(KeyCardDoor);
	}

	public void ShowHint()
	{
		// display messages to the screen
		messageText.enabled = true;
		// disable the text in 7 seconds
		Invoke("DisableText", 7);
	}
	public void DisableText()
	{
		// disable the text after it has been dislayed
		messageText.enabled = false;
	}

	public void EndGame()
	{

		//Check Achievements
		if (PlayerPrefs.GetInt("LevelOneTime") == 0 && timeCount < BEST_TIME) {
			PlayerPrefs.SetInt("LevelOneTime", 1);
		}
		// end the game when the player esacpes
		Invoke("MainMenu", 4);
	}

	public void MainMenu()
	{
		// load the main menu
		SceneManager.LoadScene("MainMenu");
	}

}
