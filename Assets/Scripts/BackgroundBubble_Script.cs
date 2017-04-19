using UnityEngine;
using System.Collections;

public class BackgroundBubble_Script : MonoBehaviour
{
	private Animator anim;
	private float targetScale;
	private bool Poppable;
	void Start()
	{
		anim = GetComponent<Animator>();
		Poppable = false;
		transform.localScale = Vector3.zero;
	}

	public void InitialiseVariables(Vector3 position, float intendedScale)
	{
		transform.position = position;
		targetScale = intendedScale;
		Poppable = false;
		transform.localScale = Vector3.zero;
		StartCoroutine(ExpandBubble());
	}

	IEnumerator ExpandBubble()
	{
		while(!Poppable)
		{
			if(transform.localScale.x != targetScale)
			{
				transform.localScale += Vector3.one * 0.1f;
			}
			yield return new WaitForSeconds(0.3f);
		}
	}

	public void OnMouseOver()
	{
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && Poppable)
		{
			if(Input.GetMouseButtonDown(0))
			{
				anim.Play("BubbleBurst");
				StartCoroutine(SelfDestroy());
				//JUST DO IT, DON'T LET YOUR DREAMS JUST BE DREAMS - SHIA LABEOUF
			}
		}
	}

	IEnumerator SelfDestroy()
	{
		float waitTime = 0.6f;
		while(true)
		{
			waitTime -= 0.03f;
			if(waitTime < 0f)
			{
				Destroy(gameObject);
			}
			yield return new WaitForSeconds(0.03f);
		}
	}
}
