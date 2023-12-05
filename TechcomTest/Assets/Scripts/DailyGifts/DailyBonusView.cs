using System;
using UnityEngine;
using UnityEngine.UI;

namespace DailyGifts
{
    public class DailyBonusView : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Button _closeButton;
        [SerializeField] private GameObject _startDay;
        [SerializeField] private GameObject _lastDay;
        
        private DailyBonusPresenter _presenter;

        public void Constructor(DailyBonusPresenter presenter)
        {
            _presenter = presenter;
        }

        private void Start()
        {
            _presenter.CreateGifts(_container);
            _startDay.SetActive(true);
            _lastDay.SetActive(false);
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(_presenter.ClosePanel);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(_presenter.ClosePanel);
        }

        private void ShowLastDay()
        {
            _startDay.SetActive(false);
            _lastDay.SetActive(true);
        }
    }
}