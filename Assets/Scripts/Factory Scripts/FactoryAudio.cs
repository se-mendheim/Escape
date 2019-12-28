using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryAudio : MonoBehaviour
{
	public static AudioClip climbLadder, itemPickup, leverPull, generator, openDoor, wallSmash;
	static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
		climbLadder = Resources.Load<AudioClip>("Climb Ladder");
		itemPickup = Resources.Load<AudioClip>("Item Pickup");
		leverPull = Resources.Load<AudioClip>("Lever Pull");
		generator = Resources.Load<AudioClip>("Generator");
		openDoor = Resources.Load<AudioClip>("Door Open");
		wallSmash = Resources.Load<AudioClip>("Wall Smash");


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
			case "lever":
				audioSrc.PlayOneShot(leverPull);
				break;
			case "generator":
				audioSrc.PlayOneShot(generator);
				break;
			case "door":
				audioSrc.PlayOneShot(openDoor);
				break;
			case "smash":
				audioSrc.PlayOneShot(wallSmash);
				break;

		}
	}
}
