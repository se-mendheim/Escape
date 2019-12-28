using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseAudio : MonoBehaviour
{

	public static AudioClip climbLadder, itemPickup, closetDoor, woodBreak, openBook, toilet, activeCandle, deactiveCandle;
	public static AudioSource audioSrc;
	// Start is called before the first frame update
	void Start()
    {
		climbLadder = Resources.Load<AudioClip>("Wood Ladder");
		itemPickup = Resources.Load<AudioClip>("Item Pickup");
		closetDoor = Resources.Load<AudioClip>("Closet Door");
		woodBreak = Resources.Load<AudioClip>("Break Wood");
		openBook = Resources.Load<AudioClip>("Book Open");
		toilet = Resources.Load<AudioClip>("Toilet");
		activeCandle = Resources.Load<AudioClip>("Good Candle");
		deactiveCandle = Resources.Load<AudioClip>("Bad Candle");

		audioSrc = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public static void PlaySound(string clip)
	{
		switch (clip)
		{

			case "climb":
				audioSrc.PlayOneShot(climbLadder);
				break;
			case "item":
				audioSrc.PlayOneShot(itemPickup);
				break;
			case "book":
				audioSrc.PlayOneShot(openBook);
				break;
			case "closet":
				audioSrc.PlayOneShot(closetDoor);
				break;
			case "break":
				audioSrc.PlayOneShot(woodBreak);
				break;
			case "toilet":
				audioSrc.PlayOneShot(toilet);
				break;
			case "active":
				audioSrc.PlayOneShot(activeCandle);
				break;
			case "deactive":
				audioSrc.PlayOneShot(deactiveCandle);
				break;

		}
	}
}
