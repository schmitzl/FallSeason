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
		Debug.Log ("pick coin name = " + other.gameObject.name + ", attracted = " + other.gameObject.GetComponent<AttractCoin>().attracted);
		if (other.gameObject.CompareTag("GoldCoin")) {
			//Destroy(other.gameObject);
			other.gameObject.GetComponent<AttractCoin>().attracted = false;
			other.gameObject.SetActive(false);
			coinCounter += 5;
		} else if (other.gameObject.CompareTag("SilverCoin")) {
			//Destroy(other.gameObject);
			other.gameObject.GetComponent<AttractCoin>().attracted = false;
			other.gameObject.SetActive(false);
			coinCounter += 2;
		} else if (other.gameObject.CompareTag("BronzeCoin")) {
			//Destroy(other.gameObject);
			other.gameObject.GetComponent<AttractCoin>().attracted = false;
			other.gameObject.SetActive(false);
			coinCounter += 1;
		}
	}

	/*void Update() {
		float maxDistance = 0.5f;
		GameObject[] background = this.GetComponent<ScrollingManager> ().background;
		int highest = this.GetComponent<ScrollingManager> ().highestBG;
		Transform collectablesTransform = background[highest].transform.FindChild ("Collectables");
		Transform collectablesTransformNext = background[(highest+1) % background.Length].transform.FindChild ("Collectables");
		//Debug.Log ("HIGHBG = " + background [highest].name);
		if (collectablesTransform != null) {
			foreach(Transform child in collectablesTransform){
				float distance = Vector3.Distance(this.transform.position, child.position);
				Debug.Log("tranform pos = " + this.transform.position + ", child pos = " + child.position);
				Debug.Log ("name = " + child.gameObject.name + ", diff = " + distance + ", active = " + this.gameObject.activeSelf);
				if ((distance < maxDistance) && (child.gameObject.activeSelf)) {
					Debug.Log ("close");
					if (child.CompareTag("GoldCoin")) {
						//Destroy(child.gameObject);
						child.GetComponent<AttractCoin>().attracted = false;
						child.gameObject.SetActive(false);
						coinCounter += 5;
					} else if (child.CompareTag("SilverCoin")) {
						//Destroy(child.gameObject);
						child.GetComponent<AttractCoin>().attracted = false;
						child.gameObject.SetActive(false);
						coinCounter += 2;
					} else if (child.CompareTag("BronzeCoin")) {
						//Destroy(child.gameObject);
						child.GetComponent<AttractCoin>().attracted = false;
						child.gameObject.SetActive(false);
						coinCounter += 1;
					}
				}
			}
		}
		if (collectablesTransformNext != null) {
			foreach(Transform child in collectablesTransformNext){
				float distance = Vector3.Distance(this.transform.position, child.position);
				Debug.Log("tranform pos = " + this.transform.position + ", child pos = " + child.position);
				Debug.Log ("name = " + child.gameObject.name + ", diff = " + distance + ", active = " + this.gameObject.activeSelf);
				if ((distance < maxDistance) && (child.gameObject.activeSelf)) {
					Debug.Log ("close");
					if (child.CompareTag("GoldCoin")) {
						//Destroy(child.gameObject);
						child.GetComponent<AttractCoin>().attracted = false;
						child.gameObject.SetActive(false);
						coinCounter += 5;
					} else if (child.CompareTag("SilverCoin")) {
						//Destroy(child.gameObject);
						child.GetComponent<AttractCoin>().attracted = false;
						child.gameObject.SetActive(false);
						coinCounter += 2;
					} else if (child.CompareTag("BronzeCoin")) {
						//Destroy(child.gameObject);
						child.GetComponent<AttractCoin>().attracted = false;
						child.gameObject.SetActive(false);
						coinCounter += 1;
					}
				}
			}
		}
	}*/
}
