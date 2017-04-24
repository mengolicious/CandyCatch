using UnityEngine;
using System.Collections;

public class WrongAnswerParticleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestroyThisObject", 2.0f);
	}

	public void DestroyThisObject(){
		Destroy (this.gameObject);
	}
}
