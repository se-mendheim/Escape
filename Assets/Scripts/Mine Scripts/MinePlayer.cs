using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePlayer : MonoBehaviour
{
    bool hasPick;
    bool hasCrowbar;
    bool hasLever;

    int keyCount;

    // Start is called before the first frame update
    void Start()
    {
        hasPick = false;
        hasCrowbar = false;
        hasLever = false;

        keyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Ladder climbing depending on tag
        if (collision.gameObject.CompareTag("Ladder1"))
        {
            MineManagerScript._instance.ClimbLadder("Ladder1");
            //Debug.Log("Touch Ladder 1");
        }
        else if (collision.gameObject.CompareTag("Ladder2"))
        {
            MineManagerScript._instance.ClimbLadder("Ladder2");
            //Debug.Log("Touch Ladder 2");
        }
        else if (collision.gameObject.CompareTag("Ladder3"))
        {
            MineManagerScript._instance.ClimbLadder("Ladder3");
            //Debug.Log("Touch Ladder 3");
        }

        //Open chest1 with key
        if (collision.gameObject.CompareTag("MineChest1") && keyCount > 0)
        {
            Debug.Log("Touch Chest 1");
            if (Input.GetKeyDown(KeyCode.E)) { 
                hasCrowbar = true;
                //Debug.Log("Player has Crowbar");
                MineManagerScript._instance.GetCrowbar();
                collision.gameObject.SetActive(false);
                keyCount--;
            }
        }
        //Open chest2 with key
        if (collision.gameObject.CompareTag("MineChest2") && keyCount > 0)
        {
            Debug.Log("Touch Chest 2");
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasPick = true;
                //Debug.Log("Player has Pick");
                MineManagerScript._instance.GetPick();
                collision.gameObject.SetActive(false);
                keyCount--;
            }
            else
            {

            }
        }

        //Destroy corner box to get to chest2
        if (collision.gameObject.CompareTag("MineBoxes") && hasCrowbar)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MineManagerScript._instance.BreakBoxes();
            }
        }
        //Break big stone to make lever
        if (collision.gameObject.CompareTag("MineStone") && hasPick)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MineManagerScript._instance.BreakStone();
                hasLever = true;
                MineManagerScript._instance.GetLever();
            }
        }
        //Put lever in place and pull to move ladder
        if (collision.gameObject.CompareTag("MineLever") && hasLever)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MineManagerScript._instance.lever.SetActive(true);
                MineManagerScript._instance.DropLadder();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Grab keys
        if (collision.gameObject.CompareTag("MineKey"))
        {
            //Debug.Log("Get Key");
            collision.gameObject.SetActive(false);
            keyCount++;
        }
        //Die and reset level
        if (collision.gameObject.CompareTag("MineSpikes"))
        {
            MineManagerScript._instance.ResetLevel();
        }
        //Enter cart and win game
        if (collision.gameObject.CompareTag("MineCart"))
        {
            //Debug.Log("Game Won");
            MineManagerScript._instance.EndGame();
        }
    }
}
