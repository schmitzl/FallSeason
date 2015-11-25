using UnityEngine;
using System.Collections;

public class WindTest : MonoBehaviour {
	
	public float radius;
	public float scaleWind;

	private Rigidbody2D wind;
	private bool mousePressed;
	private Vector2 mouseStartPosition;

	public Vector2 force;

	void Start() {
		wind = GetComponent<Rigidbody2D> ();
	}

	void Update(){
		Vector2 mouseEndPosition;
		Vector2 umbrellaPosition;
		Vector2 direction;
		float distMouseUmbrella;
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
				umbrellaPosition = transform.position;
				direction = mouseEndPosition - mouseStartPosition;
				force = new Vector2 (direction.x, direction.y) * windForce;
				wind.AddForce (force);
			}
		}
	}
}
