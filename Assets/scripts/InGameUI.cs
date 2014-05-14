using UnityEngine;
using System.Collections;

public class InGameUI : MonoBehaviour {

	public bool showSkillSelect = false;
	public bool showSpecialSelect = false;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void OnGUI() {

		if( showSkillSelect ) {

			GUI.Box ( new Rect( 10, 10, 60, 25 ), "Skill 1" );
			GUI.Box ( new Rect( 75, 10, 60, 25 ), "Skill 2" );
			GUI.Box ( new Rect( 140, 10, 60, 25 ), "Skill 3" );
			GUI.Box ( new Rect( 205, 10, 60, 25 ), "Skill 4" );

		}

		if( showSpecialSelect ) {

			GUI.Box ( new Rect( 290, 10, 75, 25 ), "Special 1" );
			GUI.Box ( new Rect( 370, 10, 75, 25 ), "Special 2" );

		}

		//Icons
		GUI.Box ( new Rect( 10, Camera.main.pixelHeight - 65 - 35, 30, 30 ), "IMG" );
		GUI.Box ( new Rect( 45, Camera.main.pixelHeight - 65 - 35, 30, 30 ), "IMG" );
		GUI.Box ( new Rect( 80, Camera.main.pixelHeight - 65 - 35, 30, 30 ), "IMG" );
		GUI.Box ( new Rect( 115, Camera.main.pixelHeight - 65 - 35, 30, 30 ), "IMG" );

		//Bars
		GUI.Box ( new Rect( 10, Camera.main.pixelHeight - 65, 300, 25 ), "CurrentHealth/TotalHealth" );
		GUI.Box ( new Rect( 10, Camera.main.pixelHeight - 35, 300, 25 ), "CurrentXP/TotalXP" );

		//Magazine, replace with animated controllable image
		GUI.Box ( new Rect( 330, Camera.main.pixelHeight - 65, 100, 55 ), "Magazine" );

	}

}
