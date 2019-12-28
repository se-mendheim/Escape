using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeAudio : MonoBehaviour
{
	// different sounds throughout the game
	public static AudioClip itemPickup, elevator, openBreaker, lightSwitch, ERROR, computerStart, gunShot;
	// audio source for all of the sounds
	public static AudioSource audioSrc;
	
	// Start is called before the first frame update
	void Start()
    {
		// loading up all of the different sounds
		itemPickup = Resources.Load<AudioClip>("Item Pickup");
		elevator = Resources.Load<AudioClip>("Elevator");
		openBreaker = Resources.Load<AudioClip>("Breaker Open");
		lightSwitch = Resources.Load<AudioClip>("Lightswitch");
		ERROR = Resources.Load<AudioClip>("Bad Candle");
		computerStart = Resources.Load<AudioClip>("Computer Start");
		gunShot = Resources.Load<AudioClip>("Gunshot");

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
			// play whichever sound is requested
			case "item":
				audioSrc.PlayOneShot(itemPickup);
				break;
			case "elevator":
				audioSrc.PlayOneShot(elevator);
				break;
			case "breaker":
				audioSrc.PlayOneShot(openBreaker);
				break;
			case "lightswitch":
				audioSrc.PlayOneShot(lightSwitch);
				break;
			case "ERROR":
				audioSrc.PlayOneShot(ERROR);
				break;
			case "computer":
				audioSrc.PlayOneShot(computerStart);
				break;
			case "gunshot":
				audioSrc.PlayOneShot(gunShot);
				break;
		}
	}
}
