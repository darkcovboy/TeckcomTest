using MainMenu;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class ShopPresenter : ICloseble
    {
        private ShopModel _shopModel;
        private ShopView _shopView;
        private Panels _panel;

        public ShopPresenter(ShopModel shopModel, ShopView shopView)
        {
            _shopModel = shopModel;
            _shopView = shopView;
            _shopView.Constructor(this);
            _panel = Panels.Shop;
        }

        public void CreateSkins(Transform container)
        {
            _shopModel.CreateSkins(container);
        }

        public void CreateLocations(Transform container)
        {
            _shopModel.CreateLocations(container);
        }

        public void CreateTickets(Transform container)
        {
            _shopModel.CreateTickets(container);
        }

        public Panels GetPanelType() => _panel;

        public void OpenPanel() => _shopView.gameObject.SetActive(true);

        public void ClosePanel() => _shopView.gameObject.SetActive(false);

        public void UpdateInfo()
        {
            _shopModel.UpdateInfo();
        }
    }
}