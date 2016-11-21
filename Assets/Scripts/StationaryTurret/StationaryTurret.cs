using UnityEngine;
using System.Collections;

public class StationaryTurret : Living
{
    private GameObject player;
    private GameObject lookPosObj;
    private SphereCollider sphereCollider;
	private float timer;
    private float playerTurretAngle;
    [SerializeField] private float attackRadius;
    private float rotateSpeed;

	public override void Start() 
	{
        //attackRadius = 20.0f; //in meters;
        rotateSpeed = 15.0f; //in degrees/second

		player = GameObject.FindGameObjectWithTag("Player");
        weapon = GetComponent<ProjectileWeapon>();
        sphereCollider = GetComponent<SphereCollider>();
        lookPosObj = new GameObject();

        lookPosObj.transform.SetParent(transform);
        playerTurretAngle = XZAngleBetweenVectors(Vector3.forward, (transform.position - player.transform.position));
        sphereCollider.radius = attackRadius;
        base.Start();
	}

	void Update()
	{
		timer += Time.deltaTime;
        float newPlayerTurretAngle = XZAngleBetweenVectors(Vector3.forward, (transform.position - player.transform.position));

        if (newPlayerTurretAngle <= playerTurretAngle + rotateSpeed &&
            newPlayerTurretAngle >= playerTurretAngle - rotateSpeed)
        {
            transform.LookAt(player.transform, Vector3.up);
        }
        else
        {
            float distToPlayer = XZDistanceBetweenPoints(transform.position, player.transform.position);
            
            Vector3 lookPos = new Vector3(
                                  distToPlayer * Mathf.Cos(newPlayerTurretAngle * Mathf.Deg2Rad),
                                  player.transform.position.y,
                                  distToPlayer * Mathf.Sin(newPlayerTurretAngle * Mathf.Deg2Rad));
            lookPosObj.transform.position = lookPos;
            
            transform.LookAt(lookPosObj.transform, Vector3.up);
        }

        playerTurretAngle = newPlayerTurretAngle;

		if (timer > weapon.stats.reloadSpeed) 
		{
            ShootProjectile();
			timer = 0.0f;
		}
	}

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
        

    private float XZAngleBetweenVectors(Vector3 first, Vector3 second)
    {
        return Vector3.Angle(
            new Vector3(
                first.x, 
                0.0f, 
                first.z),
            new Vector3(
                second.x, 
                0.0f,
                second.z));
    }

    private float XZDistanceBetweenPoints(Vector3 first, Vector3 second)
    {
        return Vector3.Distance(
            new Vector3(
                first.x,
                0.0f,
                first.z),
            new Vector3(
                second.x,
                0.0f,
                second.z));
    }

    public void Activate()
    {
        GetComponent<Renderer>().material.color = Color.red;
        timer = 0.0f;
    }

    public void Deactivate()
    {
        GetComponent<Renderer>().material.color = Color.gray;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.enabled = true;
            this.Activate();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.enabled = false;
            this.Deactivate();
        }
    }
}
