using UnityEngine;
using System.Collections;

public class MoveCoin : MonoBehaviour {

	private GameObject character;

	void Start() {
		character = GameObject.Find ("Character");
	}

	void Update () {
		float speed;
		if (character.GetComponent<Rigidbody2D> ().velocity.y == 0) {
			speed = character.GetComponent<ScrollingManager> ().speed;
			this.transform.position += new Vector3(0,speed,0);
		}
	}
}
