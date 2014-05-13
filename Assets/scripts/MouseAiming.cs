using UnityEngine;
using System.Collections;

public class MouseAiming : MonoBehaviour {

	//Objects and stuff

	public GameObject HeadObject; //Used for head angle
	public GameObject BodyObject; //Used for the body rotation

	//public float CameraDistance = 3F;
	//public float CameraHeight = 1F;


	//Sensitivety and other shit
	public bool InvertedY = false; //Enables inverted Y axis on mouse. Do not remove.

	public float SensitivityX = 500F;
	public float SensitivityY = 500F;
	
	public float MinimumX = -360F; //currently not used anywhere
	public float MaximumX = 360F; //currently not used anywhere
	
	public float MinimumY = -35F; //min Y angle
	public float MaximumY = 50F; //max Y angle
	
	float RotationY = 0F;
	float RotationX = 0F;

	/*
	// The target we are following
	private  Transform target;
	// The distance in the x-z plane to the target
	public float distance = 3.0F;
	// the height we want the camera to be above the target
	public float height = 2.0F;
	// How much we 
	public float heightDamping = 2.0F;
	public float rotationDamping = 0.6F;
	*/
	void Start ()
	{

		Camera.main.transform.parent = HeadObject.transform;

		//Screen.lockCursor= true;
		// Make the rigid body not change rotation
		//if (rigidbody)
			//rigidbody.freezeRotation = true;

	}

	void Update()
	{
		RotationX += Input.GetAxis ( "Mouse X" ) *SensitivityX*Time.deltaTime;

		if (InvertedY == false) 
		{
			
			RotationY += Input.GetAxis("Mouse Y")*SensitivityY*Time.deltaTime;
			
			RotationY = Mathf.Clamp(RotationY, MinimumY, MaximumY);
			
			BodyObject.transform.rotation = Quaternion.Euler(0,RotationX,0); //rotates the body
			HeadObject.transform.rotation = Quaternion.Euler(0,RotationX-90,RotationY-90); //rotates the head on Y axis with a clamp and also with X axis so it turns with the body
			
			
		} 
		
		else 
		{
			
			RotationY += Input.GetAxis("Mouse Y")*SensitivityY*Time.deltaTime;
			
			RotationY = Mathf.Clamp(RotationY, -MaximumY, -MinimumY);
			
			BodyObject.transform.rotation = Quaternion.Euler(0,RotationX,0); //rotates the body
			HeadObject.transform.rotation = Quaternion.Euler(0,RotationX-90,-RotationY-90); //rotates the head on Y axis with a clamp and also with X axis so it turns with the body
		}

	}
	/*
	void LateUpdate ()
	{

		Vector3 playerPOS = HeadObject.transform.position;
		Camera.main.transform.position = new Vector3(playerPOS.x, playerPOS.y, playerPOS.z - CameraDistance);

	}
	*/

	void  LateUpdate ()
	{
		/*
		target = HeadObject.transform;
		// Early out if we don't have a target
		if (!target) 
		{
			return;
		}
		else
		{
			// Calculate the current rotation angles
			float wantedRotationAngle = target.eulerAngles.y;
			float wantedHeight = target.position.y + height;
			
			float currentRotationAngle = transform.eulerAngles.y;
			float currentHeight = transform.position.y;
			
			// Damp the rotation around the y-axis
			currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
			
			// Damp the height
			currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
			
			// Convert the angle into a rotation
			Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
			
			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			Camera.main.transform.position = target.position;
			Camera.main.transform.position -= currentRotation * Vector3.forward * distance;
			
			// Set the height of the camera
			//Camera.main.transform.position.y = currentHeight;
			
			// Always look at the target
			Camera.main.transform.LookAt (target);

		}*/
	}
}
