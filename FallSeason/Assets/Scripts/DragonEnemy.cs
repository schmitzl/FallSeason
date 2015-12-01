using UnityEngine;
using System.Collections;

public class DragonEnemyScript : MonoBehaviour {

	private float startX;
	private float turnX;
	private float speed = 1;
	private bool directionIsLeft = true;

	// Use this for initialization
	void Start () {
		
		startX=transform.position.x;
		turnX=transform.position.x - 10;
	}
	
	// Update is called once per frame
	void Update () {
		float x = transform.position.x;
		// Keep on going left till we passed the turn point
		if (directionIsLeft) {
			transform.position = new Vector3 (x - Time.deltaTime * speed, transform.position.y, transform.position.z);
			if (transform.position.x <= turnX) {
				directionIsLeft = false;
				transform.Rotate (0, 180, 0);
			}
		} 
		else {
			transform.position = new Vector3 (x + Time.deltaTime * speed, transform.position.y, transform.position.z);
			if (transform.position.x >= startX) {
				directionIsLeft = true;
				transform.Rotate (0, -180, 0);
			}

		}

			
		
	}
}
