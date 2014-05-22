using UnityEngine;
using System.Collections;

public class PCTest : MonoBehaviour {

	private float sneakSpeed = 1.0F;
	private float normalSpeed = 6.0F;
	private float speed = 6.0F;
	
	private float jumpSpeed = 8.0F;
	
	private float gravity = 20.0F;
	
	
	
	private Vector3 moveDirection = Vector3.zero;

	private Vector3 CrosshairPos;

	public Material CrosshairMaterial;

	public GameObject Head;
	public GameObject GunMuzzle;

	// Use this for initialization
	void Start () {

		Transform camera = Camera.main.transform;

		camera.rotation = Quaternion.identity;

		camera.position = Head.transform.position + Vector3.back * 4f;
		camera.position = camera.position + Vector3.left * 0.5f;
		//camera.position = camera.position + Vector3.up * 2f;

	}
	
	// Update is called once per frame
	void Update () {
	
		Transform camera = Camera.main.transform;

		float mouse_x = Input.GetAxis ( "Mouse X" );
		float mouse_y = Input.GetAxis ( "Mouse Y" );

		//Rotation of the camera around the Y-axis
		if( mouse_x != 0 ) {
		
			camera.RotateAround ( camera.position + camera.forward * 4, Vector3.up, mouse_x * 500 * Time.deltaTime );

		}

		//Rotation of the camera around the X and Z-axis
		if( mouse_y != 0 ) {

			camera.RotateAround ( camera.position + camera.forward * 4, camera.rotation * Vector3.left, mouse_y * 500 * Time.deltaTime );

		}

		CharacterController controller = GetComponent<CharacterController>();
		if( !InGameUI.IsEscapeMenuOpen () ) {
			if (controller.isGrounded) {
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection ( moveDirection );
				moveDirection *= speed;
				if (Input.GetButtonDown("Jump"))
					moveDirection.y = jumpSpeed;
				if (Input.GetKey (KeyCode.LeftShift))
				{
					speed = sneakSpeed;
				}
				else
				{
					speed = normalSpeed;
				}
			}
		}
		
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		transform.rotation = Quaternion.Euler ( 0, Head.transform.eulerAngles.y, 0 );

		RaycastHit hit;

		if( Physics.Raycast ( camera.position, camera.forward, out hit, 100 ) ) {

			CrosshairPos = Camera.main.WorldToScreenPoint ( hit.point );

		}

		Head.transform.LookAt ( Camera.main.ScreenToWorldPoint ( CrosshairPos ) );
		Head.transform.Rotate ( 0, 0, -90 );

	}

	void LateUpdate() {

		Transform camera = Camera.main.transform;

		camera.position = Head.transform.position - camera.forward * 4f;
		camera.position = camera.position - camera.right * 0.5f;
		camera.position = camera.position + Vector3.up * 0.5f;

	}

	void OnGUI() {

		GUI.DrawTexture ( new Rect( CrosshairPos.x - 10, Screen.height - CrosshairPos.y - 10, 20, 20 ), CrosshairMaterial.mainTexture );

	}

}
