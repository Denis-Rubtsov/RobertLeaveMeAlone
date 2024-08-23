using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChase : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] LayerMask _enemyMask;
    [SerializeField] float _despawnTime;
    Collider[] _enemies = new Collider[10];
    public int EnemyCount { get; private set; }
    public bool IsDead { get; private set; } = false;

    void Update()
    {
        EnemyCount = Physics.OverlapSphereNonAlloc(transform.position, 4, _enemies, _enemyMask);
        if (EnemyCount >= 6)
        {
            IsDead = true;
            _animator.SetTrigger("Died");
            StartCoroutine(Despawn());
        }
    }

    public void Die()
    {
        IsDead = true;
        _animator.SetTrigger("Died");
        StartCoroutine(Despawn());
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(_despawnTime);
        Destroy(gameObject);
    }
}
