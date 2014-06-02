using UnityEngine;
using System.Collections;
using System.IO;

public class MainMenu : MonoBehaviour {

	public GameObject CreditsPosition;
	public GameObject CreditManager;

	GUIText myGUIText ;


	// Use this for initialization
	void Start () {
		changeCameraPos ("MainMenuPos");

		Color color = renderer.material.color;
		color.a = 0.5f;
		// MAIN MENU
		GameObject.Find("JoingameText").renderer.material.color = color;
		GameObject.Find("OptionsText").renderer.material.color = color;
		GameObject.Find("CreditsText").renderer.material.color = color;
		GameObject.Find("ExitText").renderer.material.color = color;
		
		// JOIN GAME
		GameObject.Find("JBackText").renderer.material.color = color;
		GameObject.Find("JSelectText").renderer.material.color = color;
		
		//OPTIONS
		GameObject.Find ("SoundVolumeText").renderer.material.color = color;
		GameObject.Find ("VideoOptionsText").renderer.material.color = color;
		GameObject.Find ("MusicVolumeText").renderer.material.color = color;
		GameObject.Find ("KeyBindingsText").renderer.material.color = color;
		GameObject.Find ("OApplyText").renderer.material.color = color;
		GameObject.Find ("OBackText").renderer.material.color = color;
		
		// CREDITS
		GameObject.Find("EYesText").renderer.material.color = color;
		GameObject.Find("ENoText").renderer.material.color = color;
		
		// VIDEO OPTIONS
		GameObject.Find ("ResolutionText").renderer.material.color = color;
		GameObject.Find ("GammaText").renderer.material.color = color;
		GameObject.Find ("BrightnessText").renderer.material.color = color;
		GameObject.Find ("AntiAliasingText").renderer.material.color = color;
		GameObject.Find ("VBackText").renderer.material.color = color;
		GameObject.Find ("VApplyText").renderer.material.color = color;
		
		// KEY BINDINGS
		GameObject.Find ("KBackText").renderer.material.color = color;
		GameObject.Find ("KApplyText").renderer.material.color = color;
		
		
		// CLASS SELECTION
		GameObject.Find ("BruiserText").renderer.material.color = color;
		GameObject.Find ("SpeedFreakText").renderer.material.color = color;
		GameObject.Find ("AssassinText").renderer.material.color = color;
		GameObject.Find ("SniperText").renderer.material.color = color;
		GameObject.Find ("CBackText").renderer.material.color = color;
		GameObject.Find ("PlayText").renderer.material.color = color;

	}

	// Update is called once per frame
	void Update () {

			
			RaycastHit hit;
			
			Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );

