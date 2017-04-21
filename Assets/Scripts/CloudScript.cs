using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		StartCoroutine (Move ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Move(){
		while (true) {
			transform.localPosition += new Vector3(-0.03f,0,0);
			
			yield return new WaitForSeconds(0.03f);
		}
	}
	
	public void OnTriggerEnter(Collider other)
	{
		
		Debug.Log ("OnTriggerEnter-Collider");
		if (other.CompareTag("DestroyTrigger")) {
			
			Destroy (this.gameObject);
			
		}
	}

}
