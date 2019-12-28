using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool isPaused;
	public GameObject pauseMenuUI;

	// Start is called before the first frame update
	void Start()
	{
		isPaused = false;
	}

	// Update is called once per frame
	void Update()
	{
		// checking to see if the game was paused
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	void Resume()
	{
		// resume the game
		isPaused = false;
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1;
	}
	void Pause()
	{
		// pause the game
		isPaused = true;
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0;
	}

	public void ResumeGameClick()
	{
		Resume();
	}

	public void MainMenuClick()
	{
		// exit to main menu
		Time.timeScale = 1;
		isPaused = false;
		SceneManager.LoadScene("MainMenu");
	}
	
	public void QuitClick()
	{
		// quit the application
		Application.Quit();
	}
}
