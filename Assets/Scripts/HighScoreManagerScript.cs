using UnityEngine;
using System.Collections;

public class HighScoreManagerScript : MonoBehaviour {

	// Use this for initialization


	public static HighScoreManagerScript Instance {
		get;
		set;
	}

	void Awake () {
		
		DontDestroyOnLoad (transform.gameObject);
		if (Instance == null) {
			Instance=this;
		}
		else if(Instance != this){
			Destroy (gameObject);
		}
		
		
	}

	void Start () {

		if(!PlayerPrefs.HasKey("First Initialization")){
			PlayerPrefs.SetInt("First Initialization",1);

			PlayerPrefs.SetString("EE_Top1_Name_Easy", "AAA");
			PlayerPrefs.SetString("EE_Top2_Name_Easy", "AAA");
			PlayerPrefs.SetString("EE_Top3_Name_Easy", "AAA");

			PlayerPrefs.SetInt("EE_Top1_Score_Easy", 800);
			PlayerPrefs.SetInt("EE_Top2_Score_Easy", 500);
			PlayerPrefs.SetInt("EE_Top3_Score_Easy", 100);

			PlayerPrefs.SetString("EE_Top1_Name_Advance", "MCK");
			PlayerPrefs.SetString("EE_Top2_Name_Advance", "MCK");
			PlayerPrefs.SetString("EE_Top3_Name_Advance", "MCK");
			
			PlayerPrefs.SetInt("EE_Top1_Score_Advance", 000);
			PlayerPrefs.SetInt("EE_Top2_Score_Advance", 000);
			PlayerPrefs.SetInt("EE_Top3_Score_Advance", 000);

			PlayerPrefs.SetString("EE_Top1_Name_Expert", "MCK");
			PlayerPrefs.SetString("EE_Top2_Name_Expert", "MCK");
			PlayerPrefs.SetString("EE_Top3_Name_Expert", "MCK");
			
			PlayerPrefs.SetInt("EE_Top1_Score_Expert", 000);
			PlayerPrefs.SetInt("EE_Top2_Score_Expert", 000);
			PlayerPrefs.SetInt("EE_Top3_Score_Expert", 000);
		}
	
	}

	void OnApplicationQuit()
	{
		PlayerPrefs.Save();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SaveHighScore(){

	}
}