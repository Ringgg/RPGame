using UnityEngine;
using System.Collections;

public class DamageTrigger : MonoBehaviour
{
    public float ammount = 50;

    void OnTriggerEnter(Collider Col)
    {
        if (Col.GetComponent<Living>())
            Col.GetComponent<Living>().TakeDamage(ammount);
    }

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.GetComponent<Living>())
            Col.gameObject.GetComponent<Living>().TakeDamage(ammount);
    }
}
