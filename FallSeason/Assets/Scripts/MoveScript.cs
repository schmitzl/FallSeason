﻿using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	// Some useful stuff :
	// Input.touches : array of touches
	// Touch myTouch = Input.GetTouch(0);
	// myTouch.deltaTime : often same as update Time
	// myTouch.fingerId index of the specific touch
	// myTouch.phase : begin, moving, stationnary, ended, cancelled (if error and can't read input)
	// myTouch.position on the screen (rawPosition : takes Android menu bar into account ?)
	// myTouch.tapCount : quickTap (double, etc.)

	void Update () {

		// Calculations to redo 
		if (Input.touchCount == 1) {
			Touch touch = Input.GetTouch(0);
			float x = -2.5f + 5 * touch.position.x / Screen.width;
			float y = -5.5f + 11 * touch.position.y / Screen.height;
			transform.position = new Vector3(x, y, 0);
		}

		// Calculations to redo 
		if (Input.GetMouseButtonDown(0)) {
			float x = -2.5f + 5 * Input.mousePosition.x / Screen.width;
			float y = -5.5f + 11 * Input.mousePosition.y / Screen.height;
			transform.position = new Vector3(x, y, 0);
		}
	}
}