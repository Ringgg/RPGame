using UnityEngine;
using System.Collections;

public class SpawnPrefabWithForceContinously : SpawnPrefabWithForce 
{
    float reloadSpeed;
    float elapsedTime;
    public bool targetAcquired;

	void Start () 
    {
        reloadSpeed = GetComponent<Weapon>().reloadTime;  
        elapsedTime = 0.0f;
        targetAcquired = true;
	}

    void Update()
    {
        if (targetAcquired == true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= reloadSpeed)
            {
                SpawnPrefab();
                elapsedTime = 0.0f;
            }
        }
        else
            elapsedTime = 0.0f;
    }
}
