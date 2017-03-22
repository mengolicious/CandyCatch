using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class GM : MonoBehaviour {

	private HighScoreDisplayManagerScript HSDM_Script;

	private SoundManagerScript SoundManager_Script;

	public GameObject playGamePanel;
	public GameObject topScorePanel;
	public GameObject creditsPanel;
	public GameObject difficultyPanel;

	public GameObject advanceDifficulty;
	public GameObject advanceDifficultyLock;
	public GameObject expertDifficulty;
	public GameObject expertDifficultyLock;

	
	public GameObject buttonSound;

	// Use this for initialization
	void Start ()
	{
		HSDM_Script = GameObject.FindGameObjectWithTag("High Score Display Manager").GetComponent<HighScoreDisplayManagerScript>();
		SoundManager_Script = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManagerScript> ();
		
		//Original sprite before click
		playGamePanel.SetActive (false);
		topScorePanel.SetActive (false);
		creditsPanel.SetActive (false);
		
		Time.timeScale = 1.0f;
		CheckDifficultyLock ();

		//Sounds manager Mute button work around and starting back ground music 
		SoundManager_Script.GetMuteButton();
		SoundManager_Script.Play_BG_loop("bg1");
	}

	public void MuteButton()
	{
		SoundManager_Script.ButtonAudio();
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	public void CheckDifficultyLock()
	{
		if(!SVM_Script.advanceIsLocked)
		{
			advanceDifficulty.GetComponent<Button>().interactable = true;
			advanceDifficultyLock.SetActive (false);
		}
		else
		{
			advanceDifficulty.GetComponent<Button>().interactable = false;
			advanceDifficultyLock.SetActive (true);
		}

		if(!SVM_Script.expertIsLocked)
		{
			expertDifficulty.GetComponent<Button>().interactable = true;
			expertDifficultyLock.SetActive (false);
		}
		else
		{
			expertDifficulty.GetComponent<Button>().interactable = false;
			expertDifficultyLock.SetActive (true);
		}
	}

	public void RelockDifficulties()
	{
		PlayerPrefs.SetInt ("EE_advance", 0);
		SVM_Script.advanceIsLocked = true;
		
		PlayerPrefs.SetInt ("EE_expert", 0);
		SVM_Script.expertIsLocked = true;
		
		CheckDifficultyLock ();
	}
	
	//Toggle campaign sprite when clicked



	public void DisablePanel(GameObject parentPanel)
	{
		SoundManager_Script.Play_SFX("MenuNav2");

		parentPanel.SetActive (false);
	}

	public void EnablePanel(GameObject targetPanel)
	{
		targetPanel.SetActive (true);
	}


	//when level 1 button pressed change scene to Level 1 shape
	public void LevelOne_Easy ()
	{ 
		SoundManager_Script.Play_SFX("MenuNav2");

		SVM_Script.targetScore=50;
		Application.LoadLevel ("ShapesLV1"); 
		SVM_Script.gameDifficulty = "easy";
	}

	public void LevelOne_Advance ()
	{
		SoundManager_Script.Play_SFX("MenuNav2");

		SVM_Script.targetScore=75;
		Application.LoadLevel ("ShapesLV1"); 
		SVM_Script.gameDifficulty = "advance";
	}

	public void LevelOne_Expert ()
	{ 
		SoundManager_Script.Play_SFX("MenuNav2");

		SVM_Script.targetScore=90;
		Application.LoadLevel ("ShapesLV1"); 
		SVM_Script.gameDifficulty = "expert";
	}

	//when level 1 button pressed change scene to Level 2 alphabet
	public void LevelTwo ()
	{
		Application.LoadLevel ("AlphabetLV2");
	}
	
	//when level 1 button pressed change scene to Level 3 numbers
	public void LevelThree ()
	{ 
		Application.LoadLevel ("NumbersLV3");
	}
	
	
	//Back Button when pressed, loads main menu
	public void BackButton ()
	{
		SoundManager_Script.Play_SFX("MenuNavPop");
		Application.LoadLevel ("MainScene");
	}
	//Play audio source when button is pressed

	
}
