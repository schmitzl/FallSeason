using UnityEngine;
using System.Collections;

public class UmbrellaFolding : MonoBehaviour {

	public float gravityMult;

	private pauseScript pauseController;

	private bool umbrellaFolded = false;
	private float doubleClickStart = 0.0f;
	private Rigidbody2D rigidBody;

	Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D> ();
		pauseController = GameObject.Find ("PauseController").GetComponent<pauseScript> ();
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
			umbrellaFolded = true;
			this.transform.GetComponent<Rigidbody2D> ().gravityScale *= gravityMult;
			animator.SetBool ("isFalling", true);
			gameObject.layer = LayerMask.NameToLayer("Folded");
		} else {
			umbrellaFolded = false;
			this.transform.GetComponent<Rigidbody2D> ().gravityScale /= gravityMult;
			animator.SetBool ("isFalling", false);
			gameObject.layer = LayerMask.NameToLayer("Default");
			rigidBody.AddForce(new Vector2(0, 0.3f* -rigidBody.velocity.y)); // add a stop forcing
		}
	}

	void Update() {
		if(!pauseController.isPaused)
			DetectDoubleClick ();
	}

	public bool folded {
		get { return umbrellaFolded; }
		set { umbrellaFolded = value; }
	}
}
