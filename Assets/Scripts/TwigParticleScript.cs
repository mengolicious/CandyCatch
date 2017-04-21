using UnityEngine;
using System.Collections;

public class TwigParticleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestroyThisParticle", 1.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DestroyThisParticle(){
		Destroy (this.gameObject);
	}
}
