using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
    public string objName { get; private set; }
    public float reloadTime;
    public float[] damage = new float[2];

	void Start () 
    {
        objName = gameObject.name;
	}

    public void ChangeOrigin(Vector3 pos)
    {
        transform.position = pos;
    }
}
