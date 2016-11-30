using UnityEngine;
using System.Collections;

public class Reloadable : ActivationFrequency 
{
    public float reloadSpeed;
    float elapsedTime;

	protected override void Start() 
    {
        base.Start();
        elapsedTime = 0.0f;
	}
	
	void Update() 
    {
        if (!isReadyToBeActivated)
            elapsedTime += Time.deltaTime;

        if (elapsedTime >= reloadSpeed)
            Activate();
	}

    public override void Deactivate()
    {
        base.Deactivate();
        elapsedTime = 0.0f;
    }

}
