using UnityEngine;
using System.Collections;

public class MoveCoin : MonoBehaviour {

	private GameObject mainCamera;
	private GameObject character;

	void Start() {
		mainCamera = GameObject.Find ("Main Camera");
		character = GameObject.Find ("Character");
	}

	void Update () {
		float speed;
		if (character.GetComponent<Rigidbody2D> ().velocity.y == 0) {
			speed = mainCamera.GetComponent<ScrollingManager> ().speed;
			this.transform.position += new Vector3(0,speed,0);
		}
	}
}
