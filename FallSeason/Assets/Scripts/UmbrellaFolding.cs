using UnityEngine;
using System.Collections;

public class UmbrellaFolding : MonoBehaviour {

	public float gravityMult;

	private bool umbrellaFolded = false;
	private float doubleClickStart = 0.0f;

	Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
	}
	
	void DetectDoubleClick()
	{
		if (Input.GetMouseButtonDown (0)) {
			if ((Time.time - doubleClickStart) < 0.3f) {
				this.OnDoubleClick ();
				doubleClickStart = -1.0f;
			} else {
				doubleClickStart = Time.time;
			}
		}
	}
	
	void OnDoubleClick () {
		if (!umbrellaFolded) {
			Debug.Log ("folded");
			umbrellaFolded = true;
			this.transform.GetComponent<Rigidbody2D> ().gravityScale *= gravityMult;
			animator.SetBool ("isFalling", true);
		} else {
			Debug.Log ("unfolded");
			umbrellaFolded = false;
			this.transform.GetComponent<Rigidbody2D> ().gravityScale /= gravityMult;
			animator.SetBool ("isFalling", false);
		}
	}

	void Update() {
		DetectDoubleClick ();
	}

	public bool folded {
		get { return umbrellaFolded; }
		set { umbrellaFolded = value; }
	}
}
