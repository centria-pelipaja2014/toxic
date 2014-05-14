using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {
	

	public float timeBetweenShots = 1.0F;
	private float timeSinceLastShot = 0.0F;
	// get the gun's muzzle point
	public GameObject gunMuzzle = GameObject.Find ("gunMuzzle");
	public float hitForce = 100.0F;
	// get the crosshair
	public GameObject crosshair = GameObject.Find("crosshairObject");

	// for the crosshair image location
	public float screenMidX = (Screen.width/2);
	public float screenMidY = (Screen.height/2);


	// Use this for initialization
	void Start () {
	
	}
	

	// Update is called once per frame
	void Update () {
		//keep track of the shot timing
		timeSinceLastShot += Time.deltaTime;
		//check if the user is firing, and refire time is over 
		if (Input.GetButtonDown("Fire1") && timeSinceLastShot >= timeBetweenShots) 
		{											
			CheckForHit();
		}
	}


		void CheckForHit()
		{
		RaycastHit objectHit;
			Vector3 fwd = gunMuzzle.transform.TransformDirection (Vector3.forward);

				Debug.DrawLine (gunMuzzle.transform.position, fwd * 50, Color.magenta);
		timeSinceLastShot = 0;
		// check for hits along the way
		//
		//											
		if (Physics.Raycast (gunMuzzle.transform.position, fwd, out objectHit, 50)) 
					//if (Physics.Raycast (gunMuzzle.transform.position, fwd, out objectHit, 50)) 
			{
				if (objectHit.rigidbody != null)
				{
				//add force to the rigidbody of the hit object
				// !!! CHANGE TO TAKE TAGS INTO ACCOUNT FOR PENETRATING HITS !!!
					Vector3 rotatedVectorMuzzle = Quaternion.Euler ( gunMuzzle.transform.localEulerAngles ) * gunMuzzle.transform.localPosition;
						objectHit.rigidbody.AddForce(rotatedVectorMuzzle * hitForce);
				}
		}
	}
	
	/*
	1: get the coordinates for the crosshairObject
	2: 

	*/

	// direct the shots towards the crosshairObject


		}

