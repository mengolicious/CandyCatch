using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GunScript : MonoBehaviour {

	public SoundManagerScript SoundManager_Script;
	public GameObject claw;
	public GameObject fishingRod;
	public bool isShooting; 
	public bool canShoot;
	public bool isRotatingRod; 
	public bool isRotatingRodBack; 
	public Animator shooterAnimator; 
	public ClawScript clawScript; 
	public RaycastHit hit;
	public float rodSpeed;
	public GameObject lineEndPos;

	public GameObject tempGameObject;

	public RaycastHit rayHit;
	public LineRenderer line;
	public GameObject ground;
	public GM_1 GM1_Script;

	public bool panelInstructionsOff=false;

	public Sprite castClaw;
	public Sprite castClawPressed;
	public GameObject castImageObject;
	public Image castSpriteRenderer;

	 


	void Start(){
		//panelInstructionsOff = false;

		SoundManager_Script = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();
		castSpriteRenderer = castImageObject.GetComponent<Image> ();

		line = this.GetComponent<LineRenderer> ();

		shooterAnimator.speed = 0;


		rodSpeed = 10.0f;
		isShooting = false;
		isRotatingRod = false;
		canShoot = false;

		claw.SetActive (false);


		//isRenderFrame = false;
		line.sortingLayerName = "OnTop";
		line.sortingOrder = 5;
		line.useWorldSpace = true;
	}

	void Update () {
		//isRenderFrame = false;
		{
			if(isShooting == true)
			{

				castSpriteRenderer.sprite = castClawPressed;
			}
				else
				{
				castSpriteRenderer.sprite = castClaw;
				}
		}

		if (!isShooting) {
			line.SetVertexCount (2);
			SetupLine ();
		} else {
			line.SetVertexCount (0);
		}
	}
	/*private bool isRenderFrame;
	public void WillRenderObject()
	{
		

		if(!isShooting)
		{
			line.SetVertexCount(2);
			line.SetPosition(0, this.gameObject.transform.position);
			//line.SetPosition(1,  rayHit.point);
			line.SetPosition(1,  lineEndPos.transform.position);
			//line.SetPosition(2, transform.localPosition);
			line.SetWidth(0.01f, 0.01f);
		}
		else
		{
			line.SetVertexCount(0);
		}
		
	}*/

	public void CastClaw ()
	{
		{
			
			if(!isShooting && panelInstructionsOff && canShoot) 
			{
				if(!GM1_Script.gameIsPaused){
					SoundManager_Script.Play_SFX("cast");
					Debug.Log ("ttttt");

					//panelInstructionsOff=true;
					isRotatingRod=true;
					isShooting = true;
					
					//clawScript.GetOrigin();
					shooterAnimator.speed = 0;
					StartCoroutine(RotateFishingRod());
					Debug.Log ("dsdsds");
				}
				
			}

		}
	}
	
	void SetupLine()
	{
		line.SetVertexCount(2);
		line.SetPosition(0, this.gameObject.transform.position);
		//line.SetPosition(1,  rayHit.point);
		line.SetPosition(1,  lineEndPos.transform.position);
		//line.SetPosition(2, transform.localPosition);
		line.SetWidth(0.01f, 0.01f);
	}

	IEnumerator RotateFishingRod(){ 


		//transform.position = Vector3.MoveTowards(transform.position, target, step);
		while(isRotatingRod){

			//fishingRod.transform.localEulerAngles = Vector3.RotateTowards(transform.localEulerAngles, new Vector3(60,45,180), Time.deltaTime*rodSpeed, 10.5f);
			fishingRod.transform.localEulerAngles += new Vector3(5.0f,0,0);
			if(fishingRod.transform.localEulerAngles.x>355){
				isRotatingRod=false;

			}
			yield return new WaitForSeconds(0.01f);
		}


		isRotatingRod=true;

		while(isRotatingRod){

			//fishingRod.transform.localEulerAngles = Vector3.RotateTowards(transform.localEulerAngles, new Vector3(60,45,180), Time.deltaTime*rodSpeed, 10.5f);
			fishingRod.transform.localEulerAngles += new Vector3(5.0f,0,0);
			if(fishingRod.transform.localEulerAngles.x>30){
				isRotatingRod=false;
				
			}
			yield return new WaitForSeconds(0.01f);
		}
	

		claw.SetActive(true);
		LaunchClaw ();
	}

	public void CallRotateBackRod(){
		StartCoroutine(RotateFishingRodBack());
	}

	IEnumerator RotateFishingRodBack(){ 
		
		isRotatingRodBack=true;
		//transform.position = Vector3.MoveTowards(transform.position, target, step);
		while(isRotatingRodBack){
			
			//fishingRod.transform.localEulerAngles = Vector3.RotateTowards(transform.localEulerAngles, new Vector3(60,45,180), Time.deltaTime*rodSpeed, 10.5f);
			fishingRod.transform.localEulerAngles -= new Vector3(5.0f,0,0);
			if(fishingRod.transform.localEulerAngles.x<5){
				isRotatingRodBack=false;
				
			}
			yield return new WaitForSeconds(0.01f);
		}

		isRotatingRodBack=true;
		
		while(isRotatingRodBack){
			
			//fishingRod.transform.localEulerAngles = Vector3.RotateTowards(transform.localEulerAngles, new Vector3(60,45,180), Time.deltaTime*rodSpeed, 10.5f);
			fishingRod.transform.localEulerAngles -= new Vector3(5.0f,0,0);
			if(fishingRod.transform.localEulerAngles.x<275){
				isRotatingRodBack=false;


				
			}
			yield return new WaitForSeconds(0.01f);
		}
	}
	
	void LaunchClaw()
	{
		
//		isShooting = true;
//		shooterAnimator.speed = 0;

		Vector3 down = transform.TransformDirection (Vector3.down);
		Debug.Log ("hit");
		//claw.SetActive (true); //Activate claw
		//Raycast must hit oject in order to be true
		if (Physics.Raycast(this.transform.position,  down, out hit, 100)) 
		{
			if(hit.transform.tag == "collectibles"){
				tempGameObject = hit.transform.gameObject as GameObject;
				tempGameObject.GetComponent<CollectiblesScript>().isCollected=true;
			}
			Debug.Log ("Raycast1");
			claw.SetActive (true); //Activate claw
			Debug.Log ("Raycast2");
			clawScript.ClawTarget (hit.point); //launch towards target(balls)

			Debug.Log (hit.point);


		}
		//Debug.DrawLine (transform.position, hit.point, Color.cyan);
		
		
	}
	
	public void CollectedObject() //after hits object, shooter stops rotation and retracts
	{
		isShooting = false;
		shooterAnimator.speed = 1;
		Debug.Log ("collected");


	}
	
}
