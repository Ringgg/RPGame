using UnityEngine;
using System.Collections;

public class Damaging : MonoBehaviour 
{
    public float minDamage;
    public float maxDamage;
    public float rolledDamage { get; protected set; }

    protected float softDamageCoeff;
    protected float armoredDamageCoeff;
    protected float structureDamageCoeff;

	protected virtual void Start () 
    {
        RollDamage();
	}

    public void RollDamage()
    {
        rolledDamage = Random.Range(minDamage, maxDamage);
    }

    public float GetSoftDamage()
    {
        return softDamageCoeff * rolledDamage;
    }

    public float GetArmoredDamage()
    {
        return armoredDamageCoeff * rolledDamage;
    }

    public float GetStructureDamage()
    {
        return structureDamageCoeff * rolledDamage;
    }
}
