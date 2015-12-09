using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickCoins : MonoBehaviour {

	public int coinCounter;

	public int coins {
		get { return coinCounter; }
		set { coinCounter = value; }
	}

	void Start() {
		coinCounter = 0;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag("GoldCoin")) {
			other.gameObject.GetComponent<AttractCoin>().attracted = false;
			other.gameObject.SetActive(false);
			coinCounter += 5;
		} else if (other.gameObject.CompareTag("SilverCoin")) {
			other.gameObject.GetComponent<AttractCoin>().attracted = false;
			other.gameObject.SetActive(false);
			coinCounter += 2;
		} else if (other.gameObject.CompareTag("BronzeCoin")) {
			other.gameObject.GetComponent<AttractCoin>().attracted = false;
			other.gameObject.SetActive(false);
			coinCounter += 1;
		}
	}
}
