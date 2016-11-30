using UnityEngine;
using System.Collections;

public class OneShot : ActivationFrequency 
{
    public bool hasAlreadyShot { get; private set; }
	
	protected override void Start() 
    {
        base.Start();
        hasAlreadyShot = false;
        Activate();
	}

    public override void Deactivate()
    {
        base.Deactivate();
        hasAlreadyShot = true;
    }
}
