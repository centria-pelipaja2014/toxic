using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject CreditsPosition;
	public GameObject CreditManager;



	// Use this for initialization
	void Start () {
		changeCameraPos ("MainMenuPos");
		/*
		Color color = renderer.material.color;
		color.a = 0.1f;
		renderer.material.color = color;
	*/
	}

	// Update is called once per frame
	void Update () {

			
			RaycastHit hit;
			
			Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );

			if( Physics.Raycast ( ray, out hit ) ) {


			switch(hit.collider.name){

			case "JoingameText":

				changeFontColor(GameObject.Find("JoingameText"));
				break;

			case "OptionsText":
				changeFontColor(GameObject.Find("OptionsText"));
				break;

			case "CreditsText":
				changeFontColor(GameObject.Find("CreditsText"));
				break;

			case "ExitText":
				changeFontColor(GameObject.Find("ExitText"));
				break;

			case "BackText":
				changeFontColor(GameObject.Find("BackText"));
				break;

			case "SelectText":
				changeFontColor(GameObject.Find("SelectText"));
				break;
			
			}


			if (Input.GetMouseButtonDown (0)) {
				
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

	void changeFontColor(GameObject gb)
	{
		Color color = renderer.material.color;
		color.a = 1f;
		gb.renderer.material.color = color;

		}


	void OnMouseExit() {

		Color color = renderer.material.color;
		color.a = 0.1f;

		GameObject.Find("JoingameText").renderer.material.color = color;
		GameObject.Find("OptionsText").renderer.material.color = color;
		GameObject.Find("CreditsText").renderer.material.color = color;
		GameObject.Find("ExitText").renderer.material.color = color;
		GameObject.Find("BackText").renderer.material.color = color;
		GameObject.Find("SelectText").renderer.material.color = color;


	}

}


























