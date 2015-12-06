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
			animator.SetBool ("shouldFall", true);
		} else {
			umbrellaFolded = false;
			this.transform.GetComponent<Rigidbody2D> ().gravityScale /= gravityMult;
			animator.SetBool ("isFalling", false);
		}
	}

	void Update() {
		if (animator.GetBool ("isFalling")) {
			animator.SetBool ("shouldFall", false);
		}
		if (umbrellaFolded) {
			animator.SetBool ("isFalling", true);
		}

	}
}
