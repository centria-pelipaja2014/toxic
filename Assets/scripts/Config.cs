using UnityEngine;
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

	void OnApplicationQuit() {

		try {

			FileStream temp = File.Open ( "Resources/config.txt", FileMode.Truncate );
			temp.Close ();

			StreamWriter writer = new StreamWriter ( "Resources/config.txt" );

			using (writer) {

				foreach( string key in options.Keys ) {

					writer.WriteLine ( "set " + key + " " + options[ key ] );

				}

				foreach( string key in keyBinds.Keys ) {

					string keyBind = keyBinds[ key ].ToString ();

					writer.WriteLine ( "bind " + key + " " + keyBind.Replace ( " ", "_" ) );
					
				}

				writer.Close ();

			}

		} catch( IOException e ) {

			Debug.Log ( e.Message );

		}

	}

	// Use this for initialization
	void Start () {

		options[ "resolutionX" ] = "1024";
		options[ "resolutionY" ] = "768";
		options[ "brightness" ] = "1";
		options[ "gamma" ] = "1";
		options[ "quality" ] = "3";
		options[ "fullscreen" ] = "true";

		keyBinds[ "forward" ] = "w";
		keyBinds[ "backward" ] = "s";
		keyBinds[ "strafe_left" ] = "a";
		keyBinds[ "strafe_right" ] = "d";

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

	static public string GetKeyBind( string action ) {

		if( !keyBinds.ContainsKey ( action ) ) return "";

		return keyBinds[ action ].ToString ();

	}

	static public T GetOption< T >( string option ) {

		if( !options.ContainsKey ( option ) ) return default( T );

		return (T)Convert.ChangeType ( options[ option ], typeof( T ) );

	}

}
