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
	public GameObject tempBallHit;

	public GameObject tempGameObject;
	
	public LineRenderer line;
	public GameObject ground;
	public GM_1 GM1_Script;

	public Sprite castClaw;
	public Sprite castClawPressed;
	public GameObject castImageObject;
	public Image castSpriteRenderer;
	
	void Start()
	{
		//panelInstructionsOff = false;
		SoundManager_Script = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();
		castSpriteRenderer = castImageObject.GetComponent<Image> ();

		line = this.GetComponent<LineRenderer>();

		shooterAnimator.speed = 0;

		rodSpeed = 10.0f;
		isShooting = false;
		isRotatingRod = false;
		canShoot = false;

		claw.SetActive (false);

		//isRenderFrame = false;
		Color targetColour;
		Color.TryParseHexString("7f64ac", out targetColour);
		line.material = new Material(Shader.Find("Unlit/Color"));
		line.material.color = targetColour;
		line.sortingLayerName = "OnTop";
		line.sortingOrder = 5;
		line.useWorldSpace = true;
		line.SetWidth(0.1f, 0.1f);
	}

	void Update()
	{
		//isRenderFrame = false;
		if(isShooting == true)
		{
			castSpriteRenderer.sprite = castClawPressed;
		}
		else
		{
			castSpriteRenderer.sprite = castClaw;
		}
	}

	void LateUpdate()
	{
		if(!isShooting)
		{
			line.SetVertexCount(2);
			SetupLine();
		}
		else
		{
			line.SetVertexCount(0);
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

	public void CastClaw()
	{
		if(!isShooting && canShoot) 
		{
			if(!GM1_Script.gameIsPaused)
			{
				SoundManager_Script.Play_SFX("cast");
				//Debug.Log("ttttt");

				//panelInstructionsOff=true;
				isRotatingRod= true;
				isShooting = true;
				
				//clawScript.GetOrigin();
				shooterAnimator.speed = 0;
				StartCoroutine(RotateFishingRod());
				//Debug.Log ("dsdsds");
			}
		}
	}
	
	void SetupLine()
	{
		line.SetVertexCount(2);
		line.SetPosition(0, this.gameObject.transform.position);
		Vector3 down = transform.TransformDirection (Vector3.down);
		if (Physics.Raycast(this.transform.position,  down, out hit, 20))
		{
			line.SetPosition(1,  hit.point);

			if(hit.transform.gameObject.CompareTag("balls")){
				tempBallHit = hit.transform.gameObject;
				tempBallHit.transform.localScale = new Vector3(0.65f,0.65f,0.65f);
				//tempBallHit.transform.localScale = new Vector3(75,75,75);
				tempBallHit.GetComponent<Renderer>().material.SetFloat("_Metallic", 0);
			}

			else if(hit.transform.gameObject.CompareTag("QueenTag")){

			}
			else{
				if(tempBallHit && !tempBallHit.transform.gameObject.CompareTag("QueenTag")){
					tempBallHit.transform.localScale = new Vector3(0.6f,0.6f,0.6f);
					//tempBallHit.transform.localScale = new Vector3(65,65,65);
					tempBallHit.GetComponent<Renderer>().material.SetFloat("_Metallic", 0.3f);
				}
			}
		}
		else 
		{
			line.SetPosition(1,  lineEndPos.transform.position);

		}
	}

	IEnumerator RotateFishingRod()
	{ 
		//transform.position = Vector3.MoveTowards(transform.position, target, step);
		/*while(isRotatingRod)
		{
			if(Time.timeScale > 0f)
			{
				//fishingRod.transform.localEulerAngles = Vector3.RotateTowards(transform.localEulerAngles, new Vector3(60,45,180), Time.deltaTime*rodSpeed, 10.5f);
				fishingRod.transform.Rotate(new Vector3(5.0f,0,0));
				if(fishingRod.transform.localEulerAngles.x>355)
				{
					isRotatingRod=false;
				}
			}
			yield return new WaitForSeconds(0.01f);
		}
		isRotatingRod=true;
		*/
		while(isRotatingRod)
		{

				//fishingRod.transform.localEulerAngles = Vector3.RotateTowards(transform.localEulerAngles, new Vector3(60,45,180), Time.deltaTime*rodSpeed, 10.5f);
				fishingRod.transform.Rotate(Vector3.right, 5f);
				if(fishingRod.transform.localEulerAngles.x>30 && fishingRod.transform.localEulerAngles.x<40)
				{
					isRotatingRod=false;
				}

			yield return new WaitForSeconds(0.01f);
		}

		claw.SetActive(true);
		LaunchClaw();
	}

	public void CallRotateBackRod()
	{
		StartCoroutine(RotateFishingRodBack());
	}

	IEnumerator RotateFishingRodBack()
	{ 
		isRotatingRodBack=true;
		//transform.position = Vector3.MoveTowards(transform.position, target, step);
		while(isRotatingRodBack)
		{
			//fishingRod.transform.localEulerAngles = Vector3.RotateTowards(transform.localEulerAngles, new Vector3(60,45,180), Time.deltaTime*rodSpeed, 10.5f);
			fishingRod.transform.localEulerAngles -= new Vector3(5.0f,0,0);
			if(fishingRod.transform.localEulerAngles.x<275 && fishingRod.transform.localEulerAngles.x>265)
			{
				isRotatingRodBack=false;
			}
			yield return new WaitForSeconds(0.01f);
		}
		/*isRotatingRodBack=true;
		while(isRotatingRodBack)
		{
			//fishingRod.transform.localEulerAngles = Vector3.RotateTowards(transform.localEulerAngles, new Vector3(60,45,180), Time.deltaTime*rodSpeed, 10.5f);
			fishingRod.transform.localEulerAngles -= new Vector3(5.0f,0,0);
			if(fishingRod.transform.localEulerAngles.x<275)
			{
				isRotatingRodBack=false;
			}
			yield return new WaitForSeconds(0.01f);
		}*/
	}
	
	void LaunchClaw()
	{
		//isShooting = true;
		//shooterAnimator.speed = 0;

		Vector3 down = transform.TransformDirection (Vector3.down);
		//Debug.Log ("hit");
		//claw.SetActive (true); //Activate claw
		//Raycast must hit oject in order to be true
		if (Physics.Raycast(this.transform.position,  down, out hit, 100)) 
		{
			if(hit.transform.tag == "collectibles")
			{
				tempGameObject = hit.transform.gameObject;
				tempGameObject.GetComponent<CollectiblesScript>().isCollected=true;
			}
			else if(hit.transform.tag == "AngryBee")
			{
				tempGameObject = hit.transform.gameObject;
				tempGameObject.GetComponent<AngryBee_Script>().isCollected=true;
			}
			//Debug.Log ("Raycast1");
			claw.SetActive (true); //Activate claw
			//Debug.Log ("Raycast2");
			clawScript.ClawTarget (hit.point); //launch towards target(balls)

			//Debug.Log (hit.point);
		}
		//Debug.DrawLine (transform.position, hit.point, Color.cyan);
	}
	
	public void CollectedObject(bool rightAnwser) //after hits object, shooter stops rotation and retracts
	{
		isShooting = false;
		if(!rightAnwser)
		{
			shooterAnimator.speed = 1;
		}
		//Debug.Log ("collected");
	}
	
}
