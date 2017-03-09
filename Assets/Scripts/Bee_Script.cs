using UnityEngine;
using System.Collections;

public class Bee_Script : MonoBehaviour {

	public ScoreManagerScript ScoreManager_Script;
	public SoundManagerScript SM_Script;
	//public bool isCollected;
	[SerializeField]
	private GameObject answerBall;
	[SerializeField]
	public Object particlePrefab;
	public Object ScoreNumberPrefab;
//	[SerializeField]
//	private Vector3 answerBallPos;
	public int value;
	private bool isAttacking;
//	private Vector3 startPos;
//	private Vector3 startDir;
	[SerializeField]
	private float speed;

	void Awake()
	{
		value = 1;
//		startPos = transform.position;
//		startDir = new Vector3(Random.Range (-1.0f,1.0f),Random.Range (-1.0f,1.0f),0);
		//Debug.Log ("Bee Awake");
	}
	// Use this for initialization
	void Start () {
		//isCollected = false;
		//answerBall = null;
		ScoreManager_Script = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
		SM_Script = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManagerScript>();
		//StartCoroutine (CollectibleAnim());
		//Invoke ("DestroyCollectible",10.0f);
	}


	/*public void InitialiseVariables(GameObject targetBall)
	{
		answerBall = targetBall;

		isAttacking = true;
		speed = 10f;
		StartCoroutine (ATTACK_ON_TITAN());
	}*/

	/// <summary>
	/// Initialises the variables.
	/// </summary>
	/// <param name="targetBall">Target ball.</param>
	/// <param name="beeSpeed">Bee speed.</param>
	public void InitialiseVariables(GameObject targetBall, float beeSpeed, int beeValue)
	{
		answerBall = targetBall;
		isAttacking = true;
		speed = beeSpeed;
		value = beeValue;
		switch(value)
		{
		case 1:
		{
			break;
		}
		case 2:
		{
			GetComponent<SpriteRenderer>().color = Color.cyan;
			break;
		}
		case 3:
		{
			GetComponent<SpriteRenderer>().color = Color.blue;
			break;
		}
		case 4:
		{
			GetComponent<SpriteRenderer>().color = Color.magenta;
			break;
		}
		case 5:
		{
			GetComponent<SpriteRenderer>().color = Color.black;
			break;
		}
		}
		StartCoroutine (ATTACK_ON_TITAN());
	}
	// Update is called once per frame
	/*void Update () {
		if(firstFrame)
		{
			Debug.Log("First Update Call");
			firstFrame = false;
		}
	}*/

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

	}

	/*IEnumerator CollectibleAnim(){
		
		while(!isCollected){
			transform.localPosition -= new Vector3(0.1f,0,0);
			
			yield return new WaitForSeconds(0.03f);
		}
		
	}*/

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



			Kill();

			
		}
	}

	public void Kill()
	{
		//Debug.Log ("Bee Dead");
		Destroy(gameObject);
	}

//	public void OnCollision(Collider other)
//	{
//		Debug.Log ("YOU HIT ME");
//	}
	/*public void DestroyCollectible(){
		Destroy (this.gameObject);
		
	}*/
	
	
}
