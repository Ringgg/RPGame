using UnityEngine;
using System.Collections;


public class SpawnPrefabWithForceContinously : SpawnPrefabWithForce 
{
    public bool targetAcquired;
   
	protected override void Start() 
    {
        base.Start();
        targetAcquired = true;
	}

    void Update()
    {
        if (targetAcquired && activationFrequency.isReadyToBeActivated)
        {
            SpawnPrefab();
            activationFrequency.Deactivate();
        }
    }
}
