namespace Settings
{
    public class SettingsModel
    {
        private bool _isSoundOn;
        private bool _isMusicOn;
        private IMusicHandler _musicHandler;
        private SoundsHandler _soundsHandler;

        public SettingsModel(IMusicHandler musicHandler, SoundsHandler soundsHandler)
        {
            _musicHandler = musicHandler;
            _soundsHandler = soundsHandler;
        }

        public bool IsSoundOn
        {
            get => _isSoundOn;
            set
            {
                _isSoundOn = value;
                SwitchAudio(_isSoundOn);
            }
        }

        public bool IsMusicOn
        {
            get => _isMusicOn;
            set
            {
                _isMusicOn = value;
                SwitchMusic(_isMusicOn);
            }
        }

        public void SwitchMusic(bool isOn)
        {
            _musicHandler.SwitchMusic(isOn);
        }

        public void SwitchAudio(bool isOn)
        {
            _soundsHandler.SwitchAudio(isOn);
        }
    }
}