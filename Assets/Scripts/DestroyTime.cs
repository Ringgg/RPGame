using UnityEngine;
using System.Collections;

public class DestroyTime : MonoBehaviour
{
    public float destroyTime;
	void Start ()
    {
        Invoke("Boop", destroyTime);
	}

    void Boop()
    {
        Destroy(gameObject);
    }
}
