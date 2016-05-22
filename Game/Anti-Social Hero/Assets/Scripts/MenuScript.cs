using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
	private GUISkin skin;

	void Start()
	{
		skin = Resources.Load("GUISkin") as GUISkin;
	}

	void OnGUI()
	{
		const int buttonWidth = 138;
		const int buttonHeight = 70;

		GUI.skin = skin;

		Rect buttonRect = new Rect(
			2*Screen.width / 3 - (1*buttonWidth/3)+20,
			(Screen.height / 3) - (buttonHeight /2)-10,
			buttonWidth,
			buttonHeight
		);
		Rect buttonRect2 = new Rect(
			2*Screen.width / 3 - (1*buttonWidth/3)+20,
			(2*Screen.height / 3) - (buttonHeight )-40,
			buttonWidth,
			buttonHeight
		);
		Rect buttonRect3 = new Rect(
			2*Screen.width / 3 - (1*buttonWidth/3)+20,
			(Screen.height) - (buttonHeight )-100,
			buttonWidth,
			buttonHeight
		);

		if(GUI.Button(buttonRect,"Normal mode"))
		{
			Application.LoadLevel("Stage1");

		}
		if(GUI.Button(buttonRect2,"Dubstep mode"))
		{
			Application.LoadLevel("Stage2");

		}
		if(GUI.Button(buttonRect3,"Exit"))
		{
			Application.Quit();
		}
	}
	void Update() {
		if (Input.GetKey("escape"))
			Application.Quit();

	}
}