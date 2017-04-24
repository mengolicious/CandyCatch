using UnityEngine;
using System.Collections;

public class CollectiblesScript : MonoBehaviour {

	public bool isCollected;

	public Object starParticle;
	public GameObject tempStar;
	
	// Use this for initialization
	void Start()
	{
		isCollected = false;

		StartCoroutine (CollectibleAnim());
	}

	IEnumerator CollectibleAnim()
	{
		while(!isCollected)
		{
			transform.localPosition -= new Vector3(0.1f,0,0);

			yield return new WaitForSeconds(0.03f);
		}
	}

	public void InstantiateStars()
	{
		tempStar = Instantiate(starParticle,this.transform.position, Quaternion.identity) as GameObject;
	}

	public void DestroySelf()
	{
		Destroy (this.gameObject);
	}
	
}
