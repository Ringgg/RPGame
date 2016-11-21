using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour 
{
	private float timer;
	private float speed;

	void Start () 
	{
		transform.Translate (Vector3.forward * 2.0f);
	}

	public void Init(float shellSpeed)
	{
		speed = shellSpeed;
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
		//Destroy (gameObject);
	}
}
