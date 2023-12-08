using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Shop
{
    public class ShopObject : MonoBehaviour
    {
        public event Action<ShopObject> OnClick;
        private const string LevelText = "Lv.";
        
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Image _icon;
        [SerializeField] private Price _price;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Image _buyedImage;
        [SerializeField] private TMP_Text _levelNeed;
        [SerializeField] private Image _lockImage;

        private void OnEnable()
        {
            _buyButton.onClick.AddListener(Click);
        }

        private void OnDisable()
        {
            _buyButton.onClick.RemoveListener(Click);
        }

        public void Render(ShopData shopData)
        {
            _icon.sprite = shopData.Icon;
            _name.text = shopData.Name;
            _price.UpdateText(shopData.Price);
            _levelNeed.text = $"{LevelText}{shopData.LevelNeed}";
        }

        public void Buy()
        {
            _price.gameObject.SetActive(false);
            _buyedImage.gameObject.SetActive(true);
            _buyButton.interactable = false;
        }

        public void Lock()
        {
            _levelNeed.gameObject.SetActive(true);
            _lockImage.gameObject.SetActive(true);
            _buyButton.interactable = false;
        }

        public void Unlock()
        {
            _levelNeed.gameObject.SetActive(false);
            _lockImage.gameObject.SetActive(false);
            _buyButton.interactable = true;
        }

        private void Click() => OnClick?.Invoke(this);
    }
}