using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Vulnerability))]
public class Entity : MonoBehaviour 
{
    public Vulnerability vulnerability;

	public virtual void Start ()
    {
        vulnerability = (Vulnerability) GetComponent(typeof (Vulnerability));
	}
	

}
