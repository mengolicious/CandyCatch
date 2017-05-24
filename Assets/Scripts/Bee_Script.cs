using UnityEngine;
using System.Collections;

public class Bee_Script : MonoBehaviour {

	protected ScoreManagerScript ScoreManager_Script;
	protected SoundManagerScript SM_Script;
	//public bool isCollected;

	protected GameObject answerBall;

	protected Object particlePrefab;
	protected Object ScoreNumberPrefab;
//	[SerializeField]
//	private Vector3 answerBallPos;
	protected int value;
	public bool isAttacking;
	public bool isGoingToHive;
//	private Vector3 startPos;
//	private Vector3 startDir;
	[SerializeField]
	protected float speed;
	protected Vector3 BeeHivePos;
	protected Vector3 MoveDir;
	protected BeeMScript BeeM;
	// Use this for initialization
	void Start ()
	{
		ScoreManager_Script = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
		SM_Script = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManagerScript>();
	}
	/// <summary>
	/// Initialises the variables.
	/// </summary>
	/// <param name="targetBall">Target ball.</param>
	/// <param name="beeSpeed">Bee speed.</param>
	public virtual void InitialiseVariables(GameObject targetBall, float beeSpeed, int beeValue,Object particleResource, Object ScoreNumResource, Vector3 HiveTragetPos, BeeMScript BeeMananager)
	{
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
	public virtual void OnMouseDown()
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
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == answerBall) {
			other.gameObject.GetComponent<BallScript>().DeductPoints(value);
			other.gameObject.transform.localScale -= new Vector3(0.1f,0.1f,0.1f);

			GameObject tempScoreParticle = GameObject.Instantiate(ScoreNumberPrefab, this.transform.position, Quaternion.identity) as GameObject;
			tempScoreParticle.GetComponent<ScoreModifierSprite>().SetNumber(value, false, false);
			//Debug.Log ("Lose some points you scrub");
			isAttacking = false;
			isGoingToHive = true;
			transform.GetChild(0).GetComponent<Renderer>().material = answerBall.GetComponent<Renderer>().material;
			transform.GetChild(0).gameObject.SetActive(true);
			answerBall = null;
		}
	}

	public virtual void Kill()
	{
		//Debug.Log ("Bee Dead");
		BeeM.RemoveBee(gameObject);
		Destroy(gameObject);
	}

	public virtual void ClearTarget()
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
