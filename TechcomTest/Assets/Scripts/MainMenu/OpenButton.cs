using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MainMenu
{
    [RequireComponent(typeof(Button))]
    public class OpenButton : MonoBehaviour
    {
        [SerializeField] private Panels _panel;
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _audioSource;
        
        private MenuPresenter _menuPresenter;

        [Inject]
        public void Constructor(MenuPresenter menuPresenter)
        {
            _menuPresenter = menuPresenter;
        }

        private void OnValidate()
        {
            if (_button == null)
                _button = gameObject.GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(() => _menuPresenter.Open(_panel));
            _button.onClick.AddListener(() =>
            {
                if(_audioSource.enabled)
                    _audioSource.Play();
            });
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(() => _menuPresenter.Open(_panel));
            _button.onClick.RemoveListener(() =>
            {
                if(_audioSource.enabled)
                    _audioSource.Play();
            });
        }
    }
}