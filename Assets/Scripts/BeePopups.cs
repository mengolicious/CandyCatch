using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePopups : MonoBehaviour {


	IEnumerator FlashingAnim()
	{
		float countDown = 0.5f;
		Vector3 sizeChange = Vector3.one * 0.01f;
		while(countDown > 0f)
		{
			transform.localScale += sizeChange;
			countDown -= 0.03f;
			yield return new WaitForSeconds(0.03f);
		}
		countDown = 0.5f;
		while(countDown > 0f)
		{
			transform.localScale -= sizeChange;
			countDown -= 0.03f;
			yield return new WaitForSeconds(0.03f);
		}

		gameObject.SetActive(false);
	}

	void OnEnable()
	{
		StartCoroutine(FlashingAnim());
	}
}
