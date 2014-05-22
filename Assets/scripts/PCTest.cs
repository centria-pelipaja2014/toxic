using UnityEngine;
using System.Collections;

public class PCTest : MonoBehaviour {

	private Vector3 CrosshairPos;

	public Material CrosshairMaterial;

	public GameObject Head;
	public GameObject GunMuzzle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		RaycastHit hit;
		
		if( Physics.Raycast ( Camera.main.transform.position, Head.transform.forward, out hit, 100 ) ) {

			CrosshairPos = Camera.main.WorldToScreenPoint ( hit.point );

			//Debug.DrawRay ( GunMuzzle.transform.position, Head.transform.forward * hit.distance );

		} else {

			CrosshairPos = Camera.main.WorldToScreenPoint ( Camera.main.transform.position + Head.transform.forward * 10 );

		}

	}

	void OnGUI() {

		GUI.DrawTexture ( new Rect( CrosshairPos.x - 10, Screen.height - CrosshairPos.y - 10, 20, 20 ), CrosshairMaterial.mainTexture );

	}

}
