using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Damaging))]
public class DamageOnCollision : MonoBehaviour 
{
    Damaging damaging;
	
	void Start () 
    {
        damaging = (Damaging) GetComponentInParent(typeof (Damaging));
	}
	
    void OnCollisionEnter(Collision col)
    {
        string colliderTag = col.collider.gameObject.tag;
        float actualDamage = 0.0f;

        if (colliderTag == "Player" || colliderTag == "Turret")
        {
            Living livingObj = (Living)col.collider.gameObject.GetComponent(typeof(Living));

            switch (livingObj.vulnerability.armorClass)
            {
                case ArmorClass.Soft:
                    actualDamage = damaging.GetSoftDamage();
                    break;
                case ArmorClass.Armored:
                    actualDamage = damaging.GetArmoredDamage();
                    break;
                case ArmorClass.Structure:
                    actualDamage = damaging.GetStructureDamage();
                    break;
                default:
                    Debug.Log("Unexpected error when checking ArmorType");
                    break;
            }

            livingObj.TakeDamage(actualDamage);
            Destroy(gameObject);
        }
    }
}
