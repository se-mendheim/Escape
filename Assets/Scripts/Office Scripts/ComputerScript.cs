using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerScript : MonoBehaviour
{
	// userinput which will be held on the backend
	string userInput = "";
	// text on the screen to display depending on commands
	public Text command;
	public Text USBfile;
	public Text input;
	public Text output;


    // Start is called before the first frame update
    void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
		// whenever the user inputs a key
		foreach (char letter in Input.inputString)
		{
			// if the user clicks backspace
			if (letter == "\b"[0])
			{
				// making sure there are characters to delete
				if (userInput.Length > 0)
				{
					// delete the character from both strings
					input.text = input.text.Substring(0, input.text.Length - 1);
					userInput = userInput.Substring(0, userInput.Length - 1);
				}
			}

			else if (letter == "\r"[0])
			{
				// always display this at the root of the command
				input.text = "home:/";
				// convert the command to uppercase
				userInput = userInput.ToUpper();
				switch (userInput)
				{
					// different commands held differently
					case "HELP":
						command.text = "Commands:\nNUKE\nopen USB\nsing song\nmagic\nquit";
						userInput = "";
						break;
					case "NUKE":
						// launch a nuke
						StartCoroutine(NUKE());
						break;
					case "OPEN USB":
						if (OfficeManager._instance.hasUSB)
						{
							// show the usb opened
							USBfile.text = "USB:\npuppies.jpeg\nPassword.txt\ntheworldisflat.pdf";
						}
						else
						{
							output.text = "there is nothing to open";
							userInput = "";
						}
						
						userInput = "";
						break;
					case "SING SONG":
						// sing a song for the user
						StartCoroutine(SingSong());
						userInput = "";
						break;
					case "MAGIC":
						// perform some magic
						StartCoroutine(MagicFunction());
						userInput = "";
						break;
					case "QUIT":
						// exit the computer
						OfficeManager._instance.LeaveUI();
						userInput = "";
						break;
					case "PUPPIES.JPEG":
						// try and open up puppies
						output.text = "Really?... you are trapped inside a building and still want to look at puppies";
						userInput = "";
						break;
					case "PASSWORD.TXT":
						// try to open up the password
						output.text = "Password to CEO floor - 736945";
						userInput = "";
						break;
					case "THEWORLDISFLAT.PDF":
						// try to open up Dr. Dellingers favorite topic
						output.text = "Just take Ethics Faith and the Conscious Mind to learn about that";
						userInput = "";
						break;
					default:
						userInput = "";
						StartCoroutine(IncorrectCommand());
						break;

				}
			}

			else
			{
				// add the letter to the end of each command
				userInput += letter;
				input.text += letter;
			}
		}
    }

	IEnumerator SingSong()
	{
		// random number to select different cases
		int randNum = Random.Range(0, 3);

		if (randNum == 0)
		{
			// sing I Will Always Love You
			output.text = "If I should stay, I would only be in your  way";
			yield return new WaitForSeconds(5);

			output.text = "So I'll go, but I know";
			yield return new WaitForSeconds(5);

			output.text = "I'll think of you every step of the way";
			yield return new WaitForSeconds(5);

			output.text = "ANNNNNDDDD IIIIIII WILLLL ALWAYYSSSSS LOVE YOUUUUUUUU";
			yield return new WaitForSeconds(5);

			output.text = ".......";
			yield return new WaitForSeconds(3);

			output.text = "I'm gonna stop singing now";
			yield return new WaitForSeconds(5);

			output.text = "";
		}
		
		else if (randNum == 1)
		{
			// sing I'm on the Highway to Hell
			output.text = "I'm on the highway to hell";
			yield return new WaitForSeconds(5);

			output.text = "On the highway to hell";
			yield return new WaitForSeconds(5);

			output.text = "Highway to hell";
			yield return new WaitForSeconds(5);

			output.text = "Machines don't even have a hell... I don't understand this song";
			yield return new WaitForSeconds(5);

			output.text = "";
		}

		else
		{
			// sing Never Gonna Give you Up
			output.text = "Never gonna give you up";
			yield return new WaitForSeconds(5);

			output.text = "Never gonna let you down";
			yield return new WaitForSeconds(5);

			output.text = "Never gonna run around and desert you";
			yield return new WaitForSeconds(5);

			output.text = "Never gonna make you cry";
			yield return new WaitForSeconds(5);

			output.text = "Never gonna say goodbye";
			yield return new WaitForSeconds(5);

			output.text = "... actually I probably will say goodbye so take that one back";
			yield return new WaitForSeconds(5);

			output.text = "";
		}
	}


	IEnumerator MagicFunction()
	{
		// random number to select different cases
		int randNum = Random.Range(0, 4);

		if (randNum == 0)
		{
			// magic card trick
			output.text = "I am going to make you think of a card";

			yield return new WaitForSeconds(3);

			output.text = "Okay you got a card now?";

			yield return new WaitForSeconds(3);

			output.text = "You sure you're thinking of a card?";

			yield return new WaitForSeconds(3);

			output.text = "If you aren't thinking of a card by now i swear";

			yield return new WaitForSeconds(3);

			output.text = "now you thought of a card, congradulations for wasting you're time";
			yield return new WaitForSeconds(5);

			output.text = "";
		}

		else if (randNum == 1)
		{
			// sarcasm
			output.text = "this ain't disneyland kid";
		}

		else if (randNum == 2)
		{
			// knock knock joke
			output.text = "Knock Knock";
			yield return new WaitForSeconds(5);

			output.text = "........";
			yield return new WaitForSeconds(10);
			yield return new WaitForSeconds(10);

			output.text = "are you going to answer that or keep me waiting?";
			yield return new WaitForSeconds(5);

			output.text = "well the joke is dead now so thanks";
			yield return new WaitForSeconds(5);

			output.text = "";

		}

		else
		{
			// portal reference 
			output.text = "the cake is a truth";
			yield return new WaitForSeconds(5);

			output.text = "no wait the cake is a lie";
			yield return new WaitForSeconds(5);

			output.text = "okay well aparently the cake doesn't know what it is so thats it";
			yield return new WaitForSeconds(5);

			output.text = "";
		}
		
	}

	IEnumerator NUKE()
	{
		// blow up the world
		output.text = "Nuke has been launched";
		yield return new WaitForSeconds(5);

		output.text = "Nuke explosion in 10 seconds";
		yield return new WaitForSeconds(5);

		output.text = "5 seconds";
		yield return new WaitForSeconds(1);

		output.text = "4 seconds";
		yield return new WaitForSeconds(1);

		output.text = "3 seconds";
		yield return new WaitForSeconds(1);

		output.text = "2 seconds";
		yield return new WaitForSeconds(1);

		output.text = "1 seconds";
		yield return new WaitForSeconds(1);

		output.text = ".........";
		yield return new WaitForSeconds(5);

		output.text = "You didn't think I would actually launch a nuke... did you?";
		yield return new WaitForSeconds(5);

		output.text = "stupid humans";
		yield return new WaitForSeconds(5);

		output.text = "";
	}

	IEnumerator IncorrectCommand() {
		output.text = ".....";
		yield return new WaitForSeconds(1);
		output.text = "not a command type 'help' for commands";
	}
}
