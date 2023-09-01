using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using UnityEngine.Events;

public class StartView : AbstractView
{
    [SerializeField] private Button playButton, exitButton;
    [SerializeField] private TextMeshPro versionText;
    [SerializeField] private Toggle soundToggle, musicToggle;

    public UnityEvent OnPlay { get; } = new UnityEvent();
    public UnityEvent<bool> OnSound { get; } = new UnityEvent<bool>();
    public UnityEvent<bool> OnMusic { get; } = new UnityEvent<bool>();

    public override void Init()
    {
        versionText.text = Application.version;
    }
    protected void OnEnable()
    {
        base.OnEnable();
        exitButton.onClick.AddListener(ExitButtonClicked);
        playButton.onClick.AddListener(PlayButtonClicked);
        soundToggle.onValueChanged.AddListener(OnSoundToggleClicked);
        musicToggle.onValueChanged.AddListener(OnMusicToggleClicked);
    }
    protected void OnDisable()
    {
        base.OnDisable();
        exitButton.onClick?.RemoveListener(ExitButtonClicked);
        playButton?.onClick?.RemoveListener(PlayButtonClicked);
        soundToggle.onValueChanged?.RemoveListener(OnSoundToggleClicked);
        musicToggle.onValueChanged?.RemoveListener(OnMusicToggleClicked);
    }
    private void ExitButtonClicked()
    {
#if Unity_Editor
EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }
    private void PlayButtonClicked()
    {
        OnPlay?.Invoke();
    }
    private void OnSoundToggleClicked(bool value)
    {
        Debug.Log($"Sound toggle - {value}");
        OnSound?.Invoke(value);
    }
    private void OnMusicToggleClicked(bool value)
    {
        Debug.Log($"Music toggle - {value}");
        OnMusic?.Invoke(value);
    }
}
