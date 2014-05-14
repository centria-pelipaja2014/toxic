using UnityEngine;
using System.Collections;

public class MouseAiming : MonoBehaviour {

	//Objects and stuff

	public GameObject HeadObject; //Used in head angle and camera parenting.
	public GameObject BodyObject; //Used in body rotation

	private Transform HeadObjectLocationXYZ; //XYZ location of HeadObject

	private float HeadObjectLocationX;	//X location of HeadObject
	private float HeadObjectLocationY;	//Y location of HeadObject
	private float HeadObjectLocationZ;	//Z location of HeadObject

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
	
	
	float RotationY = 0F;
	float RotationX = 0F;
	/* These are not used anywhere yet. They might be used later on when we implement a separate clamp for the camera.
	float CameraRotationX = 0F;
	float CameraRotationY = 0F;
	float CameraRotationZ = 0F;
	*/
	void Start ()
	{
		Camera.main.transform.position = new Vector3(0, 0, 0); //Moves camera to 0,0,0

		HeadObjectLocationXYZ = HeadObject.transform;

		HeadObjectLocationX = HeadObjectLocationXYZ.transform.position.x;
		HeadObjectLocationY = HeadObjectLocationXYZ.transform.position.y;
		HeadObjectLocationZ = HeadObjectLocationXYZ.transform.position.z;

		Camera.main.transform.position = new Vector3(HeadObjectLocationX+CameraDistanceX, HeadObjectLocationY+CameraDistanceY,HeadObjectLocationZ+CameraDistanceZ); //Moves the camera to the heads location and adds some offset to it to make it a 3rd person camera.

		Camera.main.transform.rotation = Quaternion.Euler(CameraAngleX, CameraAngleY, CameraAngleZ); //Controls the camera angle

		Camera.main.transform.parent = HeadObject.transform;	//Parents the main camera to the head.

		//Screen.lockCursor= true;

	}

	void Update()
	{
		RotationX += Input.GetAxis ( "Mouse X" ) *SensitivityX*Time.deltaTime;
		RotationY += Input.GetAxis("Mouse Y")*SensitivityY*Time.deltaTime;


		if (InvertedY == false) //Normal mouse | If you edit this, don't forget to copy and paste the changes to inverted mouse.
		{
			
			RotationY = Mathf.Clamp(RotationY, HeadObjectMinimumY, HeadObjectMaximumY); //Clamps the angle. ie. head will not rotate 360 along its Y-axis
			
			BodyObject.transform.rotation = Quaternion.Euler(0,RotationX,0); //rotates the body
			HeadObject.transform.rotation = Quaternion.Euler(0,RotationX-90,RotationY-90); //rotates the heads Y axis. Also turns head on X axis so it turns with the body. | The axis on the unity default character are a bit wonky at the moment.
			
		} 
		
		else //Inverted mouse | Some of the variables work bit differently here than on the normal mouse and you may need to use negative values for some. For example the Mathf.Clamp.
		{
			
			RotationY = Mathf.Clamp(RotationY, -HeadObjectMaximumY, -HeadObjectMinimumY); //Clamps the angle. ie. head will not rotate 360 along its Y-axis
			
			BodyObject.transform.rotation = Quaternion.Euler(0,RotationX,0); //rotates the body
			HeadObject.transform.rotation = Quaternion.Euler(0,RotationX-90,-RotationY-90); //rotates the head on Y axis with a clamp. Also turns head on X axis so it turns with the body
		
		}

	}

	/*void  LateUpdate ()
	{
		CameraRotationX = HeadObject.transform.rotation.x;
		CameraRotationY = HeadObject.transform.rotation.y;
		CameraRotationZ = HeadObject.transform.rotation.z;


		CameraRotationY = Mathf.Clamp(CameraRotationY, CameraMinimumY, CameraMaximumY);

		Camera.main.transform.rotation = Quaternion.Euler(CameraRotationX, CameraRotationY, CameraRotationZ);

	}
	*/
}
