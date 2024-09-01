using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _chaseButton;
    [SerializeField] Button _battleButton;
    [SerializeField] Button _exitButton;

    private void OnEnable()
    {
        _chaseButton.onClick.AddListener(ChaseClicked);
        _battleButton.onClick.AddListener(BattleClicked);
        _exitButton.onClick.AddListener(ExitClicked);
    }

    void ChaseClicked()
    {
        if (_chaseButton.TryGetComponent<AudioSource>(out var source)) source.Play();
        SceneManager.LoadScene("ChaseScene");
    }

    void ExitClicked()
    {
        if (_exitButton.TryGetComponent<AudioSource>(out var source)) source.Play();
        Application.Quit();
    }

    void BattleClicked()
    {
        if (_battleButton.TryGetComponent<AudioSource>(out var source)) source.Play();
    }

    private void OnDisable()
    {
        _chaseButton.onClick?.RemoveListener(ChaseClicked);
        _battleButton.onClick?.RemoveListener(BattleClicked);
        _exitButton.onClick?.RemoveAllListeners();
    }
}
