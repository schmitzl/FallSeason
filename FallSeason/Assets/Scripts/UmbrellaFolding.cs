using UnityEngine;
using System.Collections;

public class UmbrellaFolding : MonoBehaviour {

	public float gravityMult;

	private bool mousePressed = false;
	void Update () {
		Debug.Log(this.transform.GetComponent<Rigidbody2D> ().gravityScale);
		if (Input.GetMouseButtonDown (0)) {
			if (!mousePressed) {
				mousePressed = true;
				this.transform.GetComponent<Rigidbody2D> ().gravityScale *= gravityMult;
				this.GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0, 1);
			} else {
				mousePressed = false;
				this.transform.GetComponent<Rigidbody2D> ().gravityScale /= gravityMult;
				this.GetComponent<SpriteRenderer> ().color = new Color (0, 1, 0, 1);
			}
		}
	}
}
