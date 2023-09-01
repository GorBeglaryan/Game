using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private NavigationFlow _navigationFlow;
    [SerializeField] private BoxMovement _boxMovement;

    private int score;
    private bool isPLaying = false, isGameOver = false;

    public UnityEvent OnGameOver { get; } = new UnityEvent();
    public UnityEvent<int> OnScoreValueChanged { get; } = new UnityEvent<int>();
    private void Start()
    {
        _navigationFlow.OnStart.AddListener(StartGame);
        _navigationFlow.OnPause.AddListener(PauseGame);
        _boxMovement.OnBoxEntered.AddListener(ChangeScore);
        _navigationFlow.Init();
    }

    private void Update()
    {
        if (isPLaying)
        {
            //game play scripts
            _boxMovement.UpdateFrame();
            return;
        }
        if(isGameOver)
        {
            OnGameOver?.Invoke();
            isGameOver = false;
        }
    }
    private void StartGame()
    {
        isPLaying = true;
    }
    private void PauseGame()
    {
        isPLaying = false;
    }
    private void ChangeScore(int value)
    {
        score = value < -5 ? -1 : score + value;
        OnScoreValueChanged?.Invoke(score);
        if (score < 0)
        {
            isPLaying = false;
            isGameOver = true;
        }
    }
}