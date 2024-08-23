using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByTrap : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyDeath>(out var enemyDeath)) enemyDeath.Die();
        if (other.TryGetComponent<PlayerChase>(out var playerChase)) playerChase.Die();
    }
}
