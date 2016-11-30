using UnityEngine;
using System.Collections;

public class AntitankDamage : Damaging 
{
    protected override void Start () 
    {
        base.Start();
        softDamageCoeff = 0.1f;
        armoredDamageCoeff = 0.8f;
        structureDamageCoeff = 0.1f;
    }
}
