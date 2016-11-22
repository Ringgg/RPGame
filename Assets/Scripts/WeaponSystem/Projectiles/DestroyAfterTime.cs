using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour 
{
    public float timeToDestroy = 3.0f;
	
	void Start () 
    {
        Invoke("Destroy", timeToDestroy);   
	}
	
    void Destroy()
    {
        Destroy(gameObject);
    }
}
