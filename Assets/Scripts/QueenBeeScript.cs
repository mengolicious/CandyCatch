using UnityEngine;
using System.Collections;

public class QueenBeeScript : Bee_Script {

	private GM_1 GM_1Script;
	private BeeMScript BeeM_Script;
	private ClawScript Claw_Script;
	private bool hasBall;
	public int life;

	private Animator QueenAnimation;
	//public bool isCollected;

	// Use this for initialization
	void Start ()
	{
		ScoreManager_Script = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
		SM_Script = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManagerScript>();
		GM_1Script = GameObject.FindGameObjectWithTag ("GM").GetComponent<GM_1>();
		BeeM_Script = GameObject.FindGameObjectWithTag ("BeeM").GetComponent<BeeMScript>();
		Claw_Script = GameObject.FindGameObjectWithTag ("Claw").GetComponent<ClawScript>();

		QueenAnimation = this.GetComponent<Animator> ();
	}
	/// <summary>
	/// Initialises the variables.
	/// </summary>
	/// <param name="targetBall">Target ball.</param>
	/// <param name="beeSpeed">Bee speed.</param>
	public override void InitialiseVariables(GameObject targetBall, float beeSpeed, int beeValue,Object particleResource, Object ScoreNumResource, Vector3 HiveTragetPos, BeeMScript BeeMananager)
	{
		life = 5;
		hasBall = false;
		answerBall = targetBall;
		isAttacking = true;
		speed = beeSpeed;
		value = beeValue;
		/*if(value == 2)
		{
			GetComponent<SpriteRenderer>().color = Color.cyan;
		}
		else if(value == 3)
		{
			GetComponent<SpriteRenderer>().color = Color.magenta;
		}//*/
		BeeHivePos = HiveTragetPos;
		particlePrefab = particleResource;
		ScoreNumberPrefab = ScoreNumResource;
		BeeM = BeeMananager;
		if(targetBall.transform.position.x > transform.position.x)
		{
			//transform.localScale = new Vector3(-1,1,1);
			transform.Rotate(Vector3.up,180f);
		}//*/
		StartCoroutine (ATTACK_ON_TITAN());
	}
	/// <summary>
	/// Updates the bees every half second.
	/// </summary>
	IEnumerator ATTACK_ON_TITAN()
	{
		//float stepTime;
		//Debug.Log("Begin Moving");
		while(isAttacking)
		{
			/*if(Time.deltaTime < 0.03f)
			{
				//Debug.Log("Update faster than 30fps, Delta time is: " + Time.deltaTime);
				stepTime = 0.03f;
			}
			else
			{
				//Debug.Log ("Update Slower that 30fps, Delta time is: " + Time.deltaTime);
				stepTime = Time.deltaTime;
			}*/
			//Debug.Log ("Attack");
			if(answerBall)
			{
				//Debug.Log("Ball Found");
				transform.position = Vector3.MoveTowards(transform.position, answerBall.transform.position, speed * 0.02f /*Time.deltaTime*/); //replaced 0.03f with Time.deltaTime. I'll explain it in detail if you don't know why 0.03f will not work
			}
			else
			{
				isAttacking = false;
			}
			//Debug.Log(Time.time);Debug.Log(Time.deltaTime);Debug.Log(Time.fixedDeltaTime);
			yield return new WaitForSeconds(0.03f);
			//Debug.Log(Time.time);
		}
		MoveDir = BeeHivePos - transform.position;
		float dist = MoveDir.magnitude;
		MoveDir.Normalize();
		Vector3 moveStep;
		if(transform.eulerAngles.y <180)
			transform.eulerAngles += new Vector3(0,180,0);
		while(isGoingToHive)
		{
			if( dist >0f )
			{
				moveStep = MoveDir * (speed * 0.02f/*Time.deltaTime */); //replaced 0.03f with Time.deltaTime. I'll explain it in detail if you don't know why 0.03f will not work
				dist -= moveStep.magnitude;
				transform.position += moveStep;
			}
			else
			{
				isGoingToHive = false;
			}
			yield return new WaitForSeconds(0.03f);
		}
		BeeM.HiveShake(value);
		Kill();
	}
	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	public override void OnMouseDown()
	{
		//if(Input.GetMouseButtonDown(0))
		//{
		SM_Script.Play_SFX("splat");
		if(ScoreManager_Script.EditScore(value, ScoreManagerScript.ScoreSource.Bee))
		{
			GameObject.Instantiate(particlePrefab, this.transform.position, this.transform.rotation);
			GameObject tempScoreParticle = GameObject.Instantiate(ScoreNumberPrefab, this.transform.position, Quaternion.identity) as GameObject;
			tempScoreParticle.GetComponent<ScoreModifierSprite>().SetNumber(value, true, true);
		}
		Kill();
		//}
	}
	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	public override void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == answerBall) {
			other.gameObject.GetComponent<BallScript>().DeductPoints(value);
			other.gameObject.transform.localScale -= new Vector3(0.1f,0.1f,0.1f);
			
			GameObject tempScoreParticle = GameObject.Instantiate(ScoreNumberPrefab, this.transform.position, Quaternion.identity) as GameObject;
			tempScoreParticle.GetComponent<ScoreModifierSprite>().SetNumber(value, false, false);
			//Debug.Log ("Lose some points you scrub");
			isAttacking = false;
			isGoingToHive = true;
			//transform.GetChild(0).GetComponent<Renderer>().material = answerBall.GetComponent<Renderer>().material;
			//transform.GetChild(0).gameObject.SetActive(true);

			//----Start Bee Getting the Actual Ball------//


			QueenAnimation.Play ("FlyingCarryAnim");
			other.gameObject.transform.SetParent(this.transform);
			other.gameObject.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
			other.gameObject.transform.localPosition = new Vector3(-1.2f,-2.3f,0);
			other.gameObject.transform.localEulerAngles = new Vector3(270,0,0);

			hasBall=true;
			Claw_Script.hitBall=false;





			//----END Bee Getting the Actual Ball------//


			answerBall = null;
		}
	}
	
	public override void Kill()
	{

		//Start for Restarting Balls and Questions
		if(hasBall){
			Debug.Log ("The Queen lost the ball");
			GM_1Script.DestroyInstatiatedBalls("balls");
			GM_1Script.SpawnBalls();
			BeeM_Script.ClearBees();
			GM_1Script.ResetQuestion();
		}
		//END for Restarting Balls and Questions


		//Debug.Log ("Bee Dead");
		BeeM.RemoveBee(gameObject);
		Destroy(gameObject);


	}
	
	public override void ClearTarget()
	{
		answerBall = null;
		if(isAttacking)
		{
			//Destroy(this.GetComponent<Collider>());
			isAttacking = false;
		}
		isGoingToHive = true;


	}
}
