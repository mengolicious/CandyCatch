using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBeeScript : MonoBehaviour
{
	[SerializeField]
	ScoreManagerScript ScoreManager_Script;
	[SerializeField]
	SoundManagerScript SM_Script;
	[SerializeField]
	BeeMScript BeeM;

	[SerializeField]
	int value;
	[SerializeField]
	float moveSpeed;
	GameObject CarryBall;
	Object particlePrefab, scoreNumberPrefab;

	void Start ()
	{
		ScoreManager_Script	=	GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
		SM_Script			=	GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();
	}

	/// <summary>
	/// Initialises the variables used by the bee to begin all actions.
	/// </summary>
	/// <param name="beeSpeed">the movement speed of the bee.</param>
	/// <param name="beeValue">the answer the bee carries in an int based format.</param>
	/// <param name="particleResource">the prefab of the bee burst particle.</param>
	/// <param name="ScoreNumResource">the prefab of the score modifier particle.</param>
	/// <param name="BeeMananager">the bee manager, should be the only one. aka 'this'.</param>
	/// <param name="CarryBallMat">the appropriate answer ball material.</param>
	public void InitialiseVariables(float beeSpeed, int beeValue,Object particleResource, Object ScoreNumResource, BeeMScript BeeMananager, Material CarryBallMat)
	{
		CarryBall = transform.GetChild(0).gameObject;
		moveSpeed = beeSpeed;
		value = beeValue;
		particlePrefab = particleResource;
		scoreNumberPrefab = ScoreNumResource;
		BeeM = BeeMananager;
		CarryBall.GetComponent<MeshRenderer>().material = CarryBallMat;
		Invoke("Kill", 5f);
		StartCoroutine(Movement());
	}

	IEnumerator Movement()
	{
		Vector3 moveStep = Vector3.zero;
		while(true)
		{
			moveStep.x = (moveSpeed* 0.02f/*Time.deltaTime */); //replaced 0.03f with Time.deltaTime. I'll explain it in detail if you don't know why 0.03f will not work
			transform.position -= moveStep;
			yield return new WaitForSeconds(0.03f);
		}
	}

	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	public void OnMouseDown()
	{
		SM_Script.Play_SFX("splat");
		if(ScoreManager_Script.CheckBeeAnswer(value))
		{
			Instantiate(particlePrefab, this.transform.position, this.transform.rotation); //Need to complete the following lines based on the Agreed Upon value for the Bonus Round bees
			ScoreManager_Script.EditScore(1,ScoreManagerScript.ScoreSource.BonusBee); 
			GameObject tempScoreParticle = Instantiate(scoreNumberPrefab, this.transform.position, Quaternion.identity) as GameObject;
			tempScoreParticle.GetComponent<ScoreModifierSprite>().SetNumber(1, true, true, false);
		}
		else
		{
			//Reduce the time remaining or something like that here
			BeeM.ReduceTime();
			GameObject tempScoreParticle = Instantiate(scoreNumberPrefab, this.transform.position, Quaternion.identity) as GameObject;
			tempScoreParticle.GetComponent<ScoreModifierSprite>().SetNumber(1, true, true, true);
		}
		Kill();
	}


	public void Kill()
	{
		//Debug.Log ("Bee Dead");
		BeeM.RemoveBee(gameObject);
		Destroy(gameObject);
	}
}
