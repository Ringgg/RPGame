using UnityEngine;
using System.Collections;

public class TurretGun : MonoBehaviour 
{
	void Start () 
	{
		GetComponentInParent<StationaryTurret>().InitGun(gameObject);
	}
}
