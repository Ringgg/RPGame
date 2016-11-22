using UnityEngine;
using System.Collections;

public class StationaryTurret : Living
{
    GameObject player;
    public GameObject cube;
    SphereCollider sphereCollider;
    SpawnPrefabWithForceContinously prefabSpawning;

    public float attackRadius;
    public float rotateSpeed;

	public override void Start() 
	{
        base.Start();

		player = GameObject.FindGameObjectWithTag("Player");
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = attackRadius;

        weaponSystem.activeWeapon.ChangeOrigin(indicator.position);
        prefabSpawning = GetComponentInChildren<SpawnPrefabWithForceContinously>();
	}

	void Update()
	{
        FollowPlayer();
	}

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

    void FollowPlayer()
    {
        Vector3 currentTurretRotation, maxTurretRotation;

        currentTurretRotation = transform.localRotation.eulerAngles;
        transform.LookAt(player.transform);
        maxTurretRotation = transform.localRotation.eulerAngles;
        transform.localRotation = Quaternion.Euler(currentTurretRotation);
        transform.localRotation = Quaternion.RotateTowards(Quaternion.Euler(currentTurretRotation), Quaternion.Euler(maxTurretRotation), rotateSpeed * Time.deltaTime);

        Debug.DrawLine(transform.position, transform.position + transform.forward * 5.0f, Color.red);
        Debug.DrawLine(transform.position, player.transform.position, Color.blue);

        if (Mathf.Abs(Vector3.Angle(transform.forward, player.transform.position - transform.position)) <= 8.0f)
            prefabSpawning.targetAcquired = true;
        else
            prefabSpawning.targetAcquired = false;
    }

    public void Activate()
    {
        this.enabled = true;
        prefabSpawning.targetAcquired = true;
        cube.GetComponent<Renderer>().material.color = Color.red;
    }

    public void Deactivate()
    {
        cube.GetComponent<Renderer>().material.color = Color.gray;
        prefabSpawning.targetAcquired = false;
        this.enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
            this.Activate();
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
            this.Deactivate();
    }
}
