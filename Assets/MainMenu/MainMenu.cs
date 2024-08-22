using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _chaseButton;
    [SerializeField] Button _battleButton;

    private void OnEnable()
    {
        _chaseButton.onClick.AddListener(ChaseClicked);
        _battleButton.onClick.AddListener(BattleClicked);
    }

    void ChaseClicked()
    {
        SceneManager.LoadScene("ChaseScene");
    }

    void BattleClicked()
    {

    }

    private void OnDisable()
    {
        _chaseButton.onClick?.RemoveListener(ChaseClicked);
        _battleButton.onClick?.RemoveListener(BattleClicked);
    }
}