			if( Physics.Raycast ( ray, out hit ) ) {

			switch(hit.collider.name){

				//------------------MAIN MENU---------------------------------

			case "JoingameText":
				changeFontAlpha(GameObject.Find("JoingameText"));
				break;

			case "OptionsText":
				changeFontAlpha(GameObject.Find("OptionsText"));
				break;

			case "CreditsText":
				changeFontAlpha(GameObject.Find("CreditsText"));
				break;

			case "ExitText":
				changeFontAlpha(GameObject.Find("ExitText"));
				break;

				//-----------------------JOIN GAME-----------------------------------------------------

			case "JBackText":
				changeFontAlpha(GameObject.Find("JBackText"));
				break;

			case "JSelectText":
				changeFontAlpha(GameObject.Find("JSelectText"));
				break;

				//---------------------------OPTIONS--------------------------------------------------

			case "SoundVolumeText":
				changeFontAlpha(GameObject.Find("SoundVolumeText"));
				break;

			case "VideoOptionsText":
				changeFontAlpha(GameObject.Find("VideoOptionsText"));
				break;

			case "MusicVolumeText":
				changeFontAlpha(GameObject.Find("MusicVolumeText"));
				break;

			case "KeyBindingsText":
				changeFontAlpha(GameObject.Find("KeyBindingsText"));
				break;

			case "OApplyText":
				changeFontAlpha(GameObject.Find("OApplyText"));
				break;

			case "OBackText":
				changeFontAlpha(GameObject.Find("OBackText"));
				break;

				//-------------------------EXIT----------------------------------------------------

			case "EYesText":
				changeFontAlpha(GameObject.Find("EYesText"));
				break;

			case "ENoText":
				changeFontAlpha(GameObject.Find("ENoText"));
				break;

				//----------------------------VIDEO OPTIONS-------------------------------------------------

			case "ResolutionText":
				changeFontAlpha(GameObject.Find("ResolutionText"));
				break;

			case "GammaText":
				changeFontAlpha(GameObject.Find("GammaText"));
				break;

			case "BrightnessText":
				changeFontAlpha(GameObject.Find("BrightnessText"));
				break;
				
			case "AntiAliasingText":
				changeFontAlpha(GameObject.Find("AntiAliasingText"));
				break;

			case "VBackText":
				changeFontAlpha(GameObject.Find("VBackText"));
				break;
				
			case "VApplyText":
				changeFontAlpha(GameObject.Find("VApplyText"));
				break;


				//-----------------------------KEY BINDINGS-----------------------------------------

			case "KBackText":
				changeFontAlpha(GameObject.Find("KBackText"));
				break;
				
			case "KApplyText":
				changeFontAlpha(GameObject.Find("KApplyText"));
				break;


				//-------------------------------CLASS SELECTION-----------------------------------------

			case "BruiserText":
				changeFontAlpha(GameObject.Find("BruiserText"));
				break;
				
			case "SpeedFreakText":
				changeFontAlpha(GameObject.Find("SpeedFreakText"));
				break;
				
			case "AssassinText":
				changeFontAlpha(GameObject.Find("AssassinText"));
				break;
				
			case "SniperText":
				changeFontAlpha(GameObject.Find("SniperText"));
				break;
				
			case "CBackText":
				changeFontAlpha(GameObject.Find("CBackText"));
				break;
				
			case "PlayText":
				changeFontAlpha(GameObject.Find("PlayText"));
				break;
			
			}



			if (Input.GetMouseButtonDown (0)) {
				
				switch( hit.collider.name ) {
				
					// ------------------- MAIN MENU----------------------------------

				case "JoingameText":
					changeCameraPos("JoinGamePos");
					break;

				case "OptionsText":
					changeCameraPos("OptionsPos");
					break;

				case "CreditsText":
					changeCameraPos("CreditsPos");
					CreditsPosition.SetActive(true);
					break;

				case "ExitText":
					changeCameraPos("ExitPos");
					break;

					//---------------------JOIN GAME--------------------------------------

				case "JSelectText":
					changeCameraPos("ClassSelectionPos");
					break;

				case "JBackText":
					changeCameraPos("MainMenuPos");
					break;

					//-------------------------------OPTIONS---------------------------------------
				case "KeyBindingsText":
					changeCameraPos("KeyBindingsPos");
					break;
					
				case "VideoOptionsText":
					changeCameraPos("VideoOptionsPos");
					break;

				case "OBackText":
					changeCameraPos("MainMenuPos");
					break;

				case "OApplyText":

					// Something
					break;


					//--------------------------EXIT------------------------------

				case "ENoText":
					changeCameraPos("MainMenuPos");
					break;
				
				case "EYesText":
					Application.Quit();
					break;

					//-----------------------VIDEO OPTION------------------
				

				case "VBackText":
					changeCameraPos("OptionsPos");
					break;

				case "VApplyText":

					// something
					break;


					//-------------------------KEY BINDINGS-------------------

				case "KBackText":
					changeCameraPos("OptionsPos");
					break;
					
				case "KApplyText":
					
					// something
					break;


					//------------------------- CLASS SELECTION------------------
				
				case "BruiserText":
					classDescription("Resources/bruiser.txt");

					break;

				case "AssassinText":
					classDescription("Resources/assasbin.txt");
					break;

				case "SpeedFreakText":
					classDescription("Resources/speedfreak.txt");
					break;

				case "SniperText":
					classDescription("Resources/sniper.txt");
					break;

				case "CBackText":
					changeCameraPos("JoinGamePos");
					GameObject.Find ("DescriptionText").guiText.enabled =false;
					break;

					
				case "PlayText":
					Application.LoadLevel("Scene2");
					GameObject.Find ("DescriptionText").guiText.enabled =false;
					break;


				}

			 }

			
		}



