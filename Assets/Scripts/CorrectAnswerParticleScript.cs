using UnityEngine;
using System.Collections;

public class CorrectAnswerParticleScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Invoke ("DestroyThisObject", 2.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void DestroyThisObject()
	{
		Destroy (this.gameObject);
	}
}