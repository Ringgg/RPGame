using UnityEngine;
using System.Collections;

public class SpawnPrefabWithForce : MonoBehaviour 
{
    public GameObject prefabObj;
    public float forceStrength;

	void Start() 
    {
	    
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
