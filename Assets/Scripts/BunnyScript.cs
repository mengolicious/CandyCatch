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
	private GameObject bunnyCandy;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		currentState = States.EarWiggle;
		int candyNum = Random.Range(1, 5);

		//bunnyCandy = Instantiate(Resources.Load("Prefabs/Bunny/Candy" + candyNum)) as GameObject;
		//bunnyCandy.transform.SetParent(this.transform);
		//bunnyCandy.transform.localScale = Vector3.one;
		//bunnyCandy.transform.localPosition = Vector3.up;
		anim = GetComponent<Animator>();
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
			currentState = States.MoveUp;
			StartCoroutine(RiseUp());
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
		}
	}
}
