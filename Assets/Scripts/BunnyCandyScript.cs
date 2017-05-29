using UnityEngine;
using System.Collections;

public class BunnyCandyScript : MonoBehaviour {

	int candyNum;
	Animator anim;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
	}

	public void InitialiseVariables(int candyIndex)
	{
		candyNum = candyIndex;
		/*if(anim)
		{
			anim.Play("CandyRaise" + candyNum);
		}//*/
	}

	void OnMouseDown()
	{
		/*if(currentState == States.EarWiggle)
		{
			anim.Play ("HeadRaise");
			currentState = States.MoveUp;
			StartCoroutine(RiseUp());
		}*/
	}
}
