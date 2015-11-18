using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public float xInitial;
	public float yInitial;

	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			transform.position = new Vector2 (xInitial, yInitial);
		}
	}
}
