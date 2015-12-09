using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pauseScript : MonoBehaviour {

	public GameObject pausePanel;

	public bool isPaused;





	// Use this for initialization
	void Start () {

		isPaused = false;
		PauseGame (false);
	
	}


	void PauseGame (bool state){
		if (state) {
			Time.timeScale = 0.0f; //paused games
		
		} else {
			Time.timeScale = 1.0f; //unpaused game

		}
		
		//GetComponent<CharacterLife>().coinPanel.SetActive (false);
	//	GetComponent<CharacterLife>().lostPanel.SetActive (false);

		pausePanel.SetActive (state);
	

	



	}


	public void SwitchPause(){
		if (isPaused) {
			isPaused = false; //changes value
			PauseGame (false);

		} else {

			isPaused = true;
			PauseGame (true);
		}

	}




	
	public void RestartGame(){
		Application.LoadLevel ("MikaelTestScene");
	}

	
	public void ExitToMenu() {
		
		Application.LoadLevel ("MenuScene");
		
	}



}
