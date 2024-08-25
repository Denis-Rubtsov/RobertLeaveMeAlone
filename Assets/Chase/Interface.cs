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
    float _record;
    bool _gameEnded = false;

    private void OnEnable()
    {
        _mainMenuButton.onClick.AddListener(MainMenuClicked);
        _restartButton.onClick.AddListener(RestartClicked);
    }

    private void Start()
    {
        _record = Restore();
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
            _timer.text = $"{_time} seconds\nRecord: {_record}";
            _enemyCount.text = $"Enemies nearby: {_player.EnemyCount}";
        }
        else if(!_gameEnded) EndGame();
    }

    private void OnDisable()
    {
        _mainMenuButton.onClick?.RemoveAllListeners();
        _restartButton.onClick?.RemoveAllListeners();
    }

    void EndGame()
    {
        _gameOverMenu.SetActive(true);
        _enemySpawner.SetActive(false);
        if (_time > _record)
        {
            _gameOverTime.text = $"New Record!\n{_time} seconds";
            Save(_time);
        }
        else _gameOverTime.text = $"{_time} seconds\nRecord: {_record} seconds";
        _gameEnded = true;
        var enemies = FindObjectsOfType<NavMeshMover>();
        foreach (var enemy in enemies) Destroy(enemy.gameObject);
    }

    void Save(float time) => PlayerPrefs.SetFloat("ChaseRecord", time);

    float Restore()
    {
        float time;
        if (PlayerPrefs.HasKey("ChaseRecord"))
        {
            time = PlayerPrefs.GetFloat("ChaseRecord");
            return time;
        }
        else return 0;
    }
}
