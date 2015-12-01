using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickCoins : MonoBehaviour {

	private int coinCounter;

	public int coins {
		get { return coinCounter; }
		set { coinCounter = value; }
	}

	void Start() {
		coinCounter = 0;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag("GoldCoin")) {
			Destroy(other.gameObject);
			coinCounter += 5;
		} else if (other.gameObject.CompareTag("SilverCoin")) {
			Destroy(other.gameObject);
			coinCounter += 2;
		} else if (other.gameObject.CompareTag("BronzeCoin")) {
			Destroy(other.gameObject);
			coinCounter += 1;
		}
	}
}
