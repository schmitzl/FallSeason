﻿using UnityEngine;
using System.Collections;

public class ScrollingManager : MonoBehaviour {
	
	public DifficultyManager DiffManager;

	public GameObject[] background;
	public int highestBG = 0;
	private int counterBG = 0;
	
	private float speedBG;
	private int distanceCounter;

	private float mass;
	private float levelSpeed;
	private float speedBeforeCollision;

	private float speedUnfolded;
	private float speedFolded;
	private bool foldStateRegistered = false;
	private float gravityMult;

	public float speed {
		get { return speedBG; }
		set { speedBG = value; }
	}
	
	public int distance {
		get { return distanceCounter; }
		set { distanceCounter = value; }
	}
	
	void Start () {
		mass = GetComponent<Rigidbody2D>().mass;
		gravityMult = GetComponent<UmbrellaFolding>().gravityMult;
		speedUnfolded = 0.05f;
		speedFolded = speedUnfolded * gravityMult / 4;
		levelSpeed = speedUnfolded;
		levelSpeed = 0.05f;
		speedBG = levelSpeed;
		distanceCounter = 0;

		//initalize difficulty manager
		DiffManager = GetComponentInChildren<DifficultyManager>();

	}

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
			speedBG = speedBeforeCollision;
		}

		float gravityScale = this.transform.GetComponent<Rigidbody2D> ().gravityScale;
		bool nowFolded = GetComponent<UmbrellaFolding> ().folded;
		// If the umbrella has changed state, then change level speed
		if (nowFolded != foldStateRegistered) {
			// if the umbrella is now folded
			if (nowFolded) {
				levelSpeed = speedFolded;
				speedBG += (gravityMult - 1.0f) * gravityScale * (-Physics.gravity.y) * Time.deltaTime / 30;
			} else {
				levelSpeed = speedUnfolded;
				speedBG -= (gravityMult - 1.0f) * gravityScale * (-Physics.gravity.y) * Time.deltaTime / 30;
			}
			foldStateRegistered = !foldStateRegistered;
		}

		// We add the force input to the speed
		if (Input.GetMouseButtonUp(0)) {
			float forceY = GetComponent<WindTest>().force.y;
			speedBG -= forceY / mass * Time.deltaTime / 30;
		}
		
		// We move the background sprites up with the speed value
		Vector3 up = new Vector3(0, speedBG, 0);
		foreach (GameObject bg in background) {
			bg.transform.position += up;
		}
		// If a background is too high, place it underneath the others
		if (background[highestBG].transform.position.y > 17) {
			float jumpLength = 17*(background.Length);
			Vector3 down = new Vector3(0,  -jumpLength, 0);
			background[highestBG].transform.position += down;

			// Reset all taken collectables
			respawnCollectables(background[highestBG]);

			//increase difficulty of the scrolled level
			DiffManager.spawn(background[highestBG]);

			highestBG = (highestBG + 1) % background.Length;
			counterBG++;
		}

		// We update the distance counter
		distanceCounter = 17 * counterBG + (int)(background[highestBG].transform.position.y);

		// If the speed is different from the average speed
		// increase or decrease it with a small step
		if (speedBG < levelSpeed - 0.002f) {
			speedBG += 0.002f;
		} else if (speedBG > levelSpeed + 0.002f) {
			speedBG -= 0.002f;
		}

	}

	private void respawnCollectables(GameObject level){
		Transform collectablesTransform = level.transform.FindChild ("Collectables");
		if (collectablesTransform != null) {
			foreach(Transform child in collectablesTransform){
				child.gameObject.SetActive(true);
			}
		}
	}
}
