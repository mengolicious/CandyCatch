using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {


	public GameObject tempParticle;
	public Object winParticle;
	public Object loseParticle;
	public int points;
	public int scoreValue;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void DestroyBallRuss ()
	{
		//StartCoroutine (DestroyInstantiate());
		InstantiateParticleWin ();
	
	}


	public void InstantiateParticleWin(){
		tempParticle = Instantiate (winParticle, this.transform.position, Quaternion.identity) as GameObject;
		Invoke ("DestroyInstantiate",0.1f);
	}

	public void InstantiateParticleLose(){
		tempParticle = Instantiate (loseParticle, this.transform.position+ new Vector3(0,-1.8f,0), Quaternion.identity) as GameObject;
		Invoke ("DestroyInstantiate",0.1f);
	}

	public void DeductPoints(int pointValue)
	{
		scoreValue = pointValue > scoreValue ? 0 : scoreValue - pointValue;
	}

	public void DestroyInstantiate(){

		//yield return new WaitForSeconds(1.0f);
		Destroy(this.gameObject);
	}


}
