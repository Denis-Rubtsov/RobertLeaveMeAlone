using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Interface : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _enemyCount;
    [SerializeField] TextMeshProUGUI _timer;
    [SerializeField] TextMeshProUGUI _gameOverTime;
    [SerializeField] PlayerChase _player;
    [SerializeField] GameObject _gameOverMenu;
    [SerializeField] GameObject _enemySpawner;
    [SerializeField] Button _mainMenuButton;
    [SerializeField] Button _restartButton;
    float _time = 0;
    bool _gameEnded = false;

    private void OnEnable()
    {
        _mainMenuButton.onClick.AddListener(MainMenuClicked);
        _restartButton.onClick.AddListener(RestartClicked);
    }

    void RestartClicked()
    {
        SceneManager.LoadScene("ChaseScene");
    }

    void MainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        if (!_player.IsDead && !Input.GetKeyDown(KeyCode.Escape) && !_gameEnded)
        {
            _time += Time.deltaTime;
            _timer.text = $"{_time} сек";
            _enemyCount.text = $"Врагов рядом: {_player.EnemyCount}";
        }
        else 
        {
            _gameOverMenu.active = true;
            _enemySpawner.active = false;
            _gameOverTime.text = $"{_time} секунд";
            _gameEnded = true;
        }
    }

    private void OnDisable()
    {
        _mainMenuButton.onClick?.RemoveAllListeners();
        _restartButton.onClick?.RemoveAllListeners();
    }
}
