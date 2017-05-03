using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GM_1 : MonoBehaviour
{

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

	public Image targetScoreImage;
	public Sprite easyTargetScore;
	public Sprite advanceTargetScore;
	public Sprite expertTargetScore;

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

	public List<Vector3> listPosition;
	public Vector3 firstLayer;
	public Vector3 secondLayer;
	public int tempNum;
	public int numberOfBalls=10;
	public float tempX;
	
	public GameObject nextDifficultyButton;

	public GameObject InstructionPanelBG;
	public GameObject InstructionPanel1;

	//public float shooterSpeed;
	public Animator anim;
	public GameObject animM;
	//public float animSpeed;

	private List<Transform> BubbleSpawns;
	private List<GameObject> BubbleList;
	private List<int> tempIndexList;
	private List<string> colourList;
	private bool SpawnBubbles;
	private Object bubblePrefab;

	// Use this for initialization
	void Start()
	{
		SoundManager_Script = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript> ();
		Time.timeScale = 0;	//Pause time at the start
		GetBG();			// Get the appropriate BG for the Game

		gameHasStarted = false;
		gameIsPaused = false;

		tempX = -8.2f;
		matBallList = new List<Material>();
		for(int i = 0; i < 10; i++)
		{
			matBallList.Add(Resources.Load<Material>("Materials/Ball_MAT"+i));
		}
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
		BubbleSpawns = new List<Transform>();
		BubbleList = new List<GameObject>();
		/*
		for(int x=0; x<8; x++){
			listPosition.Add ( new Vector3(firstLayer.x+(2.2f*x), firstLayer.y, firstLayer.z));
			listPosition.Add ( new Vector3(secondLayer.x+(2.2f*x), secondLayer.y, secondLayer.z));
		}
		*/
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
		SpawnBalls();

		if(SVM_Script.gameDifficulty == "easy")
		{
			BG = Instantiate(BG_Easy, new Vector3(0,-1.6f,262), Quaternion.identity ) as GameObject;
			BG.transform.localScale = new Vector3(1.12f, 1.12f,1);

			//shooterSpeed = 0.5f;
			//anim["ShooterAnime"].speed = shooterSpeed;

			//animM.GetComponent<Animator>().speed = 0.1f;
			//animSpeed = 0.2f;
			animM.GetComponent<Animator>().SetFloat("speed",0.2f);
			SpawnBubbles = true;
			bubblePrefab = Resources.Load("Prefabs/Bubble");
			tempIndexList = new List<int>();
			colourList = new List<string>();
			for(int i =0; i <6; i++)
			{
				BubbleSpawns.Add(BG.transform.GetChild(i));
			}
			colourList.Add("00adef");
			colourList.Add("5ec19e");
			colourList.Add("9a519f");
			colourList.Add("fbe044");
			colourList.Add("f7964f");
			colourList.Add("8bc75d");
			colourList.Add("7f64ac");
			colourList.Add("ee3d3b");
			colourList.Add("89d2d7");
		}
		else if(SVM_Script.gameDifficulty == "advance")
		{

			BG = Instantiate(BG_Advance, new Vector3(0,-1.6f,262), Quaternion.identity ) as GameObject;
			BG.transform.localScale = new Vector3(1.12f, 1.12f,1);

			//animM.GetComponent<Animator>().speed = 0.5f;
			//shooterSpeed = 3.5f;	
			//animSpeed = 0.3f;
			animM.GetComponent<Animator>().SetFloat("speed",0.3f);
		}
		else if(SVM_Script.gameDifficulty == "expert")
		{

			BG = Instantiate(BG_Expert, new Vector3(0,-1.6f,262), Quaternion.identity ) as GameObject;
			BG.transform.localScale = new Vector3(1.12f, 1.12f,1);
			nextDifficultyButton.SetActive(false);
			//animM.GetComponent<Animator>().speed = 1.0f;
			//animSpeed = 0.4f;
			animM.GetComponent<Animator>().SetFloat("speed",0.4f);
			//shooterSpeed= 5f;
		}
		//animM.GetComponent<Animator>().SetFloat("speed",0f);
		//Debug.Log(animM.GetComponent<Animator>().GetFloat("speed"));
		if(SpawnBubbles)
			StartCoroutine(BubbleSpawner());
}
	IEnumerator BubbleSpawner()
	{
		for(int i =0; i < BubbleSpawns.Count; i++)
		{
			tempIndexList.Add(i);
		}
		int x;
		GameObject tempBubble;
		Color tempColour;
		int tempI;
		while(true)
		{
			x = Random.Range(0,tempIndexList.Count);
			tempI = Random.Range(0, colourList.Count);
			if(BubbleList.Count < 6)
			{
				//do the bubble spawning code here since it's almost 4
				tempBubble = Instantiate(bubblePrefab, BubbleSpawns[tempIndexList[x]].position, Quaternion.identity) as GameObject;
				BubbleList.Add(tempBubble);
				tempBubble.GetComponent<BackgroundBubble_Script>().InitialiseVariables(BubbleSpawns[tempIndexList[x]].position,BubbleSpawns[tempIndexList[x]].localScale.x, tempIndexList[x], Random.Range(0.1f,0.6f));
				if(Color.TryParseHexString(colourList[tempI], out tempColour))
				{
					tempBubble.GetComponent<SpriteRenderer>().color = tempColour;
				}
				tempIndexList.RemoveAt(x);
			}
			yield return new WaitForSeconds(1.5f);
		}
	}

	public void BubbleDestroyed(int spawnIndex, GameObject bubble)
	{
		tempIndexList.Add(spawnIndex);
		BubbleList.Remove(bubble);
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
			SM_Script.targetScore = SVM_Script.targetScore;

			//Play BG Music
			SoundManager_Script.Play_BG_loop("bg2");
		}
		else if(SVM_Script.gameDifficulty == "advance")
		{
			//stageSpriteRendererBG.sprite = equationAdvance;
			targetScoreImage.sprite = advanceTargetScore;
			SM_Script.targetScore = SVM_Script.targetScore;

			//Play BG Music
			SoundManager_Script.Play_BG_loop("bg2");
		}
		else if(SVM_Script.gameDifficulty == "expert")
		{
			//stageSpriteRendererBG.sprite = equationExpert;
			targetScoreImage.sprite = expertTargetScore;
			SM_Script.targetScore = SVM_Script.targetScore;

			//Play BG Music
			SoundManager_Script.Play_BG_loop("bg2");
		}
	}

	Vector3 RandomPos()
	{
		int  x,y,z;
		x = UnityEngine.Random.Range(-2, 2);
		y = UnityEngine.Random.Range(-1,1);
		z= UnityEngine.Random.Range(0,0);
		return new Vector3(x, y, z);
	}

	public void BackToMenu()
	{
		SoundManager_Script.Play_SFX("MenuNavPop");
		SoundManager_Script.Stop_BG_SFX();
		Application.LoadLevel("MainScene");
	}

	public void Restart()
	{
		SoundManager_Script.Play_SFX("MenuNavPop");
		SoundManager_Script.Stop_BG_SFX();
		Application.LoadLevel("ShapesLV1");
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
		gunScript.gamePlaying=true; 
		bigQuestionBG.SetActive(true);
		GetNextQuestion();
		StartCoroutine(BigDisplayAnim());
	}

	public void ResetQuestion()
	{
		smallQuestionDisplay.SetActive(false);

		gunScript.gamePlaying=true; 
		bigQuestionBG.SetActive(true);
		GetNextQuestion();
		StartCoroutine(BigDisplayAnim());

		gunScript.canShoot = false;
	}


	IEnumerator BigDisplayAnim()
	{
		yield return new WaitForSeconds(1.0f);
		animM.GetComponent<Animator>().speed = 0.1f;
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
		smokeSpriteSmol.SetActive(true);
		for(int x=1; x<8; x++)
		{
			Sprite smokeOnTheWater = Resources.Load<Sprite>("Sprites/Smoke/Smoke"+x);
			smokeSpriteImageComponent.sprite = smokeOnTheWater;
			smokeSpriteSmolImageComponent.sprite = smokeOnTheWater;
			yield return new WaitForSeconds(0.04f);
			if(x==4)
			{
				bigQuestionBG.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
				bigQuestionBG.SetActive(false);
			}
		}

		smokeSprite.SetActive(false);
		smokeSpriteSmol.SetActive(false);

		smallQuestionDisplay.SetActive(true);
		smallQuestionDisplayImage.sprite = currentQuestion;

		isShooting = false;
		gunScript.canShoot = true;

		gunScript.shooterAnimator.speed = 1; // shooter starts moving only once smoke appears.
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
}