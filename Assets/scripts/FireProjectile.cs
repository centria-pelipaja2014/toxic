using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {
	

	public float timeBetweenShots = 1.0F;
	private float timeSinceLastShot = 0.0F;
	// get the gun's muzzle point
	public GameObject Muzzle; 
	public float hitForce = 100.0F;
	// get the crosshair
	public GameObject crosshair; 

	// Use this for initialization
	void Start () {
		GameObject.Find ("Muzzle");
		GameObject.Find("crosshairObject"); 
	}
	

	// Update is called once per frame
	void Update () {
		//keep track of the shot timing
		timeSinceLastShot += Time.deltaTime;
		//check if the user is firing, and refire time is over 
		if (Input.GetButton("Fire1") && timeSinceLastShot >= timeBetweenShots) 
		{											
			CheckForHit();
		}
	}

	void CheckForHit()
	{
		RaycastHit objectHit;
		Vector3 fwd = Muzzle.transform.TransformDirection (Vector3.forward);
		
		Debug.DrawLine (Muzzle.transform.position, fwd * 50, Color.magenta);
		timeSinceLastShot = 0;
		// check for hits along the way
		//
		//											
		if (Physics.Raycast (Muzzle.transform.position, fwd, out objectHit, 500)) 
		{
			if (objectHit.rigidbody != null)
			{
				//add force to the rigidbody of the hit object
				// !!! CHANGE TO TAKE TAGS INTO ACCOUNT FOR PENETRATING HITS !!! 1-5 levels for penetration.
				Vector3 rotatedVectorMuzzle = Quaternion.Euler ( Muzzle.transform.localEulerAngles ) * Muzzle.transform.localPosition;
				objectHit.rigidbody.AddForce(rotatedVectorMuzzle * hitForce);
			}
		}
	}
	// ( get class.minimumDispersion, get class.maximumDispersion, 1 * time.deltaTime);
	//float offset = Vector3.Lerp ();
	//float randomAngle = Random.Range(0,360);
	// Get the forward vector, offset the direction from the forward vector by x degrees by y lenght.
	// x degrees = 0-360, y lenght = get.class.dispersionMinMax.



	// static bool Raycast(Vector3 origin, Vector3 direction, RaycastHit hitInfo, float distance = 50);
	/*
	1: get the coordinates for the crosshairObject
	2: 

	*/

	// direct the shots towards the crosshairObject


		}

