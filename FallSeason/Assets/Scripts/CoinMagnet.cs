using UnityEngine;
using System.Collections;

public class CoinMagnet : MonoBehaviour {

	public float timeActive;
	public float maxDistance;

	private float startMagnet;
	private bool magnetActivated = false;

	void Update() {
		if (magnetActivated) {
			if (Time.time - startMagnet < timeActive) {
				GameObject[] background = this.GetComponent<ScrollingManager> ().background;
				int highest = this.GetComponent<ScrollingManager> ().highestBG;
				Transform collectablesTransform = background[highest].transform.FindChild ("Collectables");
				Transform collectablesTransformNext = background[(highest+1) % background.Length].transform.FindChild ("Collectables");
				if (collectablesTransform != null) {
					foreach(Transform child in collectablesTransform){
						float distance = Vector3.Distance(this.transform.position, child.position);
						if ((distance < maxDistance) && (child.gameObject.activeSelf)) {
							if (child.CompareTag("GoldCoin") || child.CompareTag("SilverCoin") || child.CompareTag("BronzeCoin")) {
								child.GetComponent<AttractCoin>().attracted = true;
							}
						}
					}
				}
				if (collectablesTransformNext != null) {
					foreach(Transform child in collectablesTransformNext){
						float distance = Vector3.Distance(this.transform.position, child.position);
						if ((distance < maxDistance) && (child.gameObject.activeSelf)) {
							if (child.CompareTag("GoldCoin") || child.CompareTag("SilverCoin") || child.CompareTag("BronzeCoin")) {
								child.GetComponent<AttractCoin>().attracted = true;
							}
						}
					}
				}
			} else {
				magnetActivated = false;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Magnet")) {
			other.gameObject.SetActive(false);
			startMagnet = Time.time;
			magnetActivated = true;
		}
	}

}
