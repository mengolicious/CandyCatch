using UnityEngine;
using System.Collections;

public class AngryBee_Script : MonoBehaviour
{
	public bool isCollected;

	void Start()
	{
		isCollected = false;
		
		StartCoroutine (Movement());
	}

	IEnumerator Movement()
	{
		while(!isCollected)
		{
			transform.localPosition -= new Vector3(0.1f,0,0);
			
			yield return new WaitForSeconds(0.03f);
		}
	}

	public void DestroySelf()
	{
		Destroy (this.gameObject);
	}

}
