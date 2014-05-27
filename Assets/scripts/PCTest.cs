using UnityEngine;
using System.Collections;

public class PCTest : MonoBehaviour {

	private float sneakSpeed = 1.0F;
	private float normalSpeed = 6.0F;
	private float speed = 6.0F;
	
	private float jumpSpeed = 8.0F;
	
	private float gravity = 20.0F;

	float h = 0, v = 0;
	
	private Vector3 moveDirection = Vector3.zero;

	private Vector3 CrosshairPos;
	private Vector3 CrosshairGUIPos;

	public Material CrosshairMaterial;

	public GameObject Head;
	public GameObject Legs;
	public GameObject GunMuzzle;

	int FastFloor( float value ) {

		return ( int )( value + 32768f ) - 32768;

	}

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

			camera.RotateAround ( Head.transform.position, Vector3.up, mouse_x * 500 * Time.deltaTime );

		}

		//Rotation of the camera around the X and Z-axis
		if( mouse_y != 0 ) {

			float normalized_x = camera.eulerAngles.x - mouse_y * 500 * Time.deltaTime;
			normalized_x = normalized_x - ( FastFloor ( ( normalized_x + 180 ) / 360 ) ) * 360;

			float x_clamped = Mathf.Clamp ( normalized_x, -18, 26 );
			camera.rotation = Quaternion.Euler ( x_clamped, camera.eulerAngles.y, camera.eulerAngles.z );

		}

		if( Input.GetKey ( Config.GetKeyBind ( "forward" ) ) )
			v = 1;
		else if( Input.GetKey ( Config.GetKeyBind ( "backward" ) ) )
			v = -1;
		else 
			v = 0;

		if( Input.GetKey ( Config.GetKeyBind ( "strafe_left" ) ) )
			h = -1;
		else if( Input.GetKey ( Config.GetKeyBind ( "strafe_right" ) ) )
			h = 1;
		else
			h = 0;

		if( v == 1 && h == -1 )
			Legs.transform.rotation = Quaternion.Euler ( 0, 45, 0 );

		if( v != 0 )
			gameObject.GetComponent< Animator >().SetBool ( "IsWalking", true );
		else
			gameObject.GetComponent< Animator >().SetBool ( "IsWalking", false );

		CharacterController controller = GetComponent<CharacterController>();
		if( !InGameUI.IsEscapeMenuOpen () ) {
			if (controller.isGrounded) {
				moveDirection = new Vector3(h, 0, v);
				moveDirection = transform.TransformDirection ( moveDirection );
				moveDirection *= speed;
				if (Input.GetButtonDown("Jump")) {
					moveDirection.y = jumpSpeed;
					gameObject.GetComponent< Animator >().SetTrigger ("JumpTrigger");
				}
				if (Input.GetKey (KeyCode.LeftShift))
				{
					speed = sneakSpeed;
					gameObject.GetComponent< Animator >().SetBool ( "IsCrouching", true );

				}
				else
				{
					speed = normalSpeed;
					gameObject.GetComponent< Animator >().SetBool ( "IsCrouching", false );
				}
			}
		}
		
		moveDirection.y -= gravity * Time.smoothDeltaTime;
		controller.Move(moveDirection * Time.smoothDeltaTime);

		RaycastHit hit;

		if( Physics.Raycast ( camera.position, camera.forward, out hit, 100 ) ) {

			CrosshairPos = Camera.main.WorldToScreenPoint ( hit.point );

		}

		Vector3 point = Camera.main.ScreenToWorldPoint ( CrosshairPos );
		Quaternion rot = Quaternion.LookRotation ( ( point - Head.transform.position ).normalized );

		Head.transform.rotation = Quaternion.Euler ( -rot.eulerAngles.x, transform.eulerAngles.y, rot.eulerAngles.z - 90 );
		transform.rotation = Quaternion.Euler ( 0, camera.eulerAngles.y, 0 );

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
