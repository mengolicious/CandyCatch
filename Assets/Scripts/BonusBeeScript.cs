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
	}
}
