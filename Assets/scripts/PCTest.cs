using UnityEngine;
using System.Collections;

public class PCTest : MonoBehaviour {

	private Vector3 CrosshairPos;

	public GameObject Head;
	public GameObject GunMuzzle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		RaycastHit hit;

		if( Physics.Raycast ( GunMuzzle.transform.position, Head.transform.TransformDirection ( Vector3.forward ), out hit ) ) {

			CrosshairPos = Camera.main.WorldToScreenPoint ( hit.point );

			Debug.DrawRay ( GunMuzzle.transform.position, Head.transform.TransformDirection ( Vector3.forward ) * hit.distance );

		} else {

			CrosshairPos = Camera.main.WorldToScreenPoint ( Head.transform.TransformDirection ( Vector3.forward ) * 10000 );

			Debug.DrawRay ( GunMuzzle.transform.position, Head.transform.TransformDirection ( Vector3.forward ) * 10000 );

		}

	}

	void OnGUI() {

		GUI.Box ( new Rect( CrosshairPos.x, Screen.height - CrosshairPos.y, 20, 20 ), "" );

	}

}
