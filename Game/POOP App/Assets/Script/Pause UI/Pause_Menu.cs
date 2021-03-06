﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour {

	public static bool GamePaused = false;

	public GameObject pauseMenuUI;

	public GameObject UI;

	//public GameObject Joystick;

	
	
	// Update is called once per frame
	void Update ()
	{
		if( Input.GetKeyDown(KeyCode.Escape) )
		{
			if(GamePaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}

	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GamePaused = false;
		UI.SetActive(true);
		//Joystick.SetActive(true);
	}

	public void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GamePaused = true;
		UI.SetActive(false);
		//Joystick.SetActive(false);
	}

	public void Quit()
	{
		SceneManager.LoadScene("Main Menu");
	}
}
