using UnityEngine;
using System.Collections;

public class JumpPadScript : MonoBehaviour {

    public float force;

    void OnTriggerEnter(Collider col)
    {
        Rigidbody rb = col.GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(transform.up * force, ForceMode.Impulse);
    }
}
