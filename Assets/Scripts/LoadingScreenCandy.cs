using UnityEngine;
using System.Collections;

public class LoadingScreenCandy : MonoBehaviour
{
	public float rotateSpeed;
	public int dir;

	void Start()
	{

		StartCoroutine(Rotate());
	}

	IEnumerator Rotate()
	{
		while(true)
		{
			transform.Rotate(new Vector3(0,0,rotateSpeed * dir));
			yield return new WaitForSeconds(0.03f);
		}
	}
}
