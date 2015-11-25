using UnityEngine;
using System.Collections;

public class CreateCoin : MonoBehaviour {

	public GameObject coin;
	public GameObject[] background;

	private float bgPos1;
	private float maxBgPos = 20.0f;
	private float interval = 1.5f;

	void Start() {
		bgPos1 = HighestBgPos ();
	}

	void Update() {
		float bgPos2;
		if (this.GetComponent<Rigidbody2D> ().velocity.y == 0) {
			bgPos2 = HighestBgPos();
			if ((bgPos1 > maxBgPos - interval) && (bgPos2 < maxBgPos - interval)) {
				bgPos1 -= maxBgPos;
			}
			if (bgPos2 - bgPos1 > interval) {
				Instantiate (coin, 
			             	new Vector3 (Random.Range (-2.5f, 2.5f), -4.5f, 0.0f),
			             	Quaternion.identity);
				bgPos1 = bgPos2;
			}
		}
	}


	float HighestBgPos() {
		float yBg0 = background [0].transform.position.y;
		float yBg1 = background [1].transform.position.y;
		return Mathf.Max(yBg0,yBg1);
	}
}
