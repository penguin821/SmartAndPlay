using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : LifeManagement
{
    NavMeshAgent pathfinder;
    public GameObject player;
     

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        pathfinder = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        if (!dead)
        {
            pathfinder.SetDestination(targetPosition);
        }
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = 0.25f;

        while (player != null) 
        {
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
