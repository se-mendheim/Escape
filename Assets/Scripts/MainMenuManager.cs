using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
		//Add in all of the achievements if they do not exist
		if (!PlayerPrefs.HasKey("LevelOneTime")) {
			PlayerPrefs.SetInt("LevelOneTime", 0);
		}
		if (!PlayerPrefs.HasKey("LevelTwoTime")) {
			PlayerPrefs.SetInt("LevelTwoTime", 0);
		}
		if (!PlayerPrefs.HasKey("LevelThreeTime")) {
			PlayerPrefs.SetInt("LevelThreeTime", 0);
		}


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
    }

	public void Level1Button()
	{
		// load level 1
		SceneManager.LoadScene("LevelOne");
	}
	public void Level2Button()
	{
		// load level 2
		SceneManager.LoadScene("LevelTwo");
	}

	public void Level3Button() {
		SceneManager.LoadScene("LevelThree");
	}

	public void AchievementsButton() {
		SceneManager.LoadScene("Achievements");
	}

	public void Level4Button() {
		SceneManager.LoadScene("LevelFour");
	}
}
