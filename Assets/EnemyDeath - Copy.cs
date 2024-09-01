using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Animator _animator;
    [SerializeField] float _despawnTimer;
    public bool IsDead { get; private set; }

    public void Die()
    {
        _agent.isStopped = true;
        _animator.SetTrigger("Died");
        StartCoroutine(Despawn());
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(_despawnTimer);
        Destroy(gameObject);
    }
}
