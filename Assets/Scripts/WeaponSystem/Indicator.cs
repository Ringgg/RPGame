using UnityEngine;
using System.Collections;

public class Indicator : MonoBehaviour 
{
    public Vector3 position { get; private set; }
    
	void Start () 
	{
        SetPosition();
	}

    public void SetPosition()
    {
        position = transform.position;
    }
}
