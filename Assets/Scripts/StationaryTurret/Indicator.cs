using UnityEngine;
using System.Collections;

public class Indicator : MonoBehaviour 
{
	void Start () 
	{
		GetComponentInParent<StationaryTurret>().InitIndicator(gameObject);
	}
}
