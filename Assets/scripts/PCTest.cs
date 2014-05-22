using UnityEngine;
using System.Collections;

public class PCTest : MonoBehaviour {

	private Vector3 CrosshairPos;

	public Material CrosshairMaterial;

	public GameObject Head;
	public GameObject Body;
	public GameObject GunMuzzle;

	// Use this for initialization
	void Start () {
	
		Transform camera = Camera.main.transform;

		camera.rotation = Quaternion.identity;

		camera.position = Head.transform.position + Vector3.back * 4;
		camera.position = camera.position + Vector3.left * 0.5f;
		//camera.position = camera.position + Vector3.down * 0.5f;
		//camera.parent = Body.transform;
		camera.parent = Body.transform.parent;

	}
	
	// Update is called once per frame
	void Update () {
	
		Transform camera = Camera.main.transform;

		float mouse_x = Input.GetAxis ( "Mouse X" );
		float mouse_y = Input.GetAxis ( "Mouse Y" );

		if( mouse_x != 0 ) {

			camera.RotateAround ( camera.position + camera.forward * 4, Vector3.up, mouse_x * 500 * Time.deltaTime );

		}

		if( mouse_y != 0 ) {

			camera.RotateAround ( camera.position + camera.forward * 4, camera.rotation * Vector3.left, mouse_y * 500 * Time.deltaTime );

		}

		RaycastHit hit;

		if( Physics.Raycast ( camera.position, camera.forward, out hit, 100 ) ) {

			Head.transform.LookAt ( hit.point );

			CrosshairPos = Camera.main.WorldToScreenPoint ( hit.point );

		} else {



		}

	}

	void OnGUI() {

		GUI.DrawTexture ( new Rect( CrosshairPos.x - 10, Screen.height - CrosshairPos.y - 10, 20, 20 ), CrosshairMaterial.mainTexture );

	}

}
