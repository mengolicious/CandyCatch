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

	// Use this for initialization
	void Start ()
	{
		ScoreManager_Script	=	GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
		SM_Script			=	GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();
	}

	public void InitialiseVariables(float beeSpeed, int beeValue,Object particleResource, Object ScoreNumResource, BeeMScript BeeMananager, Material CarryBallMat)
	{
		CarryBall = transform.GetChild(0).gameObject;
		moveSpeed = beeSpeed;
		value = beeValue;
		particlePrefab = particleResource;
		scoreNumberPrefab = ScoreNumResource;
		BeeM = BeeMananager;
		CarryBall.GetComponent<MeshRenderer>().material = CarryBallMat;
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
		/*if(ScoreManager_Script.EditScore(value, ScoreManagerScript.ScoreSource.BonusBee))
		{
			Instantiate(particlePrefab, this.transform.position, this.transform.rotation);
			/*GameObject tempScoreParticle = Instantiate(scoreNumberPrefab, this.transform.position, Quaternion.identity) as GameObject;
			tempScoreParticle.GetComponent<ScoreModifierSprite>().SetNumber(value, true, true);
		}*/
		Kill();
	}

	public void Kill()
	{
		//Debug.Log ("Bee Dead");
		BeeM.RemoveBee(gameObject);
		Destroy(gameObject);
	}
}
