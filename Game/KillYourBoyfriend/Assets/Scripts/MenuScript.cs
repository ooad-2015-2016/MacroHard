﻿using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
	private GUISkin skin;

	void Start()
	{
		// Load a skin for the buttons
		skin = Resources.Load("GUISkin") as GUISkin;
	}

	void OnGUI()
	{
		const int buttonWidth = 128;
		const int buttonHeight = 60;

		// Set the skin to use
		GUI.skin = skin;

		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect buttonRect = new Rect(
			3*Screen.width / 4 - (buttonWidth / 2),
			(Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
		);

		// Draw a button to start the game
		if(GUI.Button(buttonRect,"Start!"))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("Stage1");

		}
	}
}