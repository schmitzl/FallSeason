using UnityEngine;
using System.Collections;

public class UmbrellaFolding : MonoBehaviour {

	public float gravityMult;

	private bool umbrellaFolded = false;
	private float doubleClickStart = 0.0f;

	void OnMouseUp()
	{
		if ((Time.time - doubleClickStart) < 0.3f)
		{
			this.OnDoubleClick();
			doubleClickStart = -1.0f;
		}
		else
		{
			doubleClickStart = Time.time;
		}
	}

	void OnDoubleClick () {
		if (!umbrellaFolded) {
			umbrellaFolded = true;
			this.transform.GetComponent<Rigidbody2D> ().gravityScale *= gravityMult;
			this.GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0, 1);
		} else {
			umbrellaFolded = false;
			this.transform.GetComponent<Rigidbody2D> ().gravityScale /= gravityMult;
			this.GetComponent<SpriteRenderer> ().color = new Color (0, 1, 0, 1);
		}
	}
}
