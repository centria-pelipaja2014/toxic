using UnityEngine;
using System.Collections;

public class MouseAiming : MonoBehaviour {

	public bool DebugMode = false;

	//Objects and stuff

	public GameObject HeadObject; //Used in head angle and camera parenting.
	public GameObject BodyObject; //Used in body rotation

	private Transform HeadObjectLocationXYZ; //XYZ location of HeadObject

	private float HeadObjectLocationX;	//X location of HeadObject
	private float HeadObjectLocationY;	//Y location of HeadObject
	private float HeadObjectLocationZ;	//Z location of HeadObject

	private Quaternion HeadObjectAngleXYZ; //XYZ angle of HeadObject
	
	private float HeadObjectAngleX;	//X angle of HeadObject
	private float HeadObjectAngleY;	//Y angle of HeadObject
	private float HeadObjectAngleZ;	//Z angle of HeadObject

	public float CameraDistanceX = -0.3F; //Adds this to HeadObjectX
	public float CameraDistanceY = 1.2F; //Add this to HeadObjectY
	public float CameraDistanceZ = -2F;	//Add this to HeadObjectZ

	public float CameraAngleX = 25F; //The X angle of Camera
	public float CameraAngleY = 0F; //The Y angle of Camera
	public float CameraAngleZ = 0F; //The Z angle of Camera

	//Sensitivety and other shit
	public bool InvertedY = false; //Enables inverted Y axis on mouse. Do not remove.

	public float SensitivityX = 500F;
	public float SensitivityY = 500F;
	
	//public float MinimumX = -360F; //currently not used anywhere
	//public float MaximumX = 360F; //currently not used anywhere
	
	public float HeadObjectMinimumY = -35F; //min Y for HeadObject angle
	public float HeadObjectMaximumY = 50F; //max Y for HeadObject angle

	public float CameraMinimumY = -20F;
	public float CameraMaximumY = 30F;
	
	
	float RotationZ = 0F;
	float RotationY = 0F;
	/* These are not used anywhere yet. They might be used later on when we implement a separate clamp for the camera.
	float CameraRotationX = 0F;
	float CameraRotationY = 0F;
	float CameraRotationZ = 0F;
	*/
	void Start ()
	{
		RotationY = BodyObject.transform.eulerAngles.y;

		Camera.main.transform.position = new Vector3(0, 0, 0); //Moves camera to 0,0,0

		HeadObjectLocationXYZ = HeadObject.transform;

		HeadObjectLocationX = HeadObjectLocationXYZ.transform.position.x;
		HeadObjectLocationY = HeadObjectLocationXYZ.transform.position.y;
		HeadObjectLocationZ = HeadObjectLocationXYZ.transform.position.z;

		Camera.main.transform.position = new Vector3(HeadObjectLocationX+CameraDistanceX, HeadObjectLocationY+CameraDistanceY,HeadObjectLocationZ+CameraDistanceZ); //Moves the camera to the heads location and adds some offset to it to make it a 3rd person camera.

		Camera.main.transform.rotation = Quaternion.Euler(CameraAngleX, CameraAngleY, CameraAngleZ); //Controls the camera angle

		Camera.main.transform.parent = HeadObject.transform;	//Parents the main camera to the head.

		Camera.main.transform.RotateAround ( BodyObject.transform.position, new Vector3( 0, 1, 0 ), RotationY );

		Screen.lockCursor= true;

	}

	void Update()
	{

		RotationY += BodyObject.transform.rotation.x + (Input.GetAxis ( "Mouse X" ) *SensitivityX*Time.deltaTime);
		RotationZ += Input.GetAxis("Mouse Y")*SensitivityY*Time.deltaTime;

		if (InvertedY == false) //Normal mouse | If you edit this, don't forget to copy and paste the changes to inverted mouse.
		{
			
			RotationZ = Mathf.Clamp(RotationZ, -HeadObjectMaximumY, -HeadObjectMinimumY); //Clamps the angle. ie. head will not rotate 360 along its Y-axis
			
			BodyObject.transform.rotation = Quaternion.Euler(0,RotationY,0); //rotates the body
			HeadObject.transform.rotation = Quaternion.Euler(-RotationZ,RotationY,0); //rotates the heads Y axis. Also turns head on X axis so it turns with the body. | The axis on the unity default character are a bit wonky at the moment.
			
		} 
		
		else //Inverted mouse | Some of the variables work bit differently here than on the normal mouse and you may need to use negative values for some. For example the Mathf.Clamp.
		{
			
			RotationZ = Mathf.Clamp(RotationZ, HeadObjectMinimumY, HeadObjectMaximumY); //Clamps the angle. ie. head will not rotate 360 along its Y-axis
			
			BodyObject.transform.rotation = Quaternion.Euler(0,RotationY,0); //rotates the body
			HeadObject.transform.rotation = Quaternion.Euler(RotationZ,RotationY,0); //rotates the head on Y axis with a clamp. Also turns head on X axis so it turns with the body


		
		}

		if (Input.GetKeyDown (KeyCode.P))
		{
			if (DebugMode == false)
			{
				DebugMode = true;
				Debug.Log ("Debug mode enabled.");
				Screen.lockCursor= false;
			}

			else
			{
				DebugMode = false;
				Debug.Log ("Debug mode disabled.");
				Screen.lockCursor= true;
			}
		}
	}

	void LateUpdate()
	{

		/*Vector3 cameraLocationXYZ = Camera.main.transform.position;

		float cameraLocationX = Camera.main.transform.position.x;
		float cameraLocationY = Camera.main.transform.position.y;
		float cameraLocationZ = Camera.main.transform.position.z;

		Vector3 newCameraLocationXYZ = new Vector3 (cameraLocationX, cameraLocationY, cameraLocationZ);

		if (DebugMode == true)
		{

		Debug.Log(newCameraLocationXYZ);

		}
			RaycastHit objectHit;
			
			Debug.DrawLine (HeadObject.transform.position, newCameraLocationXYZ, Color.magenta);
									
		if (Physics.Raycast (HeadObject.transform.position, Camera.main.transform.position, out objectHit, 50)) 

			{
			if (DebugMode == true)
				{
				Debug.LogError("hits on something");
				}
			}*/

		if( Physics.Raycast ( Camera.main.transform.position, HeadObject.transform.TransformDirection ( Vector3.left ), 1 ) ) {

			Debug.Log ( "left" );

		} else if( Physics.Raycast ( Camera.main.transform.position, HeadObject.transform.TransformDirection ( Vector3.right ), 1 ) ) {
			
			Debug.Log ( "right" );
			
		} else if( Physics.Raycast ( Camera.main.transform.position, HeadObject.transform.TransformDirection ( Vector3.back ), 1 ) ) {
			
			Debug.Log ( "back" );
			
		}

	}



}
