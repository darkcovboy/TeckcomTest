using MainMenu;
using UnityEngine;
using Zenject;

namespace Settings
{
    public class SettingsPresenter : ICloseble
    {
        private readonly SettingsView _settingsView;
        private readonly SettingsModel _settingsModel;
        private readonly Panels _panel;

        public SettingsPresenter(SettingsView settingsView, SettingsModel settingsModel)
        {
            _settingsModel = settingsModel;
            _settingsView = settingsView;
            _settingsView.Constructor(this);
            _settingsModel.IsMusicOn = true;
            _settingsModel.IsSoundOn = true;
            _panel = Panels.Settings;
        }

        public void ToggleSound()
        {
            _settingsModel.IsSoundOn = !_settingsModel.IsSoundOn;
            _settingsView.SetSoundButtonSprite(_settingsModel.IsSoundOn);
        }

        public void ToggleMusic()
        {
            _settingsModel.IsMusicOn = !_settingsModel.IsMusicOn;
            _settingsView.SetMusicButtonSprite(_settingsModel.IsMusicOn);
        }

        public Panels GetPanelType() => _panel;

        public void OpenPanel() => _settingsView.gameObject.SetActive(true);

        public void ClosePanel() => _settingsView.gameObject.SetActive(false);
    }
}