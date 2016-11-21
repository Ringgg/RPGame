using UnityEngine;
using System.Collections;

public class StationaryTurret : MonoBehaviour 
{
	private GameObject gun;
	private GameObject indicator;
	public GameObject shell;
	private Transform playerTransform;
	private TurretStats stats;
	private float timer;

	void Start() 
	{
		shell = (GameObject)Resources.Load("Shell", typeof(GameObject));
		if (shell == null)
			Debug.Log("Shell object is not properly assigned! At: StationaryTurret");
		playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		stats = GetComponent<TurretStats>();
	}

	void Update()
	{
		timer += Time.deltaTime;
		transform.LookAt(playerTransform);

		if (timer > stats.reloadSpeed) 
		{
			Shoot ();
			timer = 0.0f;
		}
	}

			
	public void InitGun(GameObject obj) {gun = obj;}
	public void InitIndicator(GameObject obj) {indicator = obj;}

	private void Shoot()
	{
		GameObject spawnedShell;
		spawnedShell = Instantiate(shell);
		spawnedShell.transform.position = indicator.transform.position;
		spawnedShell.transform.rotation = transform.rotation;
		spawnedShell.GetComponent<Shell>().Init(stats.shellSpeed);
	}
}
