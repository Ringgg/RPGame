using UnityEngine;
using System.Collections;

public class DamageOnCollision : MonoBehaviour 
{
    float damage;
	
	void Start () 
    {
        damage = Random.Range(GetComponentInParent<Weapon>().damage[0], GetComponentInParent<Weapon>().damage[1]);
        transform.parent = null;
	}
	
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.tag == "Player" || col.collider.gameObject.tag == "Turret")
        {
            col.collider.gameObject.GetComponent<Living>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
