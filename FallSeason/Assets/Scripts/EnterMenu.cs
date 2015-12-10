using UnityEngine;
using System.Collections;

public class EnterMenu : MonoBehaviour {

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel("MenuScene");
		}
	}
}
