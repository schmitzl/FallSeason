using UnityEngine;
using System.Collections;

public class DestroyCoin : MonoBehaviour {

	void Update () {
		if (transform.position.y > 4.5f) {
			DestroyObject (gameObject);
		}
	}
}
