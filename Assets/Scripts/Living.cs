using UnityEngine;
using System.Collections;

public class Living : MonoBehaviour
{
    public bool canDie = true;
    protected ProjectileWeapon weapon;
    protected GameObject indicator;

    public float maxHp = 100.0f;

    [SerializeField]
    float _hp;
    public float hp
    {
        get
        {
            return _hp;
        }
        private set
        {
            _hp = Mathf.Clamp(value, 0.0f, maxHp);
        }
    }

    public GameObject deathEffect; // disappears by itself
    public GameObject healEffect; // disappears by itself
    public GameObject damageEffect; // disappears by itself
    public GameObject healOverTimeEffect; // deleted from script

    public virtual void Start()
    {
        hp = maxHp;
    }

    public virtual void Die()
    {
        if (deathEffect != null)
            Instantiate(deathEffect, transform.position, deathEffect.transform.rotation);
    }

    public virtual void SetHp(float value)
    {
        hp = value;

        if (canDie && hp == 0)
            Die();
    }

    public virtual void ChangeHP(float change)
    {
        SetHp(hp + change);
    }

    public virtual void TakeDamage(float ammount)
    {
        if (ammount < 0)
            return;
        if (damageEffect != null)  
            Instantiate(damageEffect, transform.position, damageEffect.transform.rotation);
        ChangeHP(-ammount);
        Debug.Log(gameObject.name + " received " + ammount + " dmg!");
    }

    public virtual void HealDamage(float ammount)
    {
        if (ammount < 0)
            return;
        if (healEffect != null)
            Instantiate(healEffect, transform.position, healEffect.transform.rotation);
        ChangeHP(ammount);
    }

    public virtual void ChangeOverTime(float ammount, float time)
    {
        StartCoroutine(ChangeOverTimeEnum(ammount / time, time));
    }

    IEnumerator ChangeOverTimeEnum(float rate, float time)
    {
        GameObject effect = null;
        if (healOverTimeEffect != null)
            effect = Instantiate(healOverTimeEffect, transform.position, healOverTimeEffect.transform.rotation) as GameObject;
        while (time > 0.0f)
        {
            if (effect != null)
                effect.transform.position = transform.position;
            ChangeHP(Time.deltaTime * rate);
            time -= Time.deltaTime;
            yield return null;
        }
        if (effect != null)
            Destroy(effect);
    }

    public void ShootProjectile()
    {
        weapon.Init(indicator.transform.position);
        weapon.Shoot();
    }

    public void InitIndicator(GameObject obj) {indicator = obj;}
}
