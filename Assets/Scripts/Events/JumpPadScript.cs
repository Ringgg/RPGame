using UnityEngine;
using System.Collections;

public class JumpPadScript : MonoBehaviour {

    public float force;

    void OnTriggerEnter(Collider col)
    {
        Rigidbody rb = col.GetComponent<Rigidbody>();
        Debug.Log("ahahah");
        if (rb != null)
        {
            Debug.Log("fsdfs");
            rb.AddForce(0, force,0, ForceMode.Impulse);
        }
    }
}
