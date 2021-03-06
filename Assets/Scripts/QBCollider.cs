﻿using UnityEngine;
using System.Collections;

public class QBCollider : MonoBehaviour {

	public string animationString;
	public GameObject QueenBeeParent;
	public QueenBeeScript QueenBee_Script;
	public Animator QueenBeeAnimator;
	public GameObject particlePrefab;

	public Object particlePrefabObject;

	// Use this for initialization
	void Start () {

		QueenBeeParent = this.transform.parent.gameObject;
		QueenBeeAnimator = QueenBeeParent.GetComponent<Animator> ();
		QueenBee_Script = QueenBeeParent.GetComponent<QueenBeeScript>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown()
	{
	

		particlePrefab = Instantiate(particlePrefabObject, this.transform.position, this.transform.rotation)as GameObject;
		QueenBeeAnimator.Play (animationString);

	
		QueenBee_Script.ReduceHealth ();
	

	}
}
