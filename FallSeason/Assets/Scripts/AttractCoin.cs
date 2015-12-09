using UnityEngine;
using System.Collections;

public class AttractCoin : MonoBehaviour {
	
	public bool attracted = false;

	void Update () {
		Vector3 diff = GameObject.FindGameObjectsWithTag ("Player")[0].transform.position - this.transform.position;
		diff += 0.1f * diff;
		if (attracted) {
			this.transform.position += 0.02f * diff;
		}
	}
}
