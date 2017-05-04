using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackClickZone : MonoBehaviour {

	private Object HudRipple;
	private List<Sprite> HudRippleFrames;
	public Canvas canvas;
	private GM_1 GM;
	void Start()
	{
		GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GM_1>();
		HudRippleFrames = new List<Sprite>();
		HudRipple = Resources.Load("Prefabs/HudRipple");
		for(int i =0; i < 9; i++)
		{
			HudRippleFrames.Add(Resources.Load<Sprite>("Sprites/Ripple/ripple" + i));
		}
		HudRippleFrames.Add(Resources.Load<Sprite>("Sprites/Transparent 1x1"));
	}

	void OnMouseDown()
	{
		if(GM.gameIsPaused){return;}
		GameObject RippleEffect = Instantiate(HudRipple, Input.mousePosition, Quaternion.identity) as GameObject;
		RippleEffect.GetComponent<HudRipple_Script>().Begin(ref HudRippleFrames);
		RippleEffect.transform.SetParent(canvas.transform);
	}
}
