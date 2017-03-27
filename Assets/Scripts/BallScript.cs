using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	private SoundManagerScript SoundManager_Script;
	private GameObject tempParticle;
	public Object winParticle;
	public Object loseParticle;
	private Object scoreUpParticle;
	public int points;
	public int scoreValue;
	private Vector3 scoreChangeSpritePos;
	// Use this for initialization
	void Start ()
	{
		SoundManager_Script = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManagerScript> ();
		scoreChangeSpritePos = GameObject.FindGameObjectWithTag("BeeM").GetComponent<Transform>().position;
		scoreUpParticle = Resources.Load("Prefabs/ScoreChangeSprite");
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	/*public void DestroyBallRuss ()
	{
		//StartCoroutine (DestroyInstantiate());
		InstantiateParticleWin ();	
	}*/


	public void InstantiateParticleWin()
	{
		SoundManager_Script.Play_SFX("correct");
		tempParticle = Instantiate (winParticle, this.transform.position, Quaternion.identity) as GameObject;
		tempParticle = Instantiate(scoreUpParticle, scoreChangeSpritePos, Quaternion.identity) as GameObject;
		tempParticle.GetComponent<ScoreModifierSprite>().SetNumber(scoreValue, true, false);
		Invoke ("DestroyInstantiate",0.1f);
	}

	public void InstantiateParticleLose()
	{
		SoundManager_Script.Play_SFX("wrong");
		tempParticle = Instantiate (loseParticle, this.transform.position+ new Vector3(0,-1.8f,0), Quaternion.identity) as GameObject;
		Invoke ("DestroyInstantiate",0.1f);
	}

	public void DeductPoints(int pointValue)
	{
		scoreValue = pointValue > scoreValue ? 0 : scoreValue - pointValue;
	}

	public void DestroyInstantiate()
	{
		//yield return new WaitForSeconds(1.0f);
		Destroy(this.gameObject);
	}

}
