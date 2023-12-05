using System;
using UnityEngine;

namespace Settings
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicHandler : MonoBehaviour, IMusicHandler
    {
        [SerializeField] private AudioSource _music;

        private void OnValidate()
        {
            if (_music == null)
                _music = GetComponent<AudioSource>();
        }

        public void SwitchMusic(bool isOn)
        {
            if(isOn)
                _music.Play();
            else
                _music.Pause();
        }
    }
}