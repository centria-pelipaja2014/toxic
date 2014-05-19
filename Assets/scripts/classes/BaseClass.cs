using UnityEngine;
using System.Collections;

public class BaseClass : MonoBehaviour {

	/* Properties
	 *
	 *	health
	 *	jump_speed
	 *	normal_speed
	 *	sneak_speed
	 *	reticle_spread
	 *	attack_speed
	 *	minimum_damage
	 *	maximum_damage
	 *	visibility
	 *	life_regeneration
	 * 
	 */

	private Hashtable properties = new Hashtable();

	public BaseClass() {

		properties[ "health" ] = 100;
		properties[ "jump_speed"] = 8;
		properties[ "normal_speed" ] = 6;
		properties[ "sneak_speed" ] = 2;
		properties[ "reticle_spread" ] = 0.5f;
		properties[ "attack_speed" ] = 1.0f;
		properties[ "minimum_damage" ] = 0;
		properties[ "maximum_damage" ] = 1;
		properties[ "visibility" ] = 1;
		properties[ "life_regeneration" ] = 1;

	}

	public float GetProperty( string property ) {

		if( !properties.ContainsKey ( property ) ) return 0;

		return System.Convert.ToSingle ( properties[ property ] );

	}

	public void SetProperty( string property, float value ) {

		if( properties.ContainsKey ( property ) ) {

			properties[ property ] = value;

		}

	}

}
