using UnityEngine;

public class PlayerCharacter : Living
{
    Vector3 respawnPosition;
    Rigidbody rb;

    public override void Start()
    {
        weapon = GetComponent<ProjectileWeapon>();
        rb = GetComponent<Rigidbody>();
        respawnPosition = transform.position;
        EventManager.StartListening(EventType.ShootProjectile, ShootProjectile);
        base.Start();
    }

    public override void Die()
    {
        EventManager.StopListening(EventType.ShootProjectile, ShootProjectile);
        base.Die();
        rb.isKinematic = true;
        Invoke("Respawn", 1.0f);
    }

    public void SetRespawnPosition(Vector3 position)
    {
        respawnPosition = position;
    }
        
    void Respawn()
    {
        EventManager.StartListening(EventType.ShootProjectile, ShootProjectile);
        rb.isKinematic = false;
        SetHp(maxHp);
        transform.position = respawnPosition;
    }

    void OnDestroy()
    {
        EventManager.StopListening(EventType.ShootProjectile, ShootProjectile);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Turret")
        {
            col.gameObject.GetComponent<StationaryTurret>().enabled = true;
            col.gameObject.GetComponent<StationaryTurret>().Activate();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Turret")
        {
            col.gameObject.GetComponent<StationaryTurret>().enabled = false;
            col.gameObject.GetComponent<StationaryTurret>().Deactivate();
        }
    }
}
