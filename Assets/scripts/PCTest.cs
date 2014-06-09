using UnityEngine;
using System.Collections;

public class PCTest : MonoBehaviour {

	private Animator animator;

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
	public GameObject GunMuzzle;

	private Vector2 CameraRotation = Vector3.zero;

	// Use this for initialization
	void Start () {

		animator = GetComponent< Animator >();

		CrosshairPos = new Vector3( Screen.width / 2, Screen.height / 2 );

	}
	
	// Update is called once per frame
	void Update () {

		float mouse_x = Input.GetAxis ( "Mouse X" );
		float mouse_y = Input.GetAxis ( "Mouse Y" );

		//Rotation of the camera around the Y-axis
		if( mouse_x != 0 ) {

			CameraRotation.y += mouse_x * 500 * Time.deltaTime;

		}

		//Rotation of the camera around the X and Z-axis
		if( mouse_y != 0 ) {

			CameraRotation.x -= mouse_y * 500 * Time.deltaTime;

			CameraRotation.x = Mathf.Clamp ( CameraRotation.x, -18, 26 );

		}

		//camera.rotation = Quaternion.Euler ( CameraRotation );

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

		animator.SetFloat ( "Speed", h*h+v*v );

		CharacterController controller = GetComponent<CharacterController>();
		if( !InGameUI.IsEscapeMenuOpen () ) {
			if (controller.isGrounded) {
				moveDirection = new Vector3(h, 0, v);
				moveDirection = transform.TransformDirection ( moveDirection );
				moveDirection *= speed;
				if (Input.GetButtonDown("Jump")) {
					moveDirection.y = jumpSpeed;
					animator.SetTrigger ("JumpTrigger");
				}
				if (Input.GetKey (KeyCode.LeftShift))
				{
					speed = sneakSpeed;
					animator.SetBool ( "IsCrouching", true );

				}
				else
				{
					speed = normalSpeed;
					animator.SetBool ( "IsCrouching", false );
				}
			}
		}
		
		moveDirection.y -= gravity * Time.smoothDeltaTime;
		controller.Move(moveDirection * Time.smoothDeltaTime);

		transform.rotation = Quaternion.Euler ( 0, CameraRotation.y, 0 );

	}

	void LateUpdate() {

		Transform camera = Camera.main.transform;

		camera.rotation = Quaternion.identity;
		camera.position = Head.transform.position - Vector3.forward * 3 - Vector3.right * 0.5f + Vector3.up * 0.5f;
		camera.RotateAround ( Head.transform.position, Vector3.right, CameraRotation.x );
		camera.RotateAround ( Head.transform.position, Vector3.up, CameraRotation.y );

		Head.transform.Rotate ( 0, -CameraRotation.x, 0 );

	}

	void OnGUI() {

		GUI.DrawTexture ( new Rect( CrosshairPos.x - 10, CrosshairPos.y - 10, 20, 20 ), CrosshairMaterial.mainTexture );

	}

}
