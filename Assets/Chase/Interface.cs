using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interface : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _enemyCount;
    [SerializeField] TextMeshProUGUI _timer;
    [SerializeField] TextMeshProUGUI _gameOverTime;
    [SerializeField] PlayerChase _player;
    [SerializeField] GameObject _gameOverMenu;
    [SerializeField] GameObject _enemySpawner;
    float _time = 0;

    void Update()
    {
        if (!_player.IsDead)
        {
            _time += Time.deltaTime;
            _timer.text = $"{_time} сек";
            _enemyCount.text = $"{_player.EnemyCount}";
        }
        else
        {
            _gameOverMenu.active = true;
            _enemySpawner.active = false;
            _gameOverTime.text = $"{_time} секунд";
        }
    }
}
