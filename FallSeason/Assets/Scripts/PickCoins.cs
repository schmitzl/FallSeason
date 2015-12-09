using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickCoins : MonoBehaviour {

	public AudioClip hitCoin;

	private int coinCounter;
	private AudioSource source;

	public int coins {
		get { return coinCounter; }
		set { coinCounter = value; }
	}

	void Awake () {
		source = GetComponent<AudioSource> ();
	}

	void Start() {
		coinCounter = 0;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag("GoldCoin")) {
			source.PlayOneShot(hitCoin,5F);
			//Destroy(other.gameObject);
			other.gameObject.SetActive(false);
			coinCounter += 5;
		} else if (other.gameObject.CompareTag("SilverCoin")) {
			source.PlayOneShot(hitCoin,5F);
			//Destroy(other.gameObject);
			other.gameObject.SetActive(false);
			coinCounter += 2;
		} else if (other.gameObject.CompareTag("BronzeCoin")) {
			source.PlayOneShot(hitCoin,5F);
			//Destroy(other.gameObject);
			other.gameObject.SetActive(false);
			coinCounter += 1;
		}
	}
}
