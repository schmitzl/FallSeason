using UnityEngine;
using System.Collections;

public class CoinMagnet : MonoBehaviour {

	public float timeActive;

	private float startMagnet;
	private bool magnetActivated = false;

	void Update() {
		float y = this.transform.position.y;
		if (magnetActivated) {
			if (Time.time - startMagnet < timeActive) {
				foreach (GameObject bronzeCoin in GameObject.FindGameObjectsWithTag("BronzeCoin")) {
					if (Mathf.Abs(bronzeCoin.transform.position.y - y) < 0.05f) {
						bronzeCoin.SetActive (false);
						this.GetComponent<PickCoins> ().coinCounter += 1;
					}
				}
				foreach (GameObject silverCoin in GameObject.FindGameObjectsWithTag("SilverCoin")) {
					if (Mathf.Abs(silverCoin.transform.position.y - y) < 0.05f) {
						silverCoin.SetActive (false);
						this.GetComponent<PickCoins> ().coinCounter += 2;
					}
				}
				foreach (GameObject goldCoin in GameObject.FindGameObjectsWithTag("GoldCoin")) {
					if (Mathf.Abs(goldCoin.transform.position.y - y) < 0.05f) {
						goldCoin.SetActive (false);
						this.GetComponent<PickCoins> ().coinCounter += 5;
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
