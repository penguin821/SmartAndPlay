using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour
{
    [SerializeField]
    Transform transTarget;

    LifeManagement playerEntity;
    bool isDisabled;

    void Start()
    {
        playerEntity = FindObjectOfType<Player>();
        playerEntity.OnDeath += OnPlayerDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDisabled)
            transform.position = transTarget.position;
    }

    void OnPlayerDeath()
    {
        isDisabled = true;
    }
}
