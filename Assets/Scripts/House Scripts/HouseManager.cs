using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HouseManager : MonoBehaviour
{
	// boolean variable for inventory
	bool openInv = false;

	// creating the singleton
	public static HouseManager _instance = null;

	// GameObjects used throughout the scene
	public GameObject player;
	public GameObject Rope;
	public GameObject Sword;
	public GameObject LibraryDoor;
	public GameObject BalconyDoor;
	public GameObject GreenBook;
	public GameObject BlueBook;
	public GameObject RedBook;
	public GameObject RopeLadder;
	public GameObject piano;
	public GameObject woodWall;

	// sprites for the book activated/disabled
	public Sprite disabledSpriteBook;
	public Sprite activeSpriteBook;

	// message text that was displayed
	public Text messageText;
	public Image FadeBlack;
	public Image inventory;
	public Canvas inventoryCanvas;

	public Text timerText;

	float lastTime;
	int timeCount;
	int BEST_TIME = 200;

	// return the instance of the singleton
	public static HouseManager Instance
	{
		get
		{
			return _instance;
		}
	}
	// Start is called before the first frame update
	void Start()
    {
		messageText.enabled = false;
		FadeBlack.enabled = false;
		timeCount = 0;
		lastTime = Time.time;
		timerText.text = "Time: " + timeCount;
	}

    // Update is called once per frame
    void Update()
    {
		if (Time.time - lastTime > 1) {
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

	public void ClimbLadder(string ladder)
	{
		// if statements to check for the correct ladder
		if (ladder.Equals("Ladder1"))
		{
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				// climing the ladder
				HouseAudio.PlaySound("climb");

				// fade the screen to black
				FadeOut();

				// move the player up the ladder
				player.transform.position = new Vector3(-38, -22, 0);
			}
			else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				// climing the ladder
				HouseAudio.PlaySound("climb");

				// fade the screen to black
				FadeOut();

				// move the player down the ladder
				player.transform.position = new Vector3(-38, -33, 0);
			}
		}
		else if (ladder.Equals("Ladder2"))
		{
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				// climing the ladder
				HouseAudio.PlaySound("climb");

				// fade the screen to black
				FadeOut();

				// move the player up the ladder
				player.transform.position = new Vector3(-24, -13, 0);
			}
			else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				// climing the ladder
				HouseAudio.PlaySound("climb");

				// fade the screen to black
				FadeOut();

				// move the player down the ladder
				player.transform.position = new Vector3(-24, -22, 0);
			}
		}
		else if (ladder.Equals("Ladder3"))
		{
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				// climing the ladder
				HouseAudio.PlaySound("climb");

				// fade the screen to black
				FadeOut();

				// move the player up the ladder
				player.transform.position = new Vector3(24, -13, 0);
			}
			else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				// climing the ladder
				HouseAudio.PlaySound("climb");

				// fade the screen to black
				FadeOut();

				// move the player down the ladder
				player.transform.position = new Vector3(24, -22, 0);
			}
		}
		else if (ladder.Equals("Ladder4"))
		{
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				// climing the ladder
				HouseAudio.PlaySound("climb");

				// fade the screen to black
				FadeOut();

				// move the player up the ladder
				player.transform.position = new Vector3(37, -22, 0);
			}
			else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				// climing the ladder
				HouseAudio.PlaySound("climb");

				// fade the screen to black
				FadeOut();

				// move the player down the ladder
				player.transform.position = new Vector3(37, -33, 0);
			}
		}
	}

	public void ChangeInventory(string item)
	{
		switch (item)
		{
			case "sword":
				inventory.transform.GetChild(0).GetComponent<Image>().enabled = true;
				break;
			case "closetKey":
				inventory.transform.GetChild(1).GetComponent<Image>().enabled = true;
				break;
			case "rope":
				inventory.transform.GetChild(2).GetComponent<Image>().enabled = true;
				break;
			case "hint":
				inventory.transform.GetChild(3).GetComponent<Image>().enabled = true;
				break;
		}
	}

	public void DestroyWood()
	{
		Destroy(GameObject.FindGameObjectWithTag("BreakableWood"));

		for (int i =0; i < 4; i++)
		{
			Instantiate(woodWall, new Vector2(-31, -11), Quaternion.identity);
		}
	}

	public void SetCandleS()
	{
		GameObject.FindGameObjectWithTag("S").transform.GetChild(0).gameObject.SetActive(false);
		GameObject.FindGameObjectWithTag("S").transform.GetChild(1).gameObject.SetActive(false);
		GameObject.FindGameObjectWithTag("S").transform.GetChild(2).gameObject.SetActive(false);
	}

	public void SetCandleT()
	{
		GameObject.FindGameObjectWithTag("T").transform.GetChild(0).gameObject.SetActive(false);
		GameObject.FindGameObjectWithTag("T").transform.GetChild(1).gameObject.SetActive(false);
		GameObject.FindGameObjectWithTag("T").transform.GetChild(2).gameObject.SetActive(false);
	}

	public void SetCandleE()
	{
		GameObject.FindGameObjectWithTag("E").transform.GetChild(0).gameObject.SetActive(false);
		GameObject.FindGameObjectWithTag("E").transform.GetChild(1).gameObject.SetActive(false);
		GameObject.FindGameObjectWithTag("E").transform.GetChild(2).gameObject.SetActive(false);
	}

	public void SetCandleActiveE()
	{
		GameObject.FindGameObjectWithTag("E").transform.GetChild(0).gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag("E").transform.GetChild(1).gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag("E").transform.GetChild(2).gameObject.SetActive(true);
	}

	public void SetCandleV()
	{
		GameObject.FindGameObjectWithTag("V").transform.GetChild(0).gameObject.SetActive(false);
		GameObject.FindGameObjectWithTag("V").transform.GetChild(1).gameObject.SetActive(false);
		GameObject.FindGameObjectWithTag("V").transform.GetChild(2).gameObject.SetActive(false);
	}

	public void SetActiveCandles()
	{
		GameObject.FindGameObjectWithTag("S").transform.GetChild(0).gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag("S").transform.GetChild(1).gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag("S").transform.GetChild(2).gameObject.SetActive(true);

		GameObject.FindGameObjectWithTag("T").transform.GetChild(0).gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag("T").transform.GetChild(1).gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag("T").transform.GetChild(2).gameObject.SetActive(true);

		GameObject.FindGameObjectWithTag("E").transform.GetChild(0).gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag("E").transform.GetChild(1).gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag("E").transform.GetChild(2).gameObject.SetActive(true);

		GameObject.FindGameObjectWithTag("V").transform.GetChild(0).gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag("V").transform.GetChild(1).gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag("V").transform.GetChild(2).gameObject.SetActive(true);
	}

	public void FadeOut()
	{
		// play the ladder climbing sound
		//FactoryAudio.PlaySound("climb");
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

	public void ShowHint()
	{
		// display messages to the screen
		messageText.enabled = true;
		Invoke("DisableText", 10);
	}
	public void DisableText()
	{
		// disable the messages to the screen
		messageText.enabled = false;
	}
	public void DropRope()
	{
		// drop the rope from the ceiling
		Rope.SetActive(true);
	}
	public void DestroyRope()
	{
		// destroy the rope when picked up
		Destroy(Rope);
	}
	public void DestroySword()
	{
		// destroy the sword when picked up
		Destroy(Sword);
	}
	public void DestroyLibraryDoor()
	{
		// destroy the library door
		Destroy(LibraryDoor);
	}
	public void DestroyBalconyDoor()
	{
		// destroy the balcony door
		Destroy(BalconyDoor);
	}
	public void OpenBook(char B)
	{
		// logic for all of the books
		if (B == 'G')
		{
			// if the player clickes the green book set to active
			GreenBook.GetComponent<SpriteRenderer>().sprite = activeSpriteBook;
		}
		else if (B == 'R')
		{
			// if the player clicks the red book set to active
			RedBook.GetComponent<SpriteRenderer>().sprite = activeSpriteBook;
		}
		else if (B == 'B')
		{
			// if the player clicks the blue book set to active
			BlueBook.GetComponent<SpriteRenderer>().sprite = activeSpriteBook;
		}
	}
	public void ResetBooks()
	{
		// reseting all of the book sprites
		RedBook.GetComponent<SpriteRenderer>().sprite = disabledSpriteBook;
		GreenBook.GetComponent<SpriteRenderer>().sprite = disabledSpriteBook;
		BlueBook.GetComponent<SpriteRenderer>().sprite = disabledSpriteBook;
	}
	public void ActivateRopeLadder()
	{
		// activate the rope ladder to let the player escape
		RopeLadder.SetActive(true);
	}
	public void PlayPiano()
	{
		piano.GetComponent<AudioSource>().enabled = true;
	}
	public void EndGame()
	{
		//check for achievements
		if (PlayerPrefs.GetInt("LevelTwoTime") == 0 && timeCount < BEST_TIME) {
			PlayerPrefs.SetInt("LevelTwoTime", 1);
		}
		// end the game
		Invoke("MainMenu", 4);
	}

	public void MainMenu()
	{
		// load the main menu screen
		SceneManager.LoadScene("MainMenu");
	}
}
