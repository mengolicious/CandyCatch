using UnityEngine;
using System.Collections;

public class HighScoreManagerScript : MonoBehaviour
{

	// Use this for initialization


	public static HighScoreManagerScript Instance
	{
		get;
		set;
	}

	void Awake ()
	{
		DontDestroyOnLoad (transform.gameObject);
		if (Instance == null)
		{
			Instance=this;
		}
		else if(Instance != this)
		{
			Destroy (gameObject);
		}
	}

	void Start ()
	{
		if(!PlayerPrefs.HasKey("First Initialization"))
		{
			PlayerPrefs.SetInt("First Initialization",1);

			PlayerPrefs.SetString("EE_Top1_Name_Easy", "AAA");
			PlayerPrefs.SetString("EE_Top2_Name_Easy", "BBB");
			PlayerPrefs.SetString("EE_Top3_Name_Easy", "CCC");

			PlayerPrefs.SetInt("EE_Top1_Score_Easy", 000);
			PlayerPrefs.SetInt("EE_Top2_Score_Easy", 000);
			PlayerPrefs.SetInt("EE_Top3_Score_Easy", 000);

			PlayerPrefs.SetString("EE_Top1_Name_Advance", "MC1");
			PlayerPrefs.SetString("EE_Top2_Name_Advance", "MC2");
			PlayerPrefs.SetString("EE_Top3_Name_Advance", "MC3");
			
			PlayerPrefs.SetInt("EE_Top1_Score_Advance", 000);
			PlayerPrefs.SetInt("EE_Top2_Score_Advance", 000);
			PlayerPrefs.SetInt("EE_Top3_Score_Advance", 000);

			PlayerPrefs.SetString("EE_Top1_Name_Expert", "CK1");
			PlayerPrefs.SetString("EE_Top2_Name_Expert", "CK2");
			PlayerPrefs.SetString("EE_Top3_Name_Expert", "CK3");
			
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
	void Update ()
	{
	
	}

	public void SaveHighScore()
	{

	}
}