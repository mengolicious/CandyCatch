using UnityEngine;
using System.Collections;

public class HotAirBalloon : MonoBehaviour {
	
	float curveX = 35.0f;
	float curveY = 30.8f;
	float alongTheX = 1.0f;
	float alongTheY = 0.5f;
	public Vector3 originalPos;
	float length; 
	
	float curveSpeed = 0.5f;
	
	
	// Use this for initialization
	void Start () {
		
		originalPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		length += Time.deltaTime * curveSpeed;
		float x = originalPos.x + (curveX * Mathf.Sin (alongTheX * length));
		float y = originalPos.y + (Mathf.Abs (curveY * Mathf.Cos (alongTheY * length)));
		transform.localPosition = new Vector3 (x, y, 0);
		
		
		
	}
}