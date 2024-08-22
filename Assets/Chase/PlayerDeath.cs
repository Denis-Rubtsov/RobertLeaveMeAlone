using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] LayerMask _enemyMask;
    Collider[] _enemies = new Collider[10];

    void Start()
    {
    }

    void Update()
    {
        var enemyCount = Physics.OverlapSphereNonAlloc(transform.position, 4, _enemies, _enemyMask);
        if (enemyCount >= 6) Destroy(gameObject);
    }
}
