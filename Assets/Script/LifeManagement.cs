using System.Collections;
using UnityEngine;

public class LifeManagement : MonoBehaviour,IDamage
{
    public float startingHealth;
    protected float health;
    protected bool dead;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        health = startingHealth;
    }

    public void TakeHit(float damage, RaycastHit hit)
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
        GameObject.Destroy(gameObject);
    }
}
