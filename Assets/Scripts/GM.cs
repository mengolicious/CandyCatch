using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class GM : MonoBehaviour {

	//private HighScoreDisplayManagerScript HSDM_Script;

	private SoundManagerScript SoundManager_Script;

	public GameObject playGamePanel;
	public GameObject topScorePanel;
	public GameObject creditsPanel;
	public GameObject difficultyPanel;

	public GameObject advanceDifficulty;
	public GameObject advanceDifficultyLock;
	public GameObject expertDifficulty;
	public GameObject expertDifficultyLock;

	//public GameObject targetPanel1;

	
	public GameObject buttonSound;

	// Use this for initialization
	void Start()
	{
		//HSDM_Script = GameObject.FindGameObjectWithTag("High Score Display Manager").GetComponent<HighScoreDisplayManagerScript>();
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

	void OnMouseDown()
	{
		Debug.Log (Input.mousePosition);
	}

	public void RateOurAppButton()
	{
		#if UNITY_ANDROID
		Application.OpenURL("market://details?id=com.mccormickbytes.CandyCatch");
		#elif UNITY_APPLE
		Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_APP_ID");
		#endif
	}

	public void NCCCWebsite()
	{
		#if !UNITY_APPLE
		Application.OpenURL("http://nccc.org.au/"); 
		#endif
	}

	public void MBWebsite()
	{
		#if !UNITY_APPLE
		Application.OpenURL ("http://www.mccormickbytes.org/");
		#endif
	}

	public void MuteButton()
	{
		SoundManager_Script.ButtonAudio();
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


	// start of Functions called to load 
	public void LevelOne_Easy()
	{ 
		SoundManager_Script.Play_SFX("MenuNav2");

		SVM_Script.targetScore = 50;
		SVM_Script.gameDifficulty = "easy";
		SVM_Script.Instance.targetTime = 120; //Find a good balance between beating it if no mistakes are made and having a low enough time to make the bonus stage not feel too long
		SVM_Script.Instance.LoadLevel("Enticing Equations");
	}

	public void LevelOne_Advance()
	{
		SoundManager_Script.Play_SFX("MenuNav2");

		SVM_Script.targetScore = 75;
		SVM_Script.gameDifficulty = "advance";
		SVM_Script.Instance.targetTime = 180; //add a resonable amount to this to make it higher than easy but increases by maybe the same step on Expert
		SVM_Script.Instance.LoadLevel("Enticing Equations");
	}

	public void LevelOne_Expert ()
	{ 
		SoundManager_Script.Play_SFX("MenuNav2");

		SVM_Script.targetScore = 90;
		SVM_Script.gameDifficulty = "expert";
		SVM_Script.Instance.targetTime = 240; //a ditto was his father, and raised him in his mothers stead
		SVM_Script.Instance.LoadLevel("Enticing Equations");
	}

	//when level 2 button pressed change scene to Level 2 alphabet
	public void LevelTwo ()
	{
		//Application.LoadLevel ("AlphabetLV2");
	}
	
	//when level 3 button pressed change scene to Level 3 numbers
	public void LevelThree ()
	{ 
		//Application.LoadLevel ("NumbersLV3");
	}

}
