using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreDisplayManagerScript : MonoBehaviour {

	public Text top1Easy;
	public Text top2Easy;
	public Text top3Easy;

	public Text top1Advance;
	public Text top2Advance;
	public Text top3Advance;

	public Text top1Expert;
	public Text top2Expert;
	public Text top3Expert;





	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

	}

	public void QueryHighScore(){
		//top1Easy.text = "test";
		//top1Easy.text = PlayerPrefs.GetString ("EE_Top1_Name_Easy");



		top1Easy.text = PlayerPrefs.GetString("EE_Top1_Name_Easy")+" - "+PlayerPrefs.GetInt("EE_Top1_Score_Easy");
		top2Easy.text = PlayerPrefs.GetString("EE_Top2_Name_Easy")+" - "+PlayerPrefs.GetInt("EE_Top2_Score_Easy");
		top3Easy.text = PlayerPrefs.GetString("EE_Top3_Name_Easy")+" - "+PlayerPrefs.GetInt("EE_Top3_Score_Easy");

		top1Advance.text = PlayerPrefs.GetString("EE_Top1_Name_Advance")+" - "+PlayerPrefs.GetInt("EE_Top1_Score_Advance");
		top2Advance.text = PlayerPrefs.GetString("EE_Top2_Name_Advance")+" - "+PlayerPrefs.GetInt("EE_Top2_Score_Advance");
		top3Advance.text = PlayerPrefs.GetString("EE_Top3_Name_Advance")+" - "+PlayerPrefs.GetInt("EE_Top3_Score_Advance");

		top1Expert.text = PlayerPrefs.GetString("EE_Top1_Name_Expert")+" - "+PlayerPrefs.GetInt("EE_Top1_Score_Expert");
		top2Expert.text = PlayerPrefs.GetString("EE_Top2_Name_Expert")+" - "+PlayerPrefs.GetInt("EE_Top2_Score_Expert");
		top3Expert.text = PlayerPrefs.GetString("EE_Top3_Name_Expert")+" - "+PlayerPrefs.GetInt("EE_Top3_Score_Expert");
	
	}
}
