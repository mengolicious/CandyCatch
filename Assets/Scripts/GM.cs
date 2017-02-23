using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GM : MonoBehaviour {

	public HighScoreDisplayManagerScript HSDM_Script;

	public GameObject playGamePanel;
	public GameObject topScorePanel;
	public GameObject creditsPanel;
	public GameObject difficultyPanel;

	public GameObject advanceDifficulty;
	public GameObject advanceDifficultyLock;
	public GameObject expertDifficulty;
	public GameObject expertDifficultyLock;

	
	public GameObject buttonSound;
	new AudioSource audio;
	
	
	
	
	// Use this for initialization
	void Start () {
		//Original sprite before click
		playGamePanel.SetActive (false);
		topScorePanel.SetActive (false);
		creditsPanel.SetActive (false);
		

		audio = buttonSound.GetComponent<AudioSource> ();
		Time.timeScale = 1.0f;
		CheckDifficultyLock ();
		
		
	}
	
	// Update is called once per frame
	void Update () {



	}

	public void CheckDifficultyLock(){

		if (!SVM_Script.advanceIsLocked) {
			advanceDifficulty.GetComponent<Button> ().interactable = true;
			advanceDifficultyLock.SetActive (false);
		} else {
			advanceDifficulty.GetComponent<Button> ().interactable = false;
			advanceDifficultyLock.SetActive (true);
		}

		if (!SVM_Script.expertIsLocked) {
			expertDifficulty.GetComponent<Button> ().interactable = true;
			expertDifficultyLock.SetActive (false);
		} else {
			expertDifficulty.GetComponent<Button> ().interactable = false;
			expertDifficultyLock.SetActive (true);

		}
	}

	public void RelockDifficulties(){
		PlayerPrefs.SetInt ("EE_advance", 0);
		SVM_Script.advanceIsLocked = true;
		
		PlayerPrefs.SetInt ("EE_expert", 0);
		SVM_Script.expertIsLocked = true;
		
		CheckDifficultyLock ();
	}
	
	//Toggle campaign sprite when clicked


	public void DisablePanel(GameObject parentPanel){
		parentPanel.SetActive (false);
	}
	public void EnablePanel(GameObject targetPanel){
		targetPanel.SetActive (true);
	}


	//when level 1 button pressed change scene to Level 1 shape
	public void LevelOne_Easy (){ 
		SVM_Script.targetScore=50;
		Application.LoadLevel ("ShapesLV1"); 
		SVM_Script.gameDifficulty = "easy";
	}

	public void LevelOne_Advance (){ 
		SVM_Script.targetScore=75;
		Application.LoadLevel ("ShapesLV1"); 
		SVM_Script.gameDifficulty = "advance";
	}

	public void LevelOne_Expert (){ 
		SVM_Script.targetScore=95;
		Application.LoadLevel ("ShapesLV1"); 
		SVM_Script.gameDifficulty = "expert";
	}

	//when level 1 button pressed change scene to Level 2 alphabet
	public void LevelTwo (){ 
	
		Application.LoadLevel ("AlphabetLV2"); 

	}
	
	//when level 1 button pressed change scene to Level 3 numbers
	public void LevelThree (){ 

		Application.LoadLevel ("NumbersLV3"); 

	}
	
	
	//Back Button when pressed, loads main menu
	public void BackButton () {
		Application.LoadLevel ("MainScene");
	}
	
	//Play audio source when button is pressed
	public void ButtonAudio () {
		audio.Play();
		
	} 
	
}
