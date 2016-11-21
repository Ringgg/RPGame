using UnityEngine;
using System.Collections;

public class TurretStats : MonoBehaviour 
{
	public float dmgMin { get; set; }
	public float dmgMax { get; set; }
	public float reloadSpeed { get; set; }
	public float rotateSpeed { get; set; }
	public float shellSpeed { get; set; }

	void Start () 
	{
		reloadSpeed = 3.0f;
		shellSpeed = 3.0f;
	}
}
