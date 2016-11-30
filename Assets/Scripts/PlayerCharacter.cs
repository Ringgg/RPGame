using UnityEngine;

public class PlayerCharacter : Living
{
    Vector3 respawnPosition;
    Rigidbody rb;

    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        respawnPosition = transform.position;
    }

    public override void Die()
    {
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
        rb.isKinematic = false;
        SetHp(maxHp);
        transform.position = respawnPosition;
    }
}
