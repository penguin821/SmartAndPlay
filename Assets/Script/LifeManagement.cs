using System.Collections;
using UnityEngine;

public class LifeManagement : MonoBehaviour,IDamage
{
    public float startingHealth;
    protected float health;
    protected bool dead;

    public event System.Action OnDeath;

    // Start is called before the first frame update
    protected virtual void Start()
    { 
        health = startingHealth;
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        //여기에 hit 변수 사용해서 뭐 만들거
        TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }
}