		if (CreditManager.activeInHierarchy) {
			
			if (Input.GetKeyDown (KeyCode.Space)) {
				CreditManager.SetActive (false);
				changeCameraPos("MainMenuPos");

			}
			
		}



	}

	// function to change the position of the camera
	void changeCameraPos(string s1)
	{
		Vector3 p1 = GameObject.Find(s1).transform.position;
		Camera.main.transform.position = p1;
	}

	// Function to change the alpha value of the color

	void changeFontAlpha(GameObject gb)
	{
		Color color = renderer.material.color;
		color.a = 1f;
		gb.renderer.material.color = color;

		}


	// function to display the text file content as gui text
	void classDescription(string filePath) {

		myGUIText = GameObject.Find ("DescriptionText").guiText;
		myGUIText.material.color = Color.yellow;
		myGUIText.fontSize = 12;
		myGUIText.fontStyle = FontStyle.Italic;


		try
		{
			using (StreamReader sr = new StreamReader( filePath))
			{
			string line = sr.ReadToEnd();
				myGUIText.text = line;
			}
		}
		catch (IOException e)
		{
			Debug.Log(e.Message);
		}
		
		Debug.Log ("BRUISER....");
		
	}
	

	void OnMouseExit() {

		Color color = renderer.material.color;
		color.a = 0.5f;
		// MAIN MENU
		GameObject.Find("JoingameText").renderer.material.color = color;
		GameObject.Find("OptionsText").renderer.material.color = color;
		GameObject.Find("CreditsText").renderer.material.color = color;
		GameObject.Find("ExitText").renderer.material.color = color;

		// JOIN GAME
		GameObject.Find("JBackText").renderer.material.color = color;
		GameObject.Find("JSelectText").renderer.material.color = color;

		//OPTIONS
		GameObject.Find ("SoundVolumeText").renderer.material.color = color;
		GameObject.Find ("VideoOptionsText").renderer.material.color = color;
		GameObject.Find ("MusicVolumeText").renderer.material.color = color;
		GameObject.Find ("KeyBindingsText").renderer.material.color = color;
		GameObject.Find ("OApplyText").renderer.material.color = color;
		GameObject.Find ("OBackText").renderer.material.color = color;

		// CREDITS
		GameObject.Find("EYesText").renderer.material.color = color;
		GameObject.Find("ENoText").renderer.material.color = color;

		// VIDEO OPTIONS
		GameObject.Find ("ResolutionText").renderer.material.color = color;
		GameObject.Find ("GammaText").renderer.material.color = color;
		GameObject.Find ("BrightnessText").renderer.material.color = color;
		GameObject.Find ("AntiAliasingText").renderer.material.color = color;
		GameObject.Find ("VBackText").renderer.material.color = color;
		GameObject.Find ("VApplyText").renderer.material.color = color;

		// KEY BINDINGS
		GameObject.Find ("KBackText").renderer.material.color = color;
		GameObject.Find ("KApplyText").renderer.material.color = color;


		// CLASS SELECTION
		GameObject.Find ("BruiserText").renderer.material.color = color;
		GameObject.Find ("SpeedFreakText").renderer.material.color = color;
		GameObject.Find ("AssassinText").renderer.material.color = color;
		GameObject.Find ("SniperText").renderer.material.color = color;
		GameObject.Find ("CBackText").renderer.material.color = color;
		GameObject.Find ("PlayText").renderer.material.color = color;

	}
}


























