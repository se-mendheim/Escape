using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

	public GameObject smallWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "DestroyWall")
		{
			// smashing the wall sound
			FactoryAudio.PlaySound("smash");

			Destroy(GameObject.FindGameObjectWithTag("DestroyWall"));

			for (int i = 0; i < 4; i++)
			{
				Instantiate(smallWall, new Vector2(4,14), Quaternion.identity);
			}
		}
	}
}
