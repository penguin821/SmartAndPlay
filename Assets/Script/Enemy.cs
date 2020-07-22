using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent pathfinder;
    public GameObject player;
     

    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = 1f;

        while (player != null) 
        {
            Vector3 targetPosition = new Vector3(player.transform.position.x, 0, player.transform.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
