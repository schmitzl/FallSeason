using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {


	public void StartGame(){

		Application.LoadLevel (3);
	} 

	public void StartHighScore(){

		Application.LoadLevel ("highscore_list");

	}

	public void ExitToMenu() {

		Application.LoadLevel ("MenuScene");

	}

	public void CreditMenu() {
		
		Application.LoadLevel ("CreditScene");
		
	}


	public Animator settingsButton;

	public void OpenSettings() {
		settingsButton.SetBool ("isHidden", true);
	}

	public void CloseSettings() {
		settingsButton.SetBool ("isHidden", false);
	}


	/*public Animator startButton;
	public Animator settingsButton;
	public Animator highscoreButton;
	public Animator dialog;

	public void OpenSettings() {
		startButton.SetBool("isHidden", true);
		settingsButton.SetBool("isHidden", true);
		highscoreButton.SetBool("isHidden", true);
		dialog.SetBool("isHidden", false);

	}


	public void CloseSettings() {
		startButton.SetBool("isHidden", false);
		settingsButton.SetBool("isHidden", false);
		highscoreButton.SetBool("isHidden", false);
		dialog.SetBool("isHidden", true);
	} */


}
