using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ActivationFrequency))]
public class SpawnPrefabWithForce : MonoBehaviour 
{
    public GameObject prefabObj;
    public float forceStrength;
    protected ActivationFrequency activationFrequency;

	protected virtual void Start() 
    {
        activationFrequency = (ActivationFrequency) GetComponent(typeof (ActivationFrequency));
	}

    protected virtual void SpawnPrefab()
    {
        if (prefabObj == null)
            return;

        Weapon weapon = GetComponent<Weapon>();
        GameObject spawnedPrefab = Instantiate(prefabObj, weapon.transform.position, weapon.transform.rotation, weapon.transform) as GameObject;
        spawnedPrefab.GetComponent<Rigidbody>().AddForce(forceStrength * spawnedPrefab.transform.forward, ForceMode.Force);
    }
}
