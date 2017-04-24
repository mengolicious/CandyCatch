using UnityEngine;
using System.Collections;

public class BeeBurstParticle : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		float zRot = Random.Range(-90f, 90f);
		//float yRot = Random.Range(-90f, 90f);
		this.transform.eulerAngles = new Vector3(0f, 0f, zRot);
		Destroy(gameObject, 0.3f);
	}

	/*IEnumerator Animate()
	{
		while(true)
		{
			if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
			{
				Destroy(gameObject);
			}
			yield return new WaitForSeconds(0.3f);
		}
	}*/
}
