using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MineManagerScript : MonoBehaviour
{
    public static MineManagerScript _instance = null;

    bool openInv;

    public GameObject player;
    public GameObject lever;
    public GameObject breakStone;
    public GameObject chest1;
    public GameObject chest2;
    public GameObject breakBox;
    public GameObject dropLadder;

    public Text messageText;

    public Image FadeBlack;

    public Canvas inventoryCanvas;

    public static MineManagerScript Instance
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
        openInv = false;

        messageText.enabled = false;
        FadeBlack.enabled = false;

        lever.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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

    public void ClimbLadder(string ladder)
    {
        //Logic of ladder climbing depending on ladder number
        if (ladder.Equals("Ladder1"))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                FadeOut();
                player.transform.position = new Vector3(-35, 23, 0);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                FadeOut();
                player.transform.position = new Vector3(-38, 8, 0);
            }
        }
        else if (ladder.Equals("Ladder2"))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                FadeOut();
                player.transform.position = new Vector3(-2, 37, 0);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                FadeOut();
                player.transform.position = new Vector3(-3, 23, 0);
            }
        }
        else if (ladder.Equals("Ladder3"))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                FadeOut();
                player.transform.position = new Vector3(-7, 52, 0);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                FadeOut();
                player.transform.position = new Vector3(-3, 37, 0);
            }
        }
    }

    //Break object statements
    public void BreakBoxes()
    {
        Destroy(breakBox);
    }
    public void BreakStone()
    {
        Destroy(breakStone);
    }

    //Various display texts hints
    public void DropLadder()
    {
        dropLadder.transform.position = new Vector3(-33, 7, 0);
        messageText.enabled = true;
        messageText.text = "You hear a loud thud from above.";
        Invoke("DisableText", 10);
    }
    public void GetCrowbar()
    {
        messageText.enabled = true;
        messageText.text = "You got a crowbar. This can break boxes.";
        Invoke("DisableText", 10);
    }
    public void GetPick()
    {
        messageText.enabled = true;
        messageText.text = "You got a pick. This can break stone.";
        Invoke("DisableText", 10);
    }
    public void GetLever()
    {
        messageText.enabled = true;
        messageText.text = "You made a lever. This has to go somewhere...";
        Invoke("DisableText", 10);
    }

    //Stop displaying text
    public void DisableText()
    {
        // disable the messages to the screen
        messageText.enabled = false;
    }

    //Fade animation for ladder transitions
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

    public void ResetLevel()
    {
        SceneManager.LoadScene("LevelFour");
    }
    public void EndGame()
    {
        messageText.enabled = true;
        messageText.text = "You Escaped.";
        // end the game
        Invoke("MainMenu", 4);
    }
    public void MainMenu()
    {
        // load the main menu screen
        SceneManager.LoadScene("MainMenu");
    }


}
