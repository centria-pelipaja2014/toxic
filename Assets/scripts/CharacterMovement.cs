using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public float sneakSpeed = 1.0F;
	public float normalSpeed = 6.0F;
	public float speed = 6.0F;

	public float jumpSpeed = 8.0F;

	public float gravity = 20.0F;



	private Vector3 moveDirection = Vector3.zero;

	void FixedUpdate () {

	}

	// Update is called once per frame
	void Update() {

		CharacterController controller = GetComponent<CharacterController>();
		if( !InGameUI.IsEscapeMenuOpen () ) {
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
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
		
	}
}
