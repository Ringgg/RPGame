using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class FloatRange : ScriptableObject
{
    public float min;
    public float max;
    public float lastRolled;
	
	void Start () 
    {
	
	}
	
    public void Init(float minFloat, float maxFloat)
    {
        min = minFloat;
        max = maxFloat;
    }

    public float Roll()
    {
        lastRolled = UnityEngine.Random.Range(min, max);
        return lastRolled;
    }
	
}
