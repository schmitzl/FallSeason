﻿using UnityEngine;
using System.Collections;

public class ScrollingManager : MonoBehaviour {
	
	public GameObject[] background;
	private int highestBG = 0;
	
	private float mass;
	private float levelSpeed;
	public float speed;
	private float speedBeforeCollision;

	// Use this for initialization
	void Start () {
		mass = GetComponent<Rigidbody2D>().mass;
		levelSpeed = 0.05f;
		speed = levelSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		// Update the speed before collision
		speedBeforeCollision = - GetComponent<Rigidbody2D>().velocity.y / 30;
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		// If the character has reached the down limit
		// then the background has to start scrolling
		if (collision.collider.gameObject.tag == "LimitDown") {
			Scroll();
		}
	}

	void OnCollisionStay2D (Collision2D collision) {
		// If the character has reached the down limit
		// then the background has to start scrolling
		if (collision.collider.gameObject.tag == "LimitDown") {
			Scroll();
		}
	}

	void Scroll() {
		// We use the speed before collision with down limit as the new speed
		if (speedBeforeCollision > 0.01f) {
			speed = speedBeforeCollision;
		}
		
		// We add the force input to the speed
		if (Input.GetMouseButtonUp(0)) {
			float forceY = GetComponent<WindTest>().force.y;
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
}
