using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GM_1 : MonoBehaviour
{
	public Canvas canvas;

	public SoundManagerScript SoundManager_Script;
	public BeeMScript BeeM_Script; 	//this script is attached manually
	public int numBalls = 5;
	public Object balls;
	public GunScript gunScript;
	public QuestionManagerScript questionManagerScript;
	public Sprite currentQuestion;
	public int currentAnswer;
	public GameObject smokeSprite;
	public Image smokeSpriteImageComponent;
	public GameObject smokeSpriteSmol;
	public Image smokeSpriteSmolImageComponent;
	public GameObject smallQuestionDisplay;
	public Image smallQuestionDisplayImage;
	public GameObject bigQuestionDisplay;
	public GameObject bigQuestionBG;
	public Object QuestionMovingPart_Object;
	public GameObject QuestionMovingPart_GameObject;
	public Vector3 QuestionMovingPart_EndPos;

	//END of BG variables for instatiating BG and it's components
	public GameObject BG;
	public Object BG_Easy;
	public Object BG_Advance;
	public Object BG_Expert;
	//END of BG variables for instatiating BG and it's components

	public ScoreManagerScript SM_Script;
	//public float bigQuestionBGTime = 5f;

	//Start for BG Variables
	public SpriteRenderer stageSpriteRendererBG;
	public Sprite equationEasy;
	public Sprite equationAdvance;
	public Sprite equationExpert;

	//Start this is for Target Score
	public Image targetScoreImage;
	public Sprite easyTargetScore;
	public Sprite advanceTargetScore;
	public Sprite expertTargetScore;
	//END this is for Target Score

	//Start this is for Target Time
	public Image targetTimeImage;
	public Sprite easyTargetTime;
	public Sprite advanceTargetTime;
	public Sprite expertTargetTime;
	//END this is for Target TIme

	public bool gameHasStarted;
	public bool gameIsPaused;
	public bool isShooting;
	
	public GameObject ballPrefabs;
	/*public Material matBall0;
	public Material matBall1;
	public Material matBall2;
	public Material matBall3;
	public Material matBall4;
	public Material matBall5;
	public Material matBall6;
	public Material matBall7;
	public Material matBall8;
	public Material matBall9;*/
	public List<Material> matBallList; 

	public GameObject pauseMenu;
	public GameObject pauseButton;

	public List<Vector3> listPosition;
	public Vector3 firstLayer;
	public Vector3 secondLayer;
	public int tempNum;
	public int numberOfBalls=10;
	public float tempX;
	
	public GameObject nextDifficultyButton;

	public GameObject InstructionPanelBG;
	public GameObject InstructionPanel1;
	public GameObject tempDestroyObject;

	//public float shooterSpeed;
	//public float animSpeed;
	public TimeManagerScript TM;
	bool isSwitching;
	//public GameObject LoadingScreen;
	// Use this for initialization
	void Start()
	{
		SoundManager_Script = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript> ();
		Time.timeScale = 0;	//Pause time at the start
		GetBG();			// Get the appropriate BG for the Game

		gameHasStarted = false;
		gameIsPaused = true;

		tempX = -8.2f;
		matBallList = new List<Material>();
		isSwitching = false;
		/*matBallList.Add (matBall0);
		matBallList.Add (matBall1);
		matBallList.Add (matBall2);
		matBallList.Add (matBall3);
		matBallList.Add (matBall4);
		matBallList.Add (matBall5);
		matBallList.Add (matBall6);
		matBallList.Add (matBall7);
		matBallList.Add (matBall8);
		matBallList.Add (matBall9);*/
		
		firstLayer = new Vector3(-7.32f,-2.65f,259.0f);
		secondLayer = new Vector3(-6.07f,-4.07f,259.0f);
		listPosition = new List<Vector3>();
		/*
		for(int x=0; x<8; x++){
			listPosition.Add ( new Vector3(firstLayer.x+(2.2f*x), firstLayer.y, firstLayer.z));
			listPosition.Add ( new Vector3(secondLayer.x+(2.2f*x), secondLayer.y, secondLayer.z));
		}
		*/
		QuestionMovingPart_EndPos = new Vector3 (-5.5f,-6,-3);

		pauseMenu.SetActive(true);
		bigQuestionBG.SetActive(false);
		smokeSprite.SetActive(false);
		smokeSpriteSmol.SetActive(false);
		smallQuestionDisplay.SetActive(false);
		if(!SVM_Script.InstructionSeen)
		{
			pauseMenu.SetActive(false);
			InstructionPanelBG.SetActive(true);
			InstructionPanel1.SetActive(true);
		}

		if(SVM_Script.gameDifficulty == "easy")
		{
			BG = Instantiate(BG_Easy, new Vector3(0,-1.6f,262), Quaternion.identity ) as GameObject;
			BG.transform.localScale = new Vector3(1.12f, 1.12f,1);

			//shooterSpeed = 0.5f;
			//anim["ShooterAnime"].speed = shooterSpeed;

			//animM.GetComponent<Animator>().speed = 0.1f;
			//animSpeed = 0.2f;
			gunScript.shooterAnimator.SetFloat("speed",0.2f);
			SetMaterials("Set 1"); //setting materials of Balls for easy
		}
		else if(SVM_Script.gameDifficulty == "advance")
		{

			BG = Instantiate(BG_Advance, new Vector3(0,-1.6f,262), Quaternion.identity ) as GameObject;
			BG.transform.localScale = new Vector3(1.12f, 1.12f,1);

			//animM.GetComponent<Animator>().speed = 0.5f;
			//shooterSpeed = 3.5f;	
			//animSpeed = 0.3f;
			gunScript.shooterAnimator.SetFloat("speed",0.3f);

			SetMaterials("Set 2"); //setting materials of Balls for advance
		}
		else if(SVM_Script.gameDifficulty == "expert")
		{

			BG = Instantiate(BG_Expert, new Vector3(0,-1.6f,262), Quaternion.identity ) as GameObject;
			BG.transform.localScale = new Vector3(1.12f, 1.12f,1);
			nextDifficultyButton.SetActive(false);
			//animM.GetComponent<Animator>().speed = 1.0f;
			//animSpeed = 0.4f;
			gunScript.shooterAnimator.SetFloat("speed",0.4f);
			//shooterSpeed= 5f;

			SetMaterials("Set 3"); //setting materials of Balls for expert
		}
		//animM.GetComponent<Animator>().SetFloat("speed",0f);
		//Debug.Log(animM.GetComponent<Animator>().GetFloat("speed"));
		//also move this to to easy bg script when made
		SpawnBalls();
	}


	public void SetMaterials(string tempSet){

		for(int i = 0; i < 10; i++)
		{
			
			matBallList.Add(Resources.Load<Material>("Materials/"+tempSet+"/Ball_MAT"+i));
		}
	}

	public void DestroyInstatiatedBalls(string tag)
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
		foreach(GameObject ball in objects)
		{
			ball.GetComponent<BallScript>().DestroyInstantiate();
		}

		/*for(int i=0; i<objects.Length; i++)
		{
			objects[i].GetComponent<BallScript>().DestroyInstantiate();
		}*/
	}

	public void SpawnBalls()
	{
		//listPosition.Clear();

		/*
		for(int x=0; x<numberOfBalls; x++){
			tempNum = Random.Range (0, listPosition.Count);
			ballPrefabs = Instantiate (balls, listPosition[tempNum],Quaternion.Euler(-90, 18, 0)) as GameObject;
			listPosition.RemoveAt(tempNum);

			ballPrefabs.GetComponent<BallScript>().points = x;
			ballPrefabs.GetComponent<BallScript>().scoreValue = 5;
			ballPrefabs.transform.localEulerAngles = new Vector3(270,196,0);
			ballPrefabs.GetComponent<Renderer>().material = matBallList[x];

			//renderer.material = newMaterialRef;
		}*/

		StartCoroutine(BallSpawner());
	}

	IEnumerator BallSpawner()
	{
		tempX = -8.2f;
		for(int x=0; x<10; x++)
		{
			tempX += 1.5f;
			listPosition.Add(new Vector3(tempX, -(float)(Mathf.Sqrt(64-(tempX*tempX)))*0.65f, 259));
			//listPosition.Add(new Vector3(x, x, x));
		}
		for(int x=0; x<numberOfBalls; x++)
		{
			tempNum = Random.Range(0, listPosition.Count);
			ballPrefabs = Instantiate (balls, listPosition[tempNum],Quaternion.Euler(-90, 18, 0)) as GameObject;
			listPosition.RemoveAt(tempNum);
			
			ballPrefabs.GetComponent<BallScript>().points = x;
			ballPrefabs.GetComponent<BallScript>().scoreValue = 5;
			ballPrefabs.transform.localEulerAngles = new Vector3(270,0,0);
			ballPrefabs.GetComponent<Renderer>().material = matBallList[x];
			yield return null;
		}
	}

	public void GetBG()
	{
		if(SVM_Script.gameDifficulty == "easy")
		{
			//stageSpriteRendererBG.sprite = equationEasy;
			targetScoreImage.sprite = easyTargetScore;
			targetTimeImage.sprite = easyTargetTime;
			SM_Script.targetScore = SVM_Script.targetScore;
			SM_Script.targetTime = SVM_Script.Instance.targetTime; //Store target time


			//Play BG Music
			SoundManager_Script.Play_BG_loop("bg2");
		}
		else if(SVM_Script.gameDifficulty == "advance")
		{
			//stageSpriteRendererBG.sprite = equationAdvance;
			targetScoreImage.sprite = advanceTargetScore;
			targetTimeImage.sprite = advanceTargetTime;
			SM_Script.targetScore = SVM_Script.targetScore;
			SM_Script.targetTime = SVM_Script.Instance.targetTime; //Store target time

			//Play BG Music
			SoundManager_Script.Play_BG_loop("bg2");
		}
		else if(SVM_Script.gameDifficulty == "expert")
		{
			//stageSpriteRendererBG.sprite = equationExpert;
			targetScoreImage.sprite = expertTargetScore;
			targetTimeImage.sprite = expertTargetTime;
			SM_Script.targetScore = SVM_Script.targetScore;
			SM_Script.targetTime = SVM_Script.Instance.targetTime; //Store target time

			//Play BG Music
			SoundManager_Script.Play_BG_loop("bg2");
		}
	}

	//Vector3 RandomPos()
	//{
	//	int x, y, z;
	//	x = Random.Range(-2, 2);
	//	y = Random.Range(-1, 1);
	//	z = Random.Range(0, 0);
	//	return new Vector3(x, y, z);
	//}

	public void BackToMenu()
	{
		SoundManager_Script.Play_SFX("MenuNavPop");
		SoundManager_Script.Stop_BG_SFX();
		//LoadingScreen.SetActive(true);
		Time.timeScale = 1f;
		SVM_Script.Instance.LoadLevel("MainScene");
	}

	public void Restart()
	{
		SoundManager_Script.Play_SFX("MenuNavPop");
		SoundManager_Script.Stop_BG_SFX();
		//LoadingScreen.SetActive(true);
		Time.timeScale = 1f;
		SVM_Script.Instance.LoadLevel("Enticing Equations");
	}

	public void NextDiff()
	{
		SoundManager_Script.Stop_BG_SFX();
		if(SVM_Script.gameDifficulty == "easy")
		{
			SVM_Script.gameDifficulty = "advance";
			SVM_Script.targetScore = 75;
			return;
		}
		if(SVM_Script.gameDifficulty == "advance")
		{
			SVM_Script.gameDifficulty = "expert";
			SVM_Script.targetScore = 95;
			return;
		}
		/*switch (SVM_Script.gameDifficulty) {
		default: case "easy":  SVM_Script.gameDifficulty = "advance"; break;
		
		case "advance": SVM_Script.gameDifficulty = "expert"; break;
		}*/
	}

	public void StartGame()
	{
		SoundManager_Script.Play_SFX("MenuNavPop");

		pauseMenu.SetActive(false);
		bigQuestionBG.SetActive(true);
		GetNextQuestion();
		StartCoroutine(BigDisplayAnim());
	}

	public void ResetQuestion()
	{
		StartCoroutine(ResetQuestionEnumerator());
	}

	IEnumerator ResetQuestionEnumerator()
	{
		smallQuestionDisplay.SetActive(false);

		if(!SVM_Script.Instance.isBonus)
		{
			gunScript.canShoot = false;
			while(BeeM_Script.BeesAlive())
			{
				yield return new WaitForSeconds(0.1f);
			}
		}
		bigQuestionBG.SetActive(true);
		GetNextQuestion();
		StartCoroutine(BigDisplayAnim());
	}

	IEnumerator BigDisplayAnim()
	{
		yield return new WaitForSeconds(1.0f);

		if(!SVM_Script.Instance.isBonus)
		{
			gunScript.shooterAnimator.speed = 0.1f;
		}

		for(int x=0; x<20; x++)
		{
			bigQuestionBG.GetComponent<RectTransform>().localScale -= new Vector3 (0.03f, 0.03f, 0.03f);

			yield return new WaitForSeconds(0.03f);
		}
		StartCoroutine (SmokeSpriteAnim());
	}

	IEnumerator SmokeSpriteAnim()
	{
		smokeSprite.SetActive(true);
		//smokeSpriteSmol.SetActive(true); // placed in QuestionMovingParticleAction() IEnumerator
		for(int x=1; x<8; x++)
		{
			Sprite smokeOnTheWater = Resources.Load<Sprite>("Sprites/Smoke/Smoke"+x);
			smokeSpriteImageComponent.sprite = smokeOnTheWater;
			//smokeSpriteSmolImageComponent.sprite = smokeOnTheWater;
			yield return new WaitForSeconds(0.04f);
			if(x==4)
			{
				bigQuestionBG.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
				bigQuestionBG.SetActive(false);
			}
		}

		smokeSprite.SetActive(false);
		//smokeSpriteSmol.SetActive(false);

		//smallQuestionDisplay.SetActive(true);
		//smallQuestionDisplayImage.sprite = currentQuestion;

		//isShooting = false;
		//gunScript.canShoot = true;

		//gunScript.shooterAnimator.speed = 1; // shooter starts moving only once smoke appears.

		StartCoroutine (QuestionMovingParticleAction());
	}

	IEnumerator QuestionMovingParticleAction()
	{

		QuestionMovingPart_GameObject = Instantiate (QuestionMovingPart_Object, new Vector3(0,0,0), Quaternion.identity) as GameObject;
		QuestionMovingPart_GameObject.transform.SetParent (canvas.transform);

		while(Vector3.Distance(QuestionMovingPart_GameObject.transform.position, QuestionMovingPart_EndPos) > 0.01f){

			QuestionMovingPart_GameObject.transform.position =  Vector3.MoveTowards(QuestionMovingPart_GameObject.transform.position, QuestionMovingPart_EndPos, 15.0f  * Time.deltaTime); 

			yield return new WaitForSeconds (0.03f);
		}
		QuestionMovingPart_GameObject.GetComponent<QuestionPartScript> ().DestroyThisObject ();



		smokeSpriteSmol.SetActive(true);
		for(int x=1; x<8; x++)
		{
			Sprite smokeOnTheWater = Resources.Load<Sprite>("Sprites/Smoke/Smoke"+x);
			smokeSpriteSmolImageComponent.sprite = smokeOnTheWater;
			yield return new WaitForSeconds(0.04f);
		}

		smokeSpriteSmol.SetActive(false);
		smallQuestionDisplay.SetActive(true);
		smallQuestionDisplayImage.sprite = currentQuestion;
		if(!SVM_Script.Instance.isBonus)
		{
			isShooting = false;
			gunScript.canShoot = true;
			gunScript.shooterAnimator.speed = 1; // shooter starts moving only once smoke appears.
		}
	}



	public void GetNextQuestion()
	{
		currentQuestion = questionManagerScript.GetQuestion();
		currentAnswer = questionManagerScript.tempAnswer;

		bigQuestionDisplay.GetComponent<Image>().sprite = currentQuestion;
	}


	public void DisablePanel(GameObject parentPanel)
	{
		parentPanel.SetActive(false);
		if(gameHasStarted==false)
		{
			gameHasStarted=true;
			StartGame ();
		}
	}
	public void EnablePanel(GameObject targetPanel)
	{
		targetPanel.SetActive(true);
	}


	public void PauseGame()
	{
		SoundManager_Script.Play_SFX("MenuNavPop");
		SoundManager_Script.Pause_BG_SFX();
		//gunScript.canShoot = false;
		gameIsPaused = true;
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		SoundManager_Script.Play_SFX("MenuNavPop");
		SoundManager_Script.Resume_BG_SFX();
		//gunScript.canShoot = true;
		gameIsPaused = false;

		Time.timeScale = 1;

		//animM.GetComponent<Animator>().speed = 0.1f;
	}

	public void InstructionClose()
	{
		InstructionPanelBG.SetActive(false);
		PlayerPrefs.SetInt("Instructions_Dismissed",1);
		SVM_Script.InstructionSeen = true;
	}

	/// <summary>
	/// Switch everything to the bonus stage when the game has been qualified as being onto the bonus stage. Use this to remove all no longer needed objects when the Start Bonus Stage Panal appears.
	/// </summary>
	public void SwitchToBonusStage()
	{
		isSwitching = true;
		StopAllCoroutines();
		if(QuestionMovingPart_GameObject)
		{
			Destroy(QuestionMovingPart_GameObject);
		}
		gunScript.DestroyGunObject();
		DestroyInstatiatedBalls("balls");
		StartCoroutine(BonusStageSwitch());
	}

	/// <summary>
	/// Switches to the bonus stage over a number of frames.
	/// </summary>
	IEnumerator BonusStageSwitch()
	{
		Time.timeScale = 1f;
		BeeM_Script.SwitchToBonusRound();
		yield return null;
		questionManagerScript.SwitchToBonusRound();
		yield return null;
		SM_Script.SwitchToBonusRound();
		yield return null;
		TM.SwitchToBonusRound();
		Time.timeScale = 0f;
		isSwitching = false;
	}

	/// <summary>
	/// Starts the game into the bonus stage
	/// </summary>
	public void StartBonusStage(GameObject BonusPanel)
	{
		if(!isSwitching)
		{
			BonusPanel.SetActive(false);
			pauseButton.SetActive(true);
			ResumeGame();
			ResetQuestion();
		}
	}

	/// <summary>
	/// End the bonus stage with something else
	/// </summary>
	public void EndBonusStage()
	{
		SM_Script.EndBonusStage();
		BeeM_Script.EndBonuStage();
		//Add it here more make a function depending upon where we decide to store bonus score
		//SM_Script.totalScore += /*add the bonus score when it is strored*/;
		//call some func for bonus score to total score calc and highscore checking
	}
}