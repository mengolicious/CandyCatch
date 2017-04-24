using UnityEngine;
using System.Collections;

public class BackgroundBubble_Script : MonoBehaviour
{
	private GM_1 GameManager;
	private Animator anim;
	private float targetScale;
	private bool Poppable;
	private int SpawnIndex;
	void Start()
	{
		anim = GetComponent<Animator>();
		Poppable = false;
		transform.localScale = Vector3.zero;
		GameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GM_1>();
	}

	public void InitialiseVariables(Vector3 position, float intendedScale, int spawnIndex, int listIndex)
	{
		//transform.position = position;
		targetScale = intendedScale;
		Poppable = false;
		transform.localScale = Vector3.zero;
		SpawnIndex = spawnIndex;
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
			else
			{
				Poppable = true;
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
				GameManager.BubbleDestroyed(SpawnIndex, gameObject);
				Destroy(gameObject);
			}
			yield return new WaitForSeconds(0.03f);
		}
	}
}
