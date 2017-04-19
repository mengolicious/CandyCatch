using UnityEngine;
using System.Collections;

public class BackgroundBubble_Script : MonoBehaviour
{
	private Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void OnMouseOver()
	{
		//if()
		{
			if(Input.GetMouseButtonDown(0))
			{
				anim.Play("Burst");
				//JUST DO IT, DON'T LET YOUR DREAMS JUST BE DREAMS - SHIA LABEOUF
			}
		}
	}
}
