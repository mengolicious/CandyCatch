using UnityEngine;
using System.Collections;

public class TriggerDestroy_Script : MonoBehaviour
{

	public void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
	}
}
