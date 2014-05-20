using UnityEngine;
using System.Collections;

public class InGameUI : MonoBehaviour {

	public static Texture2D lineTex;
	
	private bool inOptionsMenu = false;
	private bool inInputSettings = false;
	private bool inVideoSettings = false;
	private bool inAudioSettings = false;
	private bool inKeyBindSettings = false;

	static private bool inEscapeMenu = false;
	static private bool inScoresMenu  = false;

	static private int playerCurrentHealth = 0;
	static private int playerTotalHealth = 0;

	static private int playerCurrentXP = 0;
	static private int playerTotalXP = 0;

	static private bool showSkillSelect = false;
	static private bool showSpecialSelect = false;

	static public bool IsEscapeMenuOpen() {
		return inEscapeMenu;
	}

	static public bool IsScoresMenuOpen(){
		return inScoresMenu;
		}

	static public void ToggleSkillsSelect() {
		showSkillSelect = !showSkillSelect;
	}

	static public void ToggleSpecialSelect() {
		showSpecialSelect = !showSpecialSelect;
	}

	static public void SetPlayerCurrentHealth( int health ) {
		playerCurrentHealth = health;
	}

	static public void SetPlayerTotalHealth( int health ) {
		playerTotalHealth = health;
	}
	
	static public void SetPlayerCurrentXP( int xp ) {
		playerCurrentXP = xp;
	}

	static public void SetPlayertotalXP( int xp ) {
		playerTotalXP = xp;
	}

	// Use this for initialization
	void Start () {
	


	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("escape")) {

			if (inOptionsMenu) {

				inOptionsMenu = false;
				inEscapeMenu = true;
			
			} else {

				inEscapeMenu = !inEscapeMenu;
			}

		}

		if(Input.GetKeyDown(KeyCode.Tab)){

			inScoresMenu = true;

		} else if(Input.GetKeyUp(KeyCode.Tab)){

			inScoresMenu = false ;
		}
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
		GUI.Box ( new Rect( 10, Camera.main.pixelHeight - 65, 300, 25 ), playerCurrentHealth + "/" + playerTotalHealth );
		GUI.Box ( new Rect( 10, Camera.main.pixelHeight - 35, 300, 25 ), playerCurrentXP + "/" + playerTotalXP );

		//Magazine, replace with animated controllable image
		GUI.Box ( new Rect( 330, Camera.main.pixelHeight - 65, 100, 55 ), "Magazine" );

		if( inEscapeMenu )
			GUI.Window (0, new Rect( Camera.main.pixelWidth / 2 - 50, Camera.main.pixelHeight / 2 - 50, 100, 100 ), EscapeMenu, "MENU" );

		if( inOptionsMenu )
			GUI.Window (1, new Rect( Camera.main.pixelWidth / 2 - 200, Camera.main.pixelHeight / 2 - 200, 400, 400 ), OptionsMenu, "Options" );

		if( inScoresMenu )
			GUI.Window (2, new Rect( Camera.main.pixelWidth / 2 - 200, Camera.main.pixelHeight / 2 - 250, 400, 400 ), ScoreMenu, "SCORE BOARD" );

	}

	void EscapeMenu( int windowId ) {

		if( GUI.Button (new Rect( 5, 40, 90, 25 ), "Options" ) ) {

			inOptionsMenu = true;
			inEscapeMenu = false;
			inVideoSettings = true;

		}

		if( GUI.Button (new Rect( 5, 70, 90, 25 ), "Exit Game" ) ) {
			Application.Quit ();
		}

	}
	// Scoreboard screen
	void ScoreMenu(int windowId){
		GUI.Label (new Rect (50, 20, 200, 120), "Name");
		GUI.Label (new Rect (180, 20, 200, 40), "Kills");
		GUI.Label (new Rect (250, 20, 200, 40), "Damage");



		}

	void OptionsMenu( int windowId ) {

		if( GUI.Button ( new Rect( 5, 20, 100, 25 ), "Video" ) ) {

			inVideoSettings = true;
			inAudioSettings = false;
			inInputSettings = false;
			inKeyBindSettings = false;

		}

		if( GUI.Button ( new Rect( 5, 50, 100, 25 ), "Audio" ) ) {
			
			inVideoSettings = false;
			inAudioSettings = true;
			inInputSettings = false;
			inKeyBindSettings = false;
			
		}

		if( GUI.Button ( new Rect( 5, 80, 100, 25 ), "Input" ) ) {
			
			inVideoSettings = false;
			inAudioSettings = false;
			inInputSettings = true;
			inKeyBindSettings = false;
			
		}

		if( inVideoSettings ) {

			GUI.Label ( new Rect( 120, 20, 200, 25 ), "Brightness" );
			Config.SetOption < float >( "brightness", GUI.HorizontalSlider ( new Rect( 120, 50, 200, 25 ), Config.GetOption< float >( "brightness" ), 0, 1 ) );

			GUI.Label ( new Rect( 120, 80, 200, 25 ), "Gamma" );
			Config.SetOption< float >( "gamma", GUI.HorizontalSlider ( new Rect( 120, 110, 200, 25 ), Config.GetOption< float >( "gamma" ), 0, 1 ) );

		}

		if( inAudioSettings ) {

			GUI.Label ( new Rect( 120, 20, 200, 25 ), "Sound Volume" );
			GUI.HorizontalSlider ( new Rect( 120, 50, 200, 25 ), 0, 0, 10 );
			
			GUI.Label ( new Rect( 120, 80, 200, 25 ), "Music Volume" );
			GUI.HorizontalSlider ( new Rect( 120, 110, 200, 25 ), 0, 0, 10 );

		}

		if( inInputSettings ) {

			GUI.Label ( new Rect( 120, 20, 200, 25 ), "Mouse Sensitivity" );
			GUI.HorizontalSlider ( new Rect( 120, 50, 200, 25 ), 0, 0, 10 );
			
			if( GUI.Button ( new Rect( 120, 80, 200, 25 ), "Change Keybinds" ) ) {

				inVideoSettings = false;
				inAudioSettings = false;
				inInputSettings = false;
				inKeyBindSettings = true;

			}

		}

		if( inKeyBindSettings ) {



		}

	}

}
