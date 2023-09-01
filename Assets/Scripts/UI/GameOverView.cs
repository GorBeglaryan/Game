using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameOverView : AbstractView
{
    [SerializeField] private Button restartButton, menuButton;
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private NavigationFlow _navigationFlow;
    public UnityEvent OnRestart { get; } = new UnityEvent();
    public UnityEvent OnMenu { get; } = new UnityEvent();
    public override void Init()
    {
        Debug.Log("Game over view activated!");
        _navigationFlow.OnScoreValueChanged.AddListener(ShowScore);
    }
    protected void OnEnable()
    {
        base.OnEnable();
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        menuButton.onClick.AddListener(OnMenuButtonClicked);
    }
    protected void OnDisable()
    {
        base.OnDisable();
        restartButton.onClick?.RemoveListener(OnRestartButtonClicked);
        menuButton.onClick?.RemoveListener(OnMenuButtonClicked);
    }
    private void OnRestartButtonClicked()
    {
        OnRestart?.Invoke();
    }
    private void OnMenuButtonClicked()
    {
        OnMenu?.Invoke();
    }
    private void ShowScore(int value)
    {
        scoreText.text = value.ToString();
    }
}
