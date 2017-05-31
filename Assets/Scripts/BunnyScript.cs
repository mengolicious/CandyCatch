using UnityEngine;
using System.Collections;

public class BunnyScript : MonoBehaviour
{
	public enum States{
		EarWiggle,
		MoveUp,
		WavingCandy,
		Dissapearing
	}
	[SerializeField]
	private States currentState;
	[SerializeField]
	private Animator anim;
	[SerializeField]
	private Animator candyAnim;
	private int candyNum;
	private ScoreManagerScript SM;
	private Object scoreChangePrefab;
	private int spawnIndex;
	private bool dissapearing;
	private BunnySpawner_Script BunnySpawn;
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		transform.position -= Vector3.up * 0.5f;
		currentState = States.EarWiggle;
		candyNum = Random.Range(1, 5);
		//transform.GetChild(0).GetComponent<BunnyCandyScript>().InitialiseVariables(candyNum);
		//bunnyCandy = Instantiate(Resources.Load("Prefabs/Bunny/Candy" + candyNum)) as GameObject;
		//bunnyCandy.transform.SetParent(this.transform);
		//bunnyCandy.transform.localScale = Vector3.one;
		//bunnyCandy.transform.localPosition = Vector3.up;
		anim = GetComponent<Animator>();
		candyAnim = transform.GetChild(0).GetComponent<Animator>();
		scoreChangePrefab = Resources.Load("Prefabs/ScoreChangeSprite");
		dissapearing = false;
		SM = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
		StartCoroutine(AppearTransition());

	}

	public void SetIndex(int index, BunnySpawner_Script bunnyM)
	{
		BunnySpawn = bunnyM;
		spawnIndex = index;
	}

	void OnMouseDown()
	{
		if(currentState == States.EarWiggle)
		{
			anim.Play ("HeadRaise");
			candyAnim.Play("CandyRaise" + candyNum);
			currentState = States.MoveUp;
			StartCoroutine(RiseUp());
		}
		else if(currentState == States.WavingCandy)
		{
			GameObject tempPart;
			//do ya thang
			if(SM.EditScore(2,ScoreManagerScript.ScoreSource.BackGroundObj))
			{
				tempPart = Instantiate(scoreChangePrefab, transform.position, Quaternion.identity) as GameObject;
				tempPart.GetComponent<ScoreModifierSprite>().SetNumber(2, true, true);
			}
			currentState = States.Dissapearing;
			Dissapear();
		}
	}

	IEnumerator AppearTransition()
	{
		int totalStep = (int)(0.5f / 0.05f);
		for(int i =0; i <totalStep; i++)
		{
			transform.position += Vector3.up * 0.05f;
			yield return new WaitForSeconds(0.03f);
		}
	}

	IEnumerator RiseUp()
	{
		while(currentState == States.MoveUp)
		{
			int totalStep = (int)(0.5f / 0.05f);
			for(int i =0; i <totalStep; i++)
			{
				transform.position += Vector3.up * 0.05f;
				yield return new WaitForSeconds(0.03f);
			}
			transform.GetChild(0).localPosition += Vector3.up * 0.1f;
			anim.Play ("HeadWiggle");
			candyAnim.Play("CandyWiggle" + candyNum);
			currentState = States.WavingCandy;
		}
		yield return new WaitForSeconds(3.0f);
		currentState = States.Dissapearing;
		Dissapear();
	}

	void DestroySelf()
	{
		BunnySpawn.BunnyGone(spawnIndex);
		Destroy(this.gameObject);
	}

	void Dissapear()
	{
		if(dissapearing)
		{
			return;
		}
		dissapearing = true;
		transform.GetChild(0).gameObject.SetActive(false);
		anim.Play("SmokePop");
	}
}
