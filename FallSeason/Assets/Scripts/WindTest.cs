using UnityEngine;
using System.Collections;

public class WindTest : MonoBehaviour {
	
	public float radius;
	public float scaleWind;
	public ParticleSystem windParticles;

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

	/*void OnMouseDown () {
		float mousePosition1 = 
		float airDensity = 1.2f;
		float surface = 4.0f * Mathf.PI * radius * radius/2.0f;
		float dragCoef = 0.45f;
		float liftCoef = 0.3f;
		float speed = 1.0f;
		wind.AddForce (new Vector3 (0.5f * airDensity * surface * dragCoef * speed * speed, 
		                        0.5f * airDensity * surface * liftCoef * speed * speed, 
		                        1.0f));
	}*/

	void Update(){
		Vector2 direction;
		Vector2 umbrellaPosition;
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
				/*distMouseUmbrella = Vector2.Distance(mouseEndPosition,umbrellaPosition);
				Debug.Log("dist = " + distMouseUmbrella);
				direction = mouseEndPosition - mouseStartPosition;
				if (distMouseUmbrella > 1.0f) {
					force = new Vector2 (direction.x, direction.y) * windForce / distMouseUmbrella;
				} else {
					force = new Vector2 (direction.x, direction.y) * windForce;
				}*/
				direction = mouseEndPosition - mouseStartPosition;
				//Vector3 particlesDirection = new Vector3(direction.x, direction.y, 0);
				//Instantiate(windParticles, mouseStartPosition, Quaternion.LookRotation(Vector3.forward, particlesDirection));
				
				//windParticles.transform.rotation = Quaternion.LookRotation(Vector3.forward, particlesDirection);
				//windParticles.Play(false);

				force = new Vector2 (direction.x, direction.y) * windForce;
				wind.AddForce (force);
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
}
