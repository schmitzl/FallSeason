using UnityEngine;
using System.Collections;

public class CoinSpawning : MonoBehaviour {

	private int currentLevelSegment = -1;
	void Update () {
		int highestBg = this.GetComponent<ScrollingManager> ().highestBG;
		// if it is a new level segment
		if (highestBg != currentLevelSegment) {
			currentLevelSegment = highestBg;
			GameObject[] levelSegments = this.GetComponent<ScrollingManager> ().background;
			GameObject nextLevelSegment = levelSegments[(currentLevelSegment + 1) % levelSegments.Length];
			// we active all the coins in the next level segment
			foreach (Transform child in nextLevelSegment.transform) {
				if (child.gameObject.CompareTag("GoldCoin") ||
			   		child.gameObject.CompareTag("SilverCoin") ||
			    	child.gameObject.CompareTag("BronzeCoin")) {
					child.gameObject.SetActive(true);
				}
			}
		}
	}
}
