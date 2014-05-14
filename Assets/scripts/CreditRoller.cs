using UnityEngine;
using System.Collections;
using System.IO;

public class CreditRoller : MonoBehaviour {

	private ArrayList credit_text = new ArrayList();

	// Use this for initialization
	void Start () {

		try {
			
			StreamReader reader = new StreamReader( "Resources/credits.txt" );
			
			string line;
			int count = 0;

			GameObject temp = new GameObject( "credits" );
			
			MeshRenderer renderer = temp.AddComponent< MeshRenderer >();
			TextMesh mesh = temp.AddComponent< TextMesh >();
			
			temp.transform.position = new Vector3( 0, 0 );
			temp.transform.localScale = new Vector3( 0.2f, 0.2f );
			
			mesh.font = Resources.Load ( "Klavika-Medium" ) as Font;
			mesh.fontSize = 50;
			mesh.alignment = TextAlignment.Center;
			mesh.anchor = TextAnchor.UpperCenter;
			
			renderer.material = mesh.font.material;

			using( reader ) {
				
				line = reader.ReadLine ();

				while( line != null ) {

					if( line.Trim ().Length > 0 ) {

						bool is_title = false;

						is_title = ( line.Substring (0, 1) == "!" ) ? true : false;

						if( is_title ) {

							line = line.Remove ( 0, 1 );

						} else {

							line = "<size=40>" + line + "</size>";

						}

						mesh.text += line + '\n';

					} else {

						mesh.text += '\n';

					}
					
					line = reader.ReadLine ();
					count++;
					
				}
				
				reader.Close ();

			}
			
		} catch( IOException e ) {
			
			Debug.Log ( e.Message );
			
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		Camera.main.transform.Translate ( -Vector3.up * 0.05f );

	}

}
