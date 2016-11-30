using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
    public string objName { get; private set; }

	void Start () 
    {
        objName = gameObject.name;
	}

    public void ChangeOrigin(Vector3 pos)
    {
        transform.position = pos;
    }
}
