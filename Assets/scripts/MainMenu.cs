using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject CreditsPosition;
	public GameObject CreditManager;

	// Use this for initialization
	void Start () {
		//changeCameraPos("JoinGamePos");
		changeCameraPos ("MainMenuPos");
	
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			
			RaycastHit hit;
			
			Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );
			
			if( Physics.Raycast ( ray, out hit ) ) {
				
				switch( hit.collider.name ) {
					
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

				case "SelectText":
					changeCameraPos("ClassSelectionPos");
					break;

				case "BackText":
					changeCameraPos("MainMenuPos");
					break;

				case "cBackText":
					changeCameraPos("JoinGamePos");
					break;

				case "NoText":
					changeCameraPos("MainMenuPos");
					break;


				case "EYesText":
					Application.Quit();
					break;


				case "KeyBindingsText":
					changeCameraPos("KeyBindingsPos");
					break;

				case "VideoOptionsText":
					changeCameraPos("VideoOptionsPos");
					break;

				case "vBackText":
					changeCameraPos("OptionsPos");
					break;

				case "PlayText":
					Application.LoadLevel("Scene2");
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
	void changeCameraPos(string s1)
	{
		Vector3 p1 = GameObject.Find(s1).transform.position;
		Camera.main.transform.position = p1;
	}


}
