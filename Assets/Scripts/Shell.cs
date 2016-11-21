using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour 
{
	private float timer;
	private float speed;
    private float dmg;

	void Start () 
	{
        
	}

    public void Init(float shellSpeed, float shellDmg)
	{
		speed = shellSpeed;
        dmg = shellDmg;
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (timer > 3.0f)
			Destroy (gameObject);
        transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}

	void OnCollisionEnter(Collision col)
	{
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Turret")
        {
            col.gameObject.GetComponent<Living>().TakeDamage(dmg);
        }

        Destroy(gameObject);
	}
}
