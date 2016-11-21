using UnityEngine;
using System.Collections;

public class Indicator : MonoBehaviour 
{
	void Start () 
	{
		GetComponentInParent<Living>().InitIndicator(gameObject);
	}
}
