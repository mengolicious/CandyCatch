using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GM_1 : MonoBehaviour {
	
	
	public int numBalls =5;
	public Object balls;
	public GunScript gunScript;
	public QuestionManagerScript questionManagerScript;
	public Sprite currentQuestion;
	public int currentAnswer;
	public GameObject smokeSprite;
	public Image smokeSpriteImageComponent;
	public GameObject smallQuestionDisplay;
	public Image smallQuestionDisplayImage;
	public GameObject bigQuestionDisplay;
	public GameObject bigQuestionBG;

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
	public Material matBall0;
	public Material matBall1;
	public Material matBall2;
	public Material matBall3;
	public Material matBall4;
	public Material matBall5;
	public Material matBall6;
	public Material matBall7;
	public Material matBall8;
	public Material matBall9;
	public List<Material> matBallList; 

	public GameObject panelInstructions; 

	
	public List<Vector3> listPosition;
	public Vector3 firstLayer;
	public Vector3 secondLayer;
	public int tempNum;
	public int numberOfBalls=10;
	public float tempX;


	public GameObject nextDifficultyButton;
	// Use this for initialization
	void Start () {

		Time.timeScale = 0;	//Pause time at the start
		GetBG ();			// Get the appropriate BG for the Game


		gameHasStarted = false;
		gameIsPaused = false;

		tempX = -8.2f;
		matBallList = new List<Material> ();
		matBallList.Add (matBall0);
		matBallList.Add (matBall1);
		matBallList.Add (matBall2);
		matBallList.Add (matBall3);
		matBallList.Add (matBall4);
		matBallList.Add (matBall5);
		matBallList.Add (matBall6);
		matBallList.Add (matBall7);
		matBallList.Add (matBall8);
		matBallList.Add (matBall9);
		
		firstLayer = new Vector3 (-7.32f,-2.65f,259.0f);
		secondLayer = new Vector3 (-6.07f,-4.07f,259.0f);
		listPosition = new List<Vector3> ();

		/*--
		for(int x=0; x<8; x++){
			listPosition.Add ( new Vector3(firstLayer.x+(2.2f*x), firstLayer.y, firstLayer.z));
			listPosition.Add ( new Vector3(secondLayer.x+(2.2f*x), secondLayer.y, secondLayer.z));
		}
		
		--*/




		
		panelInstructions.SetActive (true);
		bigQuestionBG.SetActive (false);
		smokeSprite.SetActive (false);
		smallQuestionDisplay.SetActive (false);
		if (SVM_Script.gameDifficulty == "expert")
			nextDifficultyButton.SetActive (false);
		
		SpawnBalls ();
	}

	public void DestroyInstatiatedBalls(string tag){
		GameObject[] objects = GameObject.FindGameObjectsWithTag (tag);

		for(int i=0; i<objects.Length; i++){
			objects[i].GetComponent<BallScript>().DestroyInstantiate();
		}

	}

	public void SpawnBalls ()
	{
		listPosition.Clear();
		tempX = -8.2f;
		for (int x=0; x<10; x++) {


			tempX += 1.5f;
			listPosition.Add(new Vector3(tempX, -(float)(Mathf.Sqrt(64-(tempX*tempX)))*0.65f, 259));
			//listPosition.Add(new Vector3(x, x, x));
		}

		for(int x=0; x<numberOfBalls; x++){
			tempNum = Random.Range (0, listPosition.Count);
			ballPrefabs = Instantiate (balls, listPosition[tempNum],Quaternion.Euler(-90, 18, 0)) as GameObject;
			listPosition.RemoveAt(tempNum);

			ballPrefabs.GetComponent<BallScript>().points = x;
			ballPrefabs.GetComponent<BallScript>().scoreValue = 5;
			ballPrefabs.transform.localEulerAngles = new Vector3(270,196,0);
			ballPrefabs.GetComponent<Renderer>().material = matBallList[x];

			//renderer.material = newMaterialRef;
		}
	
		
	}

	public void GetBG(){
		if (SVM_Script.gameDifficulty == "easy") {
			stageSpriteRendererBG.sprite = equationEasy;
			targetScoreImage.sprite = easyTargetScore;
			SM_Script.targetScore = SVM_Script.targetScore;
		}
		else if(SVM_Script.gameDifficulty == "advance"){
			stageSpriteRendererBG.sprite = equationAdvance;
			targetScoreImage.sprite = advanceTargetScore;
			SM_Script.targetScore = SVM_Script.targetScore;
		}
		else if(SVM_Script.gameDifficulty == "expert"){
			stageSpriteRendererBG.sprite = equationExpert;
			targetScoreImage.sprite = expertTargetScore;
			SM_Script.targetScore = SVM_Script.targetScore;

		}
	}

	
	
	Vector3 RandomPos()
	{
		int  x,y,z;
		x = UnityEngine.Random.Range (-2, 2);
		y = UnityEngine.Random.Range (-1,1);
		z= UnityEngine.Random.Range (0,0);
		return new Vector3 (x, y, z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	


	public void BackToMenu() {
		Application.LoadLevel ("MainScene");
	}

	public void Restart() {
		Application.LoadLevel ("ShapesLV1");
	}

	public void NextDiff()
	{
		if (SVM_Script.gameDifficulty == "easy") {
			SVM_Script.gameDifficulty = "advance";
			SVM_Script.targetScore = 75;
			return;
		}
		if (SVM_Script.gameDifficulty == "advance") {
			SVM_Script.gameDifficulty = "expert";
			SVM_Script.targetScore = 95;
			return;
		}
		/*switch (SVM_Script.gameDifficulty) {
		default: case "easy":  SVM_Script.gameDifficulty = "advance"; break;
		
		case "advance": SVM_Script.gameDifficulty = "expert"; break;

		}*/
	}
	public void StartGame () {


		panelInstructions.SetActive (false);
		gunScript.panelInstructionsOff=true; 
		bigQuestionBG.SetActive (true);
		GetNextQuestion ();
		StartCoroutine (BigDisplayAnim());

	}

	public void ResetQuestion(){

		smallQuestionDisplay.SetActive (false);

		gunScript.panelInstructionsOff=true; 
		bigQuestionBG.SetActive (true);
		GetNextQuestion ();
		StartCoroutine (BigDisplayAnim());

	
		gunScript.canShoot = false;

	}


	IEnumerator BigDisplayAnim(){



		yield return new WaitForSeconds (1.0f);

		for (int x=0; x<20; x++) {
//		bigQuestionBG.transform.localScale -= new Vector3(0.01f,0.01f,0.01f);
			bigQuestionBG.GetComponent<RectTransform> ().localScale -= new Vector3 (0.03f, 0.03f, 0.03f);

			yield return new WaitForSeconds (0.03f);
		}

		StartCoroutine (SmokeSpriteAnim());

	}

	IEnumerator SmokeSpriteAnim(){

		smokeSprite.SetActive (true);

		for (int x=1; x<8; x++) {

			smokeSpriteImageComponent.sprite = Resources.Load<Sprite> ("Sprites/Smoke/Smoke"+x);
			yield return new WaitForSeconds (0.04f);
			if(x==4){
				bigQuestionBG.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
				bigQuestionBG.SetActive (false);

			}
		}

		smokeSprite.SetActive (false);

		smallQuestionDisplay.SetActive (true);
		smallQuestionDisplayImage.sprite = currentQuestion;


		isShooting = false;
		gunScript.canShoot = true;

		gunScript.shooterAnimator.speed = 1; // shooter starts moving only once smoke appears.
	}

	public void GetNextQuestion(){

		currentQuestion = questionManagerScript.GetQuestion ();
		currentAnswer = questionManagerScript.tempAnswer;

		bigQuestionDisplay.GetComponent<Image> ().sprite = currentQuestion;
	}


	public void DisablePanel(GameObject parentPanel){
		parentPanel.SetActive (false);
		if(gameHasStarted==false){
			gameHasStarted=true;
			StartGame ();
		}
	}
	public void EnablePanel(GameObject targetPanel){
		targetPanel.SetActive (true);
	}


	public void PauseGame(){
		//gunScript.canShoot = false;
		gameIsPaused = true;
		Time.timeScale = 0;

	}

	public void ResumeGame(){
		//gunScript.canShoot = true;
		gameIsPaused = false;
		Time.timeScale = 1;

	}



}