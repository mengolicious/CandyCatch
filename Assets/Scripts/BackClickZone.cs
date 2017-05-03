using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackClickZone : MonoBehaviour {

	private Object HudRipple;
	private List<Sprite> HudRippleFrames;
	public Canvas canvas;
	void Start()
	{
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
		GameObject RippleEffect = Instantiate(HudRipple, Input.mousePosition, Quaternion.identity) as GameObject;
		RippleEffect.GetComponent<HudRipple_Script>().Begin(ref HudRippleFrames);
		RippleEffect.transform.SetParent(canvas.transform);
	}
}
