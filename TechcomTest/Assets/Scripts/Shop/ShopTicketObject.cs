using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopTicketObject : MonoBehaviour
    {
        public Action<ShopTicketObject> OnClick;
        
        [SerializeField] private TMP_Text _giveItMoney;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Button _buyButton;

        public void Render(ShopTicketData data)
        {
            _name.text = data.Name;
            _price.text = data.Price;
            _icon.sprite = data.Sprite;
            _giveItMoney.text = $"X{data.Money}";
        }

        private void OnEnable() => _buyButton.onClick.AddListener(Click);

        private void OnDisable() => _buyButton.onClick.RemoveListener(Click);

        private void Click() => OnClick?.Invoke(this);
    }
}