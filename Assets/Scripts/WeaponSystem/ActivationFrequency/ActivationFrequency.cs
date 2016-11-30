using UnityEngine;
using System.Collections;

public class ActivationFrequency : MonoBehaviour 
{
    public bool isReadyToBeActivated { get; private set; }

	protected virtual void Start() 
    {
        isReadyToBeActivated = false;
	}
	
    protected void Activate() 
    {
        isReadyToBeActivated = true;
    }

    public virtual void Deactivate() 
    {
        isReadyToBeActivated = false;
    }
}
