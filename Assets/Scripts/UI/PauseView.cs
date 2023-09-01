using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class PauseView : AbstractView
{
    [SerializeField] private Button resumeButton, restartButton, menuButton;
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private NavigationFlow _navigationFlow;

    public UnityEvent OnResume { get; } = new UnityEvent();
    public UnityEvent OnRestart { get; } = new UnityEvent();
    public UnityEvent OnMenu { get; } = new UnityEvent();
    public override void Init()
    {
        Debug.Log("Pause view activated!");
        _navigationFlow.OnScoreValueChanged.AddListener(ShowScore);
    }
    protected void OnEnable()
    {
        base.OnEnable();
        resumeButton.onClick.AddListener(OnResumeButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        menuButton.onClick.AddListener(OnMenuButtonClicked);
    }
    protected void OnDisable()
    {
        base.OnDisable();
        resumeButton.onClick?.RemoveListener(OnResumeButtonClicked);
        restartButton.onClick?.RemoveListener(OnRestartButtonClicked);
        menuButton.onClick?.RemoveListener(OnMenuButtonClicked);
    }
    private void OnResumeButtonClicked()
    {
        OnResume?.Invoke();
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
