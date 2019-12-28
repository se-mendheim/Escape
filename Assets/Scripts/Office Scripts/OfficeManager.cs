using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class OfficeManager : MonoBehaviour
{
	public static OfficeManager _instance = null;

	//bool openInv = false;
	bool computerOn = false;
	bool ceoOffice = false;
	bool openInv = false;
	public bool hasUSB = false;

	// 
	string codeValue = "";
	string vendingValue = "";

	// GameObjects used throughout the game
	public GameObject player;
	public GameObject officeWire;
	public GameObject FLight;
	public GameObject PLight;
	public GameObject SLight1;
	public GameObject SLight2;
	public GameObject CLight;
	public GameObject MainDoor;

	// text shown throughout the scene
	public Text messageText;
	public Text codeText;
	public Text vendingText;

	// two different images used
	public Image FadeBlack;
	public Image inventory;

	// multiple canvases used throughout the game
	public Canvas inventoryCanvas;
	public Canvas breakerBox;
	public Canvas printer;
	public Canvas computer;
	public Canvas vendingMachine;

	public Text timerText;
	float lastTime;
	int timeCount;

	int BEST_TIME = 240;

	public static OfficeManager Instance
	{
		get
		{
			return _instance;
		}
	}

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


	// Start is called before the first frame update
	void Start()
    {
		timeCount = 0;
		lastTime = Time.time;
		timerText.text = "Time: " + timeCount;

		// starting off disable all UI
		messageText.enabled = false;
		breakerBox.enabled = false;
		// this script is used later
		computer.GetComponent<ComputerScript>().enabled = false;
	}

    // Update is called once per frame
    void Update()
    {

		if (Time.time - lastTime >= 1) {
			lastTime = Time.time;
			timeCount++;
			timerText.text = "Time: " + timeCount;
		}
		// setting the text on the printer UI and vending UI
		codeText.text = codeValue;
		vendingText.text = vendingValue;

		if (codeValue.Equals("FSPSC"))
		{
			// if the user correct inputs the code
			computerOn = true;
			codeValue = "PC Unlocked";
		}
		if (codeValue.Length >= 6 && !computerOn)
		{
			// otherwise display error 
			OfficeAudio.PlaySound("ERROR");
			codeValue = "ERROR";
		}

		if (vendingValue.Equals("736945"))
		{
			// if the user correclty inputs the code
			ceoOffice = true;
			vendingValue = "Floor Unlocked";
		}
		if (vendingValue.Length >= 7 && !ceoOffice) 
		{
			// otherwise display error
			OfficeAudio.PlaySound("ERROR");
			vendingValue = "ERROR";
		}

		if (Input.GetKeyDown(KeyCode.I))
		{
			if (openInv == false && !computer.enabled)
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
	}

	public void UpElevator()
	{
		if (player.transform.position.y < 5)
		{
			// play the sound of going up the elevator
			OfficeAudio.PlaySound("elevator");
			// fade the screen black
			FadeOut();
			// move the player upwards
			player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 12);
		}
		else
		{
			// if the ceo office has been unlocked
			if (ceoOffice)
			{
				// play the sound of going up the elevator
				OfficeAudio.PlaySound("elevator");
				// fade the screen black
				FadeOut();
				// move the player up
				player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 12);
			}
			else
			{
				// send a message to the user
				messageText.text = "Can't get to that floor with the elevator buttons...";
				ShowHint();
			}
		}
	}

	public void DownElevator()
	{
		if (player.transform.position.y > -20)
		{
			// play the sound of going up the elevator
			OfficeAudio.PlaySound("elevator");
			// fade the screen black
			FadeOut();
			// move the player down
			player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 12);
		}
	}

	public void ChangeInventory(string item)
	{
		// change the inventory based off of what has been unlocked
		switch (item)
		{
			case "gun":
				inventory.transform.GetChild(0).GetComponent<Image>().enabled = true;
				break;
			case "key":
				inventory.transform.GetChild(1).GetComponent<Image>().enabled = true;
				break;
			case "USB":
				inventory.transform.GetChild(2).GetComponent<Image>().enabled = true;
				break;
		}
	}

	public void DisplayBreakerBox()
	{
		// opening the breaker box sound
		OfficeAudio.PlaySound("breaker");
		// setting the canvas to true
		breakerBox.enabled = true;
		// disable the players movement
		player.GetComponent<PlayerMovement>().enabled = false;
	}

	public void DisplayPrinter()
	{
		// turning on the printer sound
		OfficeAudio.PlaySound("computer");
		// setting the canvas to true
		printer.enabled = true;
		// disable the players movement
		player.GetComponent<PlayerMovement>().enabled = false;
	}

	public void DisplayComputer()
	{
		if (computerOn)
		{
			// turning on the computer sound
			OfficeAudio.PlaySound("computer");
			// setting the canvas to true
			computer.enabled = true;
			// removing controls from the player
			player.GetComponent<PlayerMovement>().enabled = false;
			// activating the computer script
			computer.GetComponent<ComputerScript>().enabled = true;
		}
		else
		{
			// show the hint to the player
			messageText.text = "This computer needs to be unlocked";
			ShowHint();
		}
	}

	public void DisplayVendingMachine()
	{
		// displaying the vending maching canvas to the user
		vendingMachine.enabled = true;
		player.GetComponent<PlayerMovement>().enabled = false;
	}

	public void FadeOut()
	{
		// remove controls from the player
		player.GetComponent<PlayerMovement>().enabled = false;
		// make the screen go black
		FadeBlack.enabled = true;
		// call the fade in method
		Invoke("FadeIn", 2.0f);
	}

	public void FadeIn()
	{
		// fade the screen back in
		FadeBlack.enabled = false;
		// give the player back their controls
		player.GetComponent<PlayerMovement>().enabled = true;
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
		if (PlayerPrefs.GetInt("LevelThreeTime") == 0 && timeCount < BEST_TIME) {
			PlayerPrefs.SetInt("LevelThreeTime", 1);
		}
		// end the game when the player esacpes
		Invoke("MainMenu", 4);
	}

	public void MainMenu()
	{
		// load the main menu
		SceneManager.LoadScene("MainMenu");
	}

	public void VendingButtonDown(string number)
	{
		// play the lightswitch sound
		OfficeAudio.PlaySound("lightswitch");
		// if it is equal to ERROR
		if (vendingValue.Equals("ERROR"))
		{
			// reset the value
			vendingValue = "";
		}
		if (!ceoOffice)
		{
			// add the integer to the number
			vendingValue += number;
		}
	}

	public void OpenMainDoor()
	{
		// destroy the main door
		Destroy(MainDoor);
	}

	public void ButtonDown()
	{
		// lightswitch sound
		OfficeAudio.PlaySound("lightswitch");


		// very complicated way to turn off and on the lights with buttons
		switch (EventSystem.current.currentSelectedGameObject.name)
		{
			case "L1 On":
				// get all the game objects with this tag
				GameObject[] L1On = GameObject.FindGameObjectsWithTag("L1");
				foreach (GameObject light in L1On)
				{
					// set all of the lights in that list to on/off
					light.transform.GetChild(0).gameObject.SetActive(true);
				}
				// hint lights used for the password to the computer
				FLight.SetActive(false);
				SLight1.SetActive(false);

				break;
			case "L1 Off":
				// get all the game objects with this tag
				GameObject[] L1Off = GameObject.FindGameObjectsWithTag("L1");
				foreach (GameObject light in L1Off)
				{
					// set all of the lights in that list to on/off
					light.transform.GetChild(0).gameObject.SetActive(false);
				}
				// hint lights used for the password to the computer
				FLight.SetActive(true);
				SLight1.SetActive(true);

				break;
			case "L2 On":
				// get all the game objects with this tag
				GameObject[] L2On = GameObject.FindGameObjectsWithTag("L2");
				foreach (GameObject light in L2On)
				{
					// set all of the lights in that list to on/off
					light.transform.GetChild(0).gameObject.SetActive(true);
				}
				// hint lights used for the password to the computer
				PLight.SetActive(false);
				SLight2.SetActive(false);

				break;
			case "L2 Off":
				// get all the game objects with this tag
				GameObject[] L2Off = GameObject.FindGameObjectsWithTag("L2");
				foreach (GameObject light in L2Off)
				{
					// set all of the lights in that list to on/off
					light.transform.GetChild(0).gameObject.SetActive(false);
				}
				// hint lights used for the password to the computer
				PLight.SetActive(true);
				SLight2.SetActive(true);

				break;
			case "L3 On":
				// get all the game objects with this tag
				GameObject[] L3On = GameObject.FindGameObjectsWithTag("L3");
				foreach (GameObject light in L3On)
				{
					// set all of the lights in that list to on/off
					light.transform.GetChild(0).gameObject.SetActive(true);
				}
				// hint lights used for the password to the computer
				CLight.SetActive(false);

				break;
			case "L3 Off":
				// get all the game objects with this tag
				GameObject[] L3Off = GameObject.FindGameObjectsWithTag("L3");
				foreach (GameObject light in L3Off)
				{
					// set all of the lights in that list to on/off
					light.transform.GetChild(0).gameObject.SetActive(false);
				}
				// hint lights used for the password to the computer
				CLight.SetActive(true);

				break;
		}
	}

	public void HasUSB()
	{
		// set the value for the USB stick
		if (!hasUSB)
		{
			hasUSB = true;
		}
		else
		{
			hasUSB = false;
		}
	}


	public void AddLetter(string letter)
	{
		// add a letter to the printer
		OfficeAudio.PlaySound("lightswitch");

		if (codeValue.Equals("ERROR"))
		{
			codeValue = "";
		}
		if (!computerOn)
		{
			codeValue += letter;
		}
	}

	public void LeaveUI()
	{
		// close out all of the UIs if they are ever active
		vendingMachine.enabled = false;
		printer.enabled = false;
		breakerBox.enabled = false;
		computer.enabled = false;
		player.GetComponent<PlayerMovement>().enabled = true;
		computer.GetComponent<ComputerScript>().enabled = false;
	}
}
