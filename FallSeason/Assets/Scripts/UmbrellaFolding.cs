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
		} else {
			umbrellaFolded = false;
			this.transform.GetComponent<Rigidbody2D> ().gravityScale /= gravityMult;
		}
	}
}
