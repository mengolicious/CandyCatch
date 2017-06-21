using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBeeScript : MonoBehaviour
{
	ScoreManagerScript ScoreManager_Script;
	SoundManagerScript SM_Script;
	BeeMScript BeeM;

	int value;
	float moveSpeed, moveDir;
	GameObject CarryBall;
	Object particlePrefab, scoreNumberPrefab;

	// Use this for initialization
	void Start ()
	{
		CarryBall = transform.GetChild(0).gameObject;
		ScoreManager_Script	=	GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
		SM_Script			=	GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();
		BeeM				=	GameObject.FindGameObjectWithTag("BeeM").GetComponent<BeeMScript>();
		particlePrefab		=	Resources.Load("Prefabs/BeeBurst");
		scoreNumberPrefab	=	Resources.Load("Prefabs/ScoreChangeSprite");
	}
	
}
