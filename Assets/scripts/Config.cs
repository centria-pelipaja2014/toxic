﻿using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class Config : MonoBehaviour {

	/*
	 * 
	 * This script needs to be attached to some kind of Manager object.
	 * Otherwise it won't load the config.txt and the defaults below will be used instead.
	 * 
	 */

	static private Hashtable options = new Hashtable();
	static private Hashtable keyBinds = new Hashtable();

	// Use this for initialization
	void Start () {

		options[ "resolutionX" ] = 1024;
		options[ "resolutionY" ] = 768;
		options[ "brightness" ] = 1.0f;
		options[ "gamma" ] = 1.0f;
		options[ "quality" ] = 3;
		options[ "fullscreen" ] = true;

		keyBinds[ "up" ] = "w";
		keyBinds[ "down" ] = "s";
		keyBinds[ "left" ] = "a";
		keyBinds[ "right" ] = "d";

		keyBinds[ "select1" ] = "f1";
		keyBinds[ "select2" ] = "f2";
		keyBinds[ "select3" ] = "f3";
		keyBinds[ "select4" ] = "f4";
		keyBinds[ "select5" ] = "f5";
		keyBinds[ "select6" ] = "f6";

		keyBinds[ "jump" ] = "space";
		keyBinds[ "sneak" ] = "left shift";
		keyBinds[ "crouch" ] = "left control";

		keyBinds[ "attack" ] = "mouse 0";
		keyBinds[ "special" ] = "mouse 1";

		try {

			StreamReader reader = new StreamReader( "Resources/config.txt" );

			string line;

			using( reader ) {

				line = reader.ReadLine ();

				while( line != null ) {

					string[] entries = line.Split ( ' ' );
					if( entries.Length == 3 ) {

						string cmd = entries[0];

						if( cmd == "set" ) {

							string option = entries[1];
							string value = entries[2];

							if( options.ContainsKey ( option ) ) options[ option ] = value;

						} else if( cmd == "bind" ) {

							string action = entries[1];
							string key = entries[2];

							if( keyBinds.ContainsKey ( action ) ) keyBinds[ action ] = key.Replace ( "_", " " );

						}

					}

					line = reader.ReadLine ();

				}

				reader.Close ();

			}

		} catch( IOException e ) {

			Debug.Log ( e.Message );

		}

	}

	static string GetKeyBind( string action ) {

		if( keyBinds.ContainsKey ( action ) ) return keyBinds[ action ].ToString ();

		return "";

	}

	static float GetGamma() { return Convert.ToSingle ( options[ "gamma" ] ); }
	static float GetBrightness() { return Convert.ToSingle ( options[ "brightness" ] ); }
	static bool GetFullscreen() { return Convert.ToBoolean ( options[ "fullscreen" ] ); }
	static Vector2 GetResolution() { return new Vector2( Convert.ToSingle ( options[ "resolutionX" ] ), Convert.ToSingle( options[ "resolutionY" ] ) ); }
	static int GetQuality() {

		int quality = Convert.ToInt32 ( options[ "quality" ] );

		if( quality < 0 ) return 0;
		if( quality > QualitySettings.names.Length - 1 ) return QualitySettings.names.Length - 1;

		return quality;

	}

}
