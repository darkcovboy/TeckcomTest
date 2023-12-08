using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private Transform _ticketsContainer;
        [SerializeField] private Transform _skinsContainer;
        [SerializeField] private Transform _locationsContaier;
        [SerializeField] private Button _exitButton;

        private bool _isFirst = true;
        private ShopPresenter _shopPresenter;
        
        public void Constructor(ShopPresenter shopPresenter)
        {
            _shopPresenter = shopPresenter;
        }
        
        private void Start()
        {
            _shopPresenter.CreateSkins(_skinsContainer);
            _shopPresenter.CreateLocations(_locationsContaier);
            _shopPresenter.CreateTickets(_ticketsContainer);
        }

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(_shopPresenter.ClosePanel);
            if (!_isFirst)
                _shopPresenter.UpdateInfo();
            else
                _isFirst = false;
        }

        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(_shopPresenter.ClosePanel);
        }
    }
}