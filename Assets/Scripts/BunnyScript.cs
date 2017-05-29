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
	[SerializeField]
	private GameObject bunnyCandy;
	private int candyNum;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		currentState = States.EarWiggle;
		candyNum = Random.Range(1, 5);
		//transform.GetChild(0).GetComponent<BunnyCandyScript>().InitialiseVariables(candyNum);
		//bunnyCandy = Instantiate(Resources.Load("Prefabs/Bunny/Candy" + candyNum)) as GameObject;
		//bunnyCandy.transform.SetParent(this.transform);
		//bunnyCandy.transform.localScale = Vector3.one;
		//bunnyCandy.transform.localPosition = Vector3.up;
		anim = GetComponent<Animator>();
		candyAnim = transform.GetChild(0).GetComponent<Animator>();
	}

	public void SwitchState(States newState)
	{
		currentState = newState;
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
			//do ya thang
		}
	}

	IEnumerator RiseUp()
	{
		while(currentState == States.MoveUp)
		{
			for(int i =0; i <20; i++)
			{
				transform.position += Vector3.up * 0.05f;
				yield return new WaitForSeconds(0.03f);
			}
			transform.GetChild(0).localPosition += Vector3.up;
			anim.Play ("HeadWiggle");
			candyAnim.Play("CandyWiggle" + candyNum);
			currentState = States.WavingCandy;
		}
	}
}
