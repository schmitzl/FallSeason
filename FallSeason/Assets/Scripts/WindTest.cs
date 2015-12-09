using UnityEngine;
using System.Collections;

public class WindTest : MonoBehaviour {
	
	public float radius;
	public float scaleWind;
	
	public GameObject big;
	public GameObject medium;
	public GameObject small;

	private Rigidbody2D wind;
	private bool mousePressed;
	private Vector2 mouseStartPosition;
	private Vector2 mouseEndPosition;

	public Vector2 force;

	Animator animator;

	void Start() {
		wind = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator>();
	}

	void Update(){
		Vector2 direction;	
		float airDensity = 1.2f;
		float surface = 4.0f * Mathf.PI * radius * radius / 2.0f;
		float dragCoef = 0.45f;
		float speed = 1.0f;
		float windForce = 0.5f * airDensity * surface * dragCoef * speed * speed / scaleWind;
		if (Input.GetMouseButtonDown (0)) {
			mousePressed = true;
			mouseStartPosition = Camera.main.ScreenPointToRay (Input.mousePosition).origin;
		}
		if (Input.GetMouseButtonUp (0)) {
			if (mousePressed) {
				mouseEndPosition = Camera.main.ScreenPointToRay (Input.mousePosition).origin;

				direction = mouseEndPosition - mouseStartPosition;
				force = new Vector2 (direction.x, direction.y) * windForce;
				wind.AddForce (force);
				spawnWindParticles();
			}
		}

	}

	void FixedUpdate(){
		UpdateWindBlowingDirection();
	}

	void UpdateWindBlowingDirection() {

		if (mouseStartPosition.x < mouseEndPosition.x) {
			animator.SetBool ("windIsBlowingToTheRight", true);
			animator.SetBool ("windIsBlowingToTheLeft", false);
		} else if (mouseStartPosition.x > mouseEndPosition.x){
			animator.SetBool ("windIsBlowingToTheLeft", true);
			animator.SetBool ("windIsBlowingToTheRight", false);
		}

	}

	Vector3 scaleDir (Vector3 dir) {
		dir.x = dir.x * 0.1f;
		dir.y = dir.y * 0.3f;
		return dir;
	}

	void spawnWindParticles () {
		// We calculate the rotation of the wind effect around z
		Vector3 dir = mouseEndPosition - mouseStartPosition;
		float alpha = Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg;
		if (mouseStartPosition.x > mouseEndPosition.x) {
			alpha += 180;
		}

		float norm = Vector2.Distance(mouseStartPosition, mouseEndPosition);
		if (norm > 0.5f) {

			// Depending of the strength of the wind, we instantiate a big, medium or small one
			GameObject windInstance;
			Vector3 windDir = scaleDir(dir);
			Vector3 pos = this.transform.position - windDir;
			if (norm > 5.0f) {
				windInstance = Instantiate(big, pos, Quaternion.identity) as GameObject;
			} else if (norm <= 5.0f && norm > 2.5f) {
				windInstance = Instantiate(medium, pos, Quaternion.identity) as GameObject;
			} else {
				windInstance = Instantiate(small, pos, Quaternion.identity) as GameObject;
			}
			windInstance.GetComponent<WindPosition>().scaledDir = dir;
			Debug.Log(windInstance.GetComponent<WindPosition>().scaledDir);
			windInstance.transform.Rotate(0, 0, alpha);

			// After the effect has finished playing, we destroy it
			Destroy(windInstance, 5);
		}
	}
}
