using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float _spawnDelay;
    [SerializeField] GameObject _prefab;
    [SerializeField] GameObject _player;
    Vector3 _enemySpawnPoint;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        _enemySpawnPoint = NewEnemySpawnPoint();
    }

    protected IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        var enemy = Instantiate(_prefab, _enemySpawnPoint, Quaternion.identity);
    }

    Vector3 NewEnemySpawnPoint()
    {
        Vector3 newEnemySpawnPoint = _player.transform.position;
        newEnemySpawnPoint.x += Random.Range(-2f, 2f);
        newEnemySpawnPoint.z += Random.Range(-2f, 2f);
        return newEnemySpawnPoint;
    }
}
