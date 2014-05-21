using UnityEngine;
using System.Collections;

public class MouseLight : MonoBehaviour {
	
	//public Vector3 mousePosition;
	public GameObject mouseLight;
	// Use this for initialization
	private Vector3 WorldPos;

	void Start () {



		mouseLight = GameObject.Find ( "cursorLight" );

	}
	
	// Update is called once per frame
	void Update () {


		WorldPos = Camera.main.ScreenToWorldPoint ( new Vector3( Input.mousePosition.x, Input.mousePosition.y, 8.5f ) );
		//Vector3 mousePosition = camera.ScreenToWorldPoint (Input.mousePosition);
		//mouseLight.transform.Translate( WorldPos * Time.deltaTime);

		mouseLight.transform.position = WorldPos;

	}
}
