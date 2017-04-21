using UnityEngine;
using System.Collections;

public class TumbleweedScript : MonoBehaviour {

	private ScoreManagerScript ScoreManager_Script;
	private SoundManagerScript SM_Script;

	public Object twigParticlePrefab;
	public Object scoreChangePrefab;
	public int tempLifeNum;
	public int lifeTest;
	public int tempValue;
	// Use this for initialization
	void Start () {

		ScoreManager_Script = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
		SM_Script = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManagerScript>();

		tempLifeNum = 0;
		//lifeTest = 0;
		//tempValue = 0;

		

	}

	public void StartRolling(){
		StartCoroutine (Move ());
	}
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Move(){
		while (true) {
			transform.localPosition += new Vector3(-0.08f,0,0);

			yield return new WaitForSeconds(0.03f);
		}
	}

	public void OnTriggerEnter(Collider other)
	{

		Debug.Log ("OnTriggerEnter-Collider");
		if (other.CompareTag("DestroyTrigger")) {

			Destroy (this.gameObject);
		
		}
	}

	public void OnMouseOver()
	{

		if(Input.GetMouseButtonDown(0))
		{
			SM_Script.Play_SFX("twigsnap");
			GameObject.Instantiate(twigParticlePrefab, this.transform.position, this.transform.rotation);
		
			tempLifeNum++;
			if (tempLifeNum < lifeTest) {
				
				transform.localScale -= new Vector3 (0.06f, 0.06f, 0.06f);
			} else {
				GameObject tempScoreParticle = GameObject.Instantiate(scoreChangePrefab, this.transform.position, Quaternion.identity) as GameObject;
				tempScoreParticle.GetComponent<ScoreModifierSprite>().SetNumber(tempValue, true, true);
				ScoreManager_Script.EditScore(tempValue);
				Destroy(this.gameObject);
			}
		}


	}
	


}
