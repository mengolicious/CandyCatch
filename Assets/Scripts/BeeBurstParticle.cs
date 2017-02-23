using UnityEngine;
using System.Collections;

public class BeeBurstParticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float zRot = Random.Range(-90f, 90f);
		//float yRot = Random.Range(-90f, 90f);
		this.transform.eulerAngles = new Vector3(0f, 0f, zRot);
		StartCoroutine(CheckState());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator CheckState()
	{
		while(true)
		{
			if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("END"))
				DestroyImmediate(gameObject);
			yield return new WaitForSeconds(0.3f);
		}
	}
}
