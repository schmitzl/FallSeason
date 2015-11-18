using UnityEngine;
using System.Collections;

public class ScrollingManager : MonoBehaviour {

	public GameObject[] background;
	public GameObject character;
	public float speed;
	private int highestBG = 0;

	// Use this for initialization
	void Start () {
		speed = 0.115f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 up = new Vector3(0, speed, 0);

		if (character.transform.position.y < -1) {
			character.GetComponent<Rigidbody2D>().isKinematic = true;

			foreach (GameObject bg in background) {
				bg.transform.position += up;
			}

			if (background[highestBG].transform.position.y > 20) {
				Vector3 down = new Vector3(0, -40, 0);
				background[highestBG].transform.position += down;
				highestBG = (highestBG + 1) % background.Length;
			}

		} else {
			character.GetComponent<Rigidbody2D>().isKinematic = false;
		}

	}
}
