using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	
	public Text scoreText;
	public Text distanceText;
	public Text coinText;

	private int prevDistance;
	private int prevCoins;

	private int distance;
	private float speed;
	private int speedCombo;
	private int coins;
	private int score;

	// Use this for initialization
	void Start () {
		score = distance = coins = 0;
		UpdateTexts();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateValues();
		UpdateTexts();
	}

	void UpdateValues () {
		// Update the distance
		prevDistance = distance;
		distance = GetComponent<ScrollingManager>().distance;

		// Update the speed combo
		speed = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y);
		if (speed < 0.01) {
			speed = GetComponent<ScrollingManager>().speed;
			speedCombo = (int) (speed * 30);
		} else {
			speedCombo = (int) (speed);
		}
		if (speedCombo == 0) {
			speedCombo++;
		}

		// Udpate the number of coins
		prevCoins = coins;
		coins = GetComponent<PickCoins>().coins;

		// Update the score
		score += (distance - prevDistance) * speedCombo * 10 + (coins - prevCoins);
	}

	void UpdateTexts () {
		scoreText.text 		= "Score : " 	+ score.ToString ();
		distanceText.text 	= "Distance : " + distance.ToString ();
		coinText.text 		= "Coins : " 	+ coins.ToString ();
	}
}
