using UnityEngine;
using System.Collections;

public class SpawnPrefabWithForceTriggered : SpawnPrefabWithForce 
{
    public EventType triggerEvent;
    bool isAlreadySpawned;

	protected override void Start () 
    {
        base.Start();
        isAlreadySpawned = false;
	}
	
	void Update () 
    {
        if (activationFrequency.isReadyToBeActivated)
        {
            isAlreadySpawned = false;
            EventManager.StartListening(triggerEvent, SpawnPrefab);
        }
	}

    void OnDestroy ()
    {
        EventManager.StopListening(triggerEvent, SpawnPrefab);
    }

    protected override void SpawnPrefab()
    {
        if (isAlreadySpawned)
            return;

        isAlreadySpawned = true;
        base.SpawnPrefab();
        EventManager.StopListening(triggerEvent, SpawnPrefab);
        activationFrequency.Deactivate();
    }
}
