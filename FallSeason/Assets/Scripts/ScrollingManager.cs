using UnityEngine;
using System.Collections;

public class ScrollingManager : MonoBehaviour {

	public GameObject[] background;
	public GameObject character;
	
	private float mass;
	private float levelSpeed;
	private float speed;
	private float speedBeforeCollision;

	private int highestBG = 0;

	// Use this for initialization
	void Start () {
		mass = character.GetComponent<Rigidbody2D>().mass;
		levelSpeed = 0.05f;
		speed = levelSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		// If the character has reached the down limit
		// then its speed is 0 and the background has to start scrolling
		if (character.GetComponent<Rigidbody2D>().velocity.y == 0) {

			// We use the speed before collision with down limit as the new speed
			if (speedBeforeCollision > 0.01f) {
				speed = speedBeforeCollision;
			}

			// We add the force input to the speed
			if (Input.GetMouseButtonUp(0)) {
				float forceY = character.GetComponent<WindTest>().force.y;
				speed -= forceY / mass * Time.deltaTime / 30;
			}

			// We move the background sprites up with the speed value
			Vector3 up = new Vector3(0, speed, 0);
			foreach (GameObject bg in background) {
				bg.transform.position += up;
			}

			// If a background is too high, place it underneath the others
			if (background[highestBG].transform.position.y > 20) {
				float jumpLength = 20*(background.Length);
				Vector3 down = new Vector3(0,  -jumpLength, 0);
				background[highestBG].transform.position += down;
				highestBG = (highestBG + 1) % background.Length;
			}

			// If the speed is different from the average speed
			// increase or decrease it with a small step
			if (speed < levelSpeed - 0.002f) {
				speed += 0.002f;
			} else if (speed > levelSpeed + 0.002f) {
				speed -= 0.002f;
			}
		}

		// Update the speed before collision
		speedBeforeCollision = - character.GetComponent<Rigidbody2D>().velocity.y / 30;
	}
}
