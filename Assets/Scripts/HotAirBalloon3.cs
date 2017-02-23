using UnityEngine;
using System.Collections;

public class HotAirBalloon3 : MonoBehaviour {

	float curveX = 35.0f;
	float curveY = 30.8f;
	float alongTheX = 1.0f;
	float alongTheY = 0.5f;
	public Vector3 originalPos;
	public int tempCondition=1;
	public int tempControl1;
	public int tempControl2;
	float length; 
	
	public float curveSpeed = 1.0f;
	
	
	// Use this for initialization
	void Start () {
		
		originalPos = new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);



		if (tempCondition == 1) {
			tempControl1=1;
			tempControl2=1;
		}
		else if(tempCondition == 2){
			tempControl1=-1;
			tempControl2=-1;
		}
		else if(tempCondition == 3){
			tempControl1=1;
			tempControl2=-1;
		}

		StartCoroutine (MoveBalloon ());
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		


		
		
		
	}

	IEnumerator MoveBalloon(){

		while(true){
			length += Time.deltaTime * curveSpeed;
			float x = originalPos.x + (tempControl1*(curveX * Mathf.Sin (alongTheX * length)));
			float y = originalPos.y + (tempControl2*(Mathf.Abs (curveY * Mathf.Cos (alongTheY * length))));
			transform.localPosition = new Vector3 (x, y, 0);
			yield return new WaitForSeconds(0.001f);
		}

	}
}
