using UnityEngine;
using System.Collections;

public class ProjectileStats : ScriptableObject 
{
    public  float dmgMin { get; private set; }
	public float dmgMax { get; private set; }
	public float reloadSpeed { get; private set; }
	public float rotateSpeed { get; private set; }
	public float shellSpeed { get; private set; }

	void Start () 
	{
        Init();
	}

    public void Init()
    {
        dmgMin = 8.0f;
        dmgMax = 12.0f;
        reloadSpeed = 3.0f; //in seconds
        shellSpeed = 10.0f;
    }

    public float RollDmg() { return Random.Range(dmgMin, dmgMax); }
}
