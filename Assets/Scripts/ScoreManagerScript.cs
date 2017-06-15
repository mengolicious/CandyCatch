using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreManagerScript : MonoBehaviour {

	public int score;
	public int targetScore;
	public int targetTime;
	public int totalScore;
	public int pointToAdd;
	public int tempNum;
	public int lives;
	private int BGObjScoreRemain;

	public Object collectiblePrefab;
	public GameObject tempCollectible;

	public string tempString;

	public char tempChar;
	public string scoreString;
	//Answer to current question
	public int currentAnswerInSM;
	//Answer held in claw
	public int playerAnswerInSM;
	public Image question;
	public QuestionManagerScript QM_Script;
	public TimeManagerScript TM_Script;
	public GameObject questionBox;
	public GameObject scoreNum1;
	public GameObject scoreNum2;
	public GameObject targetScoreNum1;
	public GameObject targetScoreNum2;

	public Image scoreNumImage1;
	public Image scoreNumImage2;
	public List<Sprite> listNumImage;
	public Sprite num0;
	public Sprite num1;
	public Sprite num2;
	public Sprite num3;
	public Sprite num4;
	public Sprite num5;
	public Sprite num6;
	public Sprite num7;
	public Sprite num8;
	public Sprite num9;

	public Image tempSprite;


	public int tempImg;
	public char tempCharImg;
	public GameObject marshNum1;
	public GameObject marshNum2;
	public GameObject marshNum3;
	public GameObject marshNum4;
	public GameObject marshNum5;
	public Sprite marshNumImg1;
	public Sprite marshNumImg2;


	public GameObject bonusScreen;
	public GameObject winScreen;
	public GameObject loseScreen;
	public GameObject textInputField;
	public Sprite loseScreenImg;
	public Sprite winScreenImg;

	//public string playerName;	//this is for input of the player for high score

	public GM_1 gM_1;

	public GameObject pauseButton;

	public List<GameObject> marshMLives;

	public GameObject insertScore;
	public int tempHighScoreIndex;
	public enum ScoreSource
	{
		BackGroundObj,
		Colllectible,
		Ball,
		Bee,
		AngryBee,
		QueenBee
	}

	
	// Use this for initialization
	void Start ()
	{
		lives = 5;
		pointToAdd = 5;

		//testing
		targetScore = SVM_Script.targetScore;
		BGObjScoreRemain = (int)(targetScore * 0.2f);
		tempHighScoreIndex = 0;

		score = 0;
		totalScore = 0;

		//insertScore.SetActive(false);
		//DisplayScore ();
		//END testing
		listNumImage = new List<Sprite> ();
		listNumImage.Add (num0);
		listNumImage.Add (num1);
		listNumImage.Add (num2);
		listNumImage.Add (num3);
		listNumImage.Add (num4);
		listNumImage.Add (num5);
		listNumImage.Add (num6);
		listNumImage.Add (num7);
		listNumImage.Add (num8);
		listNumImage.Add (num9);

		//DisplayScore ();

		marshMLives = new List<GameObject> ();
		marshMLives.Add (marshNum1);
		marshMLives.Add (marshNum2);
		marshMLives.Add (marshNum3);
		marshMLives.Add (marshNum4);
		marshMLives.Add (marshNum5);

		DisplayScore (targetScoreNum1,targetScoreNum2,targetScore);

		//StartCoroutine (BeeSpawn ());

		StartCoroutine (CollectibleSpawn ());

		//loseScreen.SetActive (false);
	}

	IEnumerator CollectibleSpawn(){

		while(true){
			if(lives <2)
			{
				tempCollectible = Instantiate(collectiblePrefab, this.gameObject.transform.localPosition, Quaternion.identity) as GameObject;
			}
			yield return new WaitForSeconds(10f);
		}
	}

	public bool EditScore(int changeScore, ScoreSource srcType)//tag of the object that changed the score, to 
	{
		if(srcType == ScoreSource.BackGroundObj)
		{
			if(BGObjScoreRemain <=0)
				return false;
			BGObjScoreRemain -= changeScore;
		}
		score += changeScore;
		if(score < 0)
			score = 0;
		DisplayScore(scoreNum1, scoreNum2, score);
		return true;
	}

	public void DisplayScore(GameObject num1, GameObject num2, int tempChangeValue)
	{
		if(tempChangeValue > 99)
			tempChangeValue = 99;
		scoreString = tempChangeValue.ToString ();

		//Debug.Log (scoreString.Length);

		if (scoreString.Length == 1)
		{
			tempChar = scoreString[0];
			tempNum = (int)char.GetNumericValue(tempChar);
			num1.GetComponent<Image> ().sprite = listNumImage [tempNum];
			num2.GetComponent<Image> ().sprite = listNumImage [0];
		} else
		{

			tempChar = scoreString[1];
			tempNum = (int)char.GetNumericValue(tempChar);
			num1.GetComponent<Image> ().sprite = listNumImage[tempNum];
			//scoreNum2.GetComponent<Image> ().sprite = listNumImage[scoreString[0]];

			tempChar = scoreString[0];
			tempNum = (int)char.GetNumericValue(tempChar);
			num2.GetComponent<Image> ().sprite = listNumImage[tempNum];

			
		}
	}



	/// <summary>
	/// Checks if the answer is correct and updates that score if it is, otherwise updates the lives.
	/// </summary>
	/// <returns><c>true</c> If answer is correct, <c>false</c> otherwise.</returns>
	/// <param name="ballScoreValue">Ball score value.</param>
	public bool CheckScore(int ballScoreValue){

		//when answer is right
		if (currentAnswerInSM == playerAnswerInSM) {
			score += ballScoreValue;
			DisplayScore(scoreNum1, scoreNum2, score); 

			if(score>=targetScore){
				if(TM_Script.elapsedTime < SVM_Script.Instance.targetTime){

					bonusScreen.SetActive(true);
					gM_1.PauseGame();
					pauseButton.SetActive (false);
					SVM_Script.Instance.isBonus = true;
					SVM_Script.Instance.bonusTime = targetTime - TM_Script.elapsedTime;
					TM_Script.BonusTime = SVM_Script.Instance.bonusTime;
					ComputeTotalScore();
				}
				else
				{
					winScreen.SetActive(true);
					//winScreen.GetComponent<Image> ().sprite = winScreenImg;

					gM_1.PauseGame();
					pauseButton.SetActive (false);

					if (SVM_Script.gameDifficulty=="easy")
					{
						tempString="Easy";
						if(SVM_Script.advanceIsLocked){
							SVM_Script.advanceIsLocked=false;
							PlayerPrefs.SetInt("EE_advance",1);
						}
					}else if(SVM_Script.gameDifficulty=="advance")
					{
						tempString="Advance";
						if(SVM_Script.expertIsLocked){
							SVM_Script.expertIsLocked=false;
							PlayerPrefs.SetInt("EE_expert",1);
						}
					}
					else if(SVM_Script.gameDifficulty=="expert")
					{
						tempString="Expert";
					}

					ComputeTotalScore(); //this is for saving highscores
					//print (totalScore);
					//Debug.Log ("itsGoingHere");

					//show score on winScreen
				}
			}
			//Debug.Log ("Correct Answer");
			return true;
		} 
		//when answer is wrong
		else
		{ 
			LoseLife (); 
			CheckLives ();
			return false;
		}
	}

	public void ComputeTotalScore()
	{
		totalScore = Mathf.FloorToInt((float)((float)score / (float)TM_Script.elapsedTime)*100f*lives);
		if (!SVM_Script.Instance.isBonus)
		{
			CheckHighScore();
		}
	}

	public void CheckHighScore()
	{
		//Might need to do some other stuff with total score / bonus points here or elsewhere
		if (totalScore >= PlayerPrefs.GetInt("EE_Top1_Score_" + tempString))
		{
			insertScore.transform.parent.gameObject.SetActive(true);
			SoundManagerScript.Instance.Play_SFX("HighScore");
			PlayerPrefs.SetInt("EE_Top3_Score_" + tempString, PlayerPrefs.GetInt("EE_Top2_Score_" + tempString));
			PlayerPrefs.SetString("EE_Top3_Name_" + tempString, PlayerPrefs.GetString("EE_Top2_Name_" + tempString));
			PlayerPrefs.SetInt("EE_Top2_Score_" + tempString, PlayerPrefs.GetInt("EE_Top1_Score_" + tempString));
			PlayerPrefs.SetString("EE_Top2_Name_" + tempString, PlayerPrefs.GetString("EE_Top1_Name_" + tempString));

			PlayerPrefs.SetInt("EE_Top1_Score_" + tempString, (int)totalScore);
			SVM_Script.Instance.highScoreIndex = 1;
		}
		else if (totalScore >= PlayerPrefs.GetInt("EE_Top2_Score_" + tempString))
		{
			insertScore.transform.parent.gameObject.SetActive(true);
			SoundManagerScript.Instance.Play_SFX("HighScore");
			PlayerPrefs.SetInt("EE_Top3_Score_" + tempString, PlayerPrefs.GetInt("EE_Top2_Score_" + tempString));
			PlayerPrefs.SetInt("EE_Top2_Score_" + tempString, (int)totalScore);
			SVM_Script.Instance.highScoreIndex = 2;
		}
		else if (totalScore >= PlayerPrefs.GetInt("EE_Top3_Score_" + tempString))
		{
			insertScore.transform.parent.gameObject.SetActive(true);
			SoundManagerScript.Instance.Play_SFX("HighScore");
			PlayerPrefs.SetInt("EE_Top3_Score_" + tempString, (int)totalScore);
			SVM_Script.Instance.highScoreIndex = 3;
		}
		else
		{
			SVM_Script.Instance.highScoreIndex = 0;
		}
		insertScore.transform.GetChild(3).GetComponent<Text>().text = "Total = " + totalScore.ToString() + " :";
		insertScore.transform.GetChild(5).GetComponent<Text>().text = score.ToString();
		insertScore.transform.GetChild(7).GetComponent<Text>().text = " X " + lives.ToString();
		insertScore.transform.GetChild(9).GetComponent<Text>().text = TM_Script.minutesStr + ":" + TM_Script.secondsStr;
	}

	public void SetTopScoreName()
	{
		string inputText = insertScore.GetComponent<InputField>().text;
		//Debug.Log(inputText);
		PlayerPrefs.SetString("EE_Top" + SVM_Script.Instance.highScoreIndex + "_Name_" + tempString, inputText);
	}

	public void LoseLife()
	{
		lives -= 1;
		marshMLives[lives].GetComponent<Image>().sprite=marshNumImg2;
	}

	public void GainLife()
	{
		marshMLives[lives].GetComponent<Image>().sprite=marshNumImg1;
		lives += 1;
	}

	public void CheckLives()
	{
		if (lives < 1)
		{
			loseScreen.SetActive (true);

			loseScreen.GetComponent<Image> ().sprite = loseScreenImg;
			gM_1.PauseGame();
			pauseButton.SetActive (false);
		}
	}

	public bool VerifyAnswer()
	{
		if (playerAnswerInSM == currentAnswerInSM)
			return true;
		else
			return false;
	}
}
