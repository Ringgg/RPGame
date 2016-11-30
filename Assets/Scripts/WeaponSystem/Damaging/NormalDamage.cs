using UnityEngine;
using System.Collections;

public class NormalDamage : Damaging 
{
    protected override void Start () 
    {
        base.Start();
        softDamageCoeff = 0.7f;
        armoredDamageCoeff = 0.3f;
        structureDamageCoeff = 0.0f;
    }
}
