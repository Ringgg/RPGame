using UnityEngine;
using System.Collections;

public class HeavyDamage : Damaging
{
    protected override void Start () 
    {
        base.Start();
        softDamageCoeff = 0.5f;
        armoredDamageCoeff = 0.4f;
        structureDamageCoeff = 0.1f;
    }
}
