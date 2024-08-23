using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float _spawnDelay;
    [SerializeField] GameObject _prefab;
    private Transform _player;
    Vector3 _enemySpawnPoint;

    void Start()
    {
        _player = FindObjectOfType<MotionScript>().transform;
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
        Vector3 newEnemySpawnPoint = _player.position;
        newEnemySpawnPoint.x += Random.RandomRange(-2, 2);
        newEnemySpawnPoint.z += Random.RandomRange(-2, 2);
        return newEnemySpawnPoint;
    }
}
