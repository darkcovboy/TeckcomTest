using UnityEngine;

namespace Settings
{
    public class SoundsHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource[] _audioSources;

        public void SwitchAudio(bool isOn)
        {
            if(isOn)
                OnSounds();
            else
                OffSounds();
        }

        private void OffSounds()
        {
            foreach (var audio in _audioSources)
            {
                audio.enabled = false;
            }
        }

        private void OnSounds()
        {
            foreach (var audio in _audioSources)
            {
                audio.enabled = true;
            }
        }
    }
}