using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class SVM_Script : MonoBehaviour {


	public static GameObject advanceDifficulty;
	public static GameObject advanceDifficultyLock;
	public static GameObject expertDifficulty;
	public static GameObject expertDifficultyLock;

	public static string gameDifficulty;
	public static int targetScore = 50;
	public static bool advanceIsLocked = true;
	public static bool expertIsLocked = true;
	public static bool InstructionSeen = false;
	public GM GM_Script;
	public static bool gameSetup;
		// Make global
	public static SVM_Script Instance {
			get;
			set;
	}
		


	void Awake () {

		InitializeSavedVariables (); 	//Initialize variables that needs to be saved when APP is closed
		LoadSavedVariables ();			//Load the variables from Playerprefs

		DontDestroyOnLoad (transform.gameObject);
		if (Instance == null) {
			Instance=this;
		}
		else if(Instance != this){
			Destroy (gameObject);
		}
	}

	public void InitializeSavedVariables(){
		if (!PlayerPrefs.HasKey ("EE_advance")) {
			PlayerPrefs.SetInt ("EE_advance", 0);
		} else {

		}

		if (!PlayerPrefs.HasKey ("EE_expert")) {
			PlayerPrefs.SetInt ("EE_expert", 0);
		} else {

		}
		if (!PlayerPrefs.HasKey ("Instructions_Dismissed")) {
			PlayerPrefs.SetInt ("Instructions_Dismissed", 0);
		} else {
			
		}
	}

	public void LoadSavedVariables(){
		if (PlayerPrefs.GetInt ("EE_advance") == 1) {
			advanceIsLocked = false;
		} else {
			advanceIsLocked = true;
		}

		if (PlayerPrefs.GetInt ("EE_expert") == 1) {
			expertIsLocked = false;
		} else {
			expertIsLocked = true;
		}
		if(PlayerPrefs.GetInt("Instructions_Dismissed") == 1)
		{
			InstructionSeen = true;
		} else {
			InstructionSeen = false;
		}
	}
}
