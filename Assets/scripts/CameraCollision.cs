//(Created CSharp Version) 10/2010: Daniel P. Rossi (DR9885)

using UnityEngine;
using System.Collections;

public class CameraCollision : MonoBehaviour {

	public GameObject objCamera;

	void FixedUpdate() {

		RaycastHit hitInfo;

		Vector3 backRay = -objCamera.transform.forward;
		Vector3 relativeTransformBack = Camera.main.transform.TransformPoint (backRay);
		Debug.DrawLine (objCamera.transform.position, relativeTransformBack * 2f, Color.magenta);

		/*
		Vector3 upRay = objCamera.transform.up;
		Vector3 relativeTransformUp = Camera.main.transform.TransformPoint (upRay);
		Debug.DrawLine (objCamera.transform.position, relativeTransformUp * 2f, Color.blue);

		Vector3 downRay = -objCamera.transform.up;
		Vector3 relativeTransformDown = Camera.main.transform.TransformPoint (downRay);
		Debug.DrawLine (objCamera.transform.position, relativeTransformDown * 2f, Color.red);

		Vector3 leftRay = -objCamera.transform.right;
		Vector3 relativeTransformLeft = Camera.main.transform.TransformPoint (leftRay);
		Debug.DrawLine (objCamera.transform.position, relativeTransformLeft * 2f, Color.cyan);

		Vector3 rightRay = objCamera.transform.right;
		Vector3 relativeTransformRight = Camera.main.transform.TransformPoint (rightRay);
		Debug.DrawLine (objCamera.transform.position, relativeTransformRight * 2f, Color.yellow);

*/


		if (Physics.Raycast (objCamera.transform.position, relativeTransformBack, out hitInfo, 2f)) {

			Camera.main.transform.position = hitInfo.point;


			Debug.Log("Back");

		}
		/*

		if (Physics.Raycast (objCamera.transform.position, relativeTransformUp, out hitInfo, 2f)) {


			
			Debug.Log("Up");
			
		}

		if (Physics.Raycast (objCamera.transform.position, relativeTransformDown, out hitInfo, 2f)) {
			
			
			Debug.Log("Down");
			
		}

		if (Physics.Raycast (objCamera.transform.position, relativeTransformLeft, out hitInfo, 2f)) {
			
			
			Debug.Log("Left");
			
		}

		if (Physics.Raycast (objCamera.transform.position, relativeTransformRight, out hitInfo, 2f)) {
			
			
			Debug.Log("Right");
			
		}

*/

		

		

	}
}