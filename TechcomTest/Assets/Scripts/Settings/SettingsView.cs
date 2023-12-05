using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Settings
{
    public class SettingsView : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _soundButton;
        [SerializeField] private Button _musicButton;
        [SerializeField] private Sprite _musicOnSprite;
        [SerializeField] private Sprite _musicOffSprite;
        [SerializeField] private Sprite _soundOnSprite;
        [SerializeField] private Sprite _soundOffSprite;
        private SettingsPresenter _settingsPresenter;

        public void Constructor(SettingsPresenter settingsPresenter)
        {
            _settingsPresenter = settingsPresenter;
        }

        private void OnEnable()
        {
            _soundButton.onClick.AddListener(_settingsPresenter.ToggleSound);
            _musicButton.onClick.AddListener(_settingsPresenter.ToggleMusic);
            _exitButton.onClick.AddListener(_settingsPresenter.ClosePanel);
        }

        private void OnDisable()
        {
            _soundButton.onClick.RemoveListener(_settingsPresenter.ToggleSound);
            _musicButton.onClick.RemoveListener(_settingsPresenter.ToggleMusic);
            _exitButton.onClick.RemoveListener(_settingsPresenter.ClosePanel);
        }
        
        public void SetSoundButtonSprite(bool isSoundOn)
        {
            _soundButton.image.sprite = isSoundOn ? _soundOnSprite : _soundOffSprite;
        }

        public void SetMusicButtonSprite(bool isMusicOn)
        {
            _musicButton.image.sprite = isMusicOn ? _musicOnSprite : _musicOffSprite;
        }
    }
}