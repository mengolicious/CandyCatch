using UnityEngine;
using System.Collections;

public class Bee_Script : MonoBehaviour {

	private ScoreManagerScript ScoreManager_Script;
	private SoundManagerScript SM_Script;
	//public bool isCollected;

	private GameObject answerBall;

	private Object particlePrefab;
	private Object ScoreNumberPrefab;
//	[SerializeField]
//	private Vector3 answerBallPos;
	private int value;
	private bool isAttacking;
	private bool isGoingToHive;
//	private Vector3 startPos;
//	private Vector3 startDir;
	[SerializeField]
	private float speed;
	private Vector3 BeeHivePos;
	private Vector3 MoveDir;
	void Awake()
	{

	}
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
	public void InitialiseVariables(GameObject targetBall, float beeSpeed, int beeValue,Object particleResource, Object ScoreNumResource, Vector3 HiveTragetPos)
	{
		answerBall = targetBall;
		isAttacking = true;
		speed = beeSpeed;
		value = beeValue;
		if(value == 2)
		{
			GetComponent<SpriteRenderer>().color = Color.cyan;
		}
		else if(value == 3)
		{
			GetComponent<SpriteRenderer>().color = Color.magenta;
		}
		BeeHivePos = HiveTragetPos;
		particlePrefab = particleResource;
		ScoreNumberPrefab = ScoreNumResource;
		StartCoroutine (ATTACK_ON_TITAN());
	}
	/// <summary>
	/// Updates the bees every half second.
	/// </summary>
	IEnumerator ATTACK_ON_TITAN()
	{
		//Debug.Log("Begin Moving");
		while(isAttacking)
		{
			//Debug.Log ("Attack");
			if(answerBall)
			{
				//Debug.Log("Ball Found");
				transform.position = Vector3.MoveTowards(transform.position, answerBall.transform.position, speed  * Time.deltaTime);
			}
			else
			{
				isAttacking = false;
			}
			yield return new WaitForSeconds(0.03f);
		}
		MoveDir = BeeHivePos - transform.position;
		float dist = MoveDir.magnitude;
		MoveDir.Normalize();
		Vector3 moveStep;
		while(isGoingToHive)
		{
			if( dist >0f )
			{
				moveStep = MoveDir * (speed * Time.deltaTime);
				dist -= moveStep.magnitude;
				transform.position += moveStep;
			}
			else
			{
				isGoingToHive = false;
			}
			yield return new WaitForSeconds(0.03f);
		}
		Kill();
	}
	/// <summary>
	/// Raises the mouse over event.
	/// </summary>
	public void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0))
		{
			SM_Script.Play_SFX("splat");
			GameObject.Instantiate(particlePrefab, this.transform.position, this.transform.rotation);
			GameObject tempScoreParticle = GameObject.Instantiate(ScoreNumberPrefab, this.transform.position, Quaternion.identity) as GameObject;
			tempScoreParticle.GetComponent<ScoreModifierSprite>().SetNumber(value, true, true);
			ScoreManager_Script.EditScore(value);
			Kill();
		}
	}
	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == answerBall) {
			other.gameObject.GetComponent<BallScript>().DeductPoints(value);
			//Debug.Log ("Lose some points you scrub");
			isAttacking = false;
			isGoingToHive = true;
			if(transform.childCount > 0)
			{
				transform.GetChild(0).gameObject.SetActive(true);
			}
		}
	}

	public void Kill()
	{
		//Debug.Log ("Bee Dead");
		Destroy(gameObject);
	}

}
