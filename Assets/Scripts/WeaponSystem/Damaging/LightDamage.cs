using UnityEngine;
using System.Collections;

public class LightDamage : Damaging 
{
	protected override void Start () 
    {
        base.Start();
        softDamageCoeff = 0.9f;
        armoredDamageCoeff = 0.1f;
        structureDamageCoeff = 0.0f;
	}
}
