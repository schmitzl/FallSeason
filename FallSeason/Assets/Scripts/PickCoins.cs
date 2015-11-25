using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickCoins : MonoBehaviour {

	public Text countText;

	private int count;
	
	void Start() {
		count = 0;
		SetCountText ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag("Coin")) {
			Destroy(other.gameObject);
			count++;
			SetCountText();
		}
	}
	
	void SetCountText() {
		countText.text = "Score: " + count.ToString ();
	}
}
