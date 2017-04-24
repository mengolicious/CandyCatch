using UnityEngine;
using System.Collections;

public class TwigParticleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestroyThisParticle", 1.0f);
	
	}

	void DestroyThisParticle(){
		Destroy (this.gameObject);
	}
}
