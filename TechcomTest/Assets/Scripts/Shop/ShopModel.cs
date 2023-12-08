using System.Collections.Generic;
using Money;
using PlayerData;
using UnityEngine;

namespace Shop
{
    public class ShopModel
    {
        private ShopDataContainer _shopDataContainer;
        private ShopFactory _shopFactory;
        private PlayerSavedData _playerSavedData;
        private MoneyCounter _moneyCounter;
        private Dictionary<ShopObject, SkinData> _skins;
        private Dictionary<ShopObject, LocationData> _locations;
        private Dictionary<ShopTicketObject, ShopTicketData> _tickets;
        private IAPManager _iapManager;
        
        
        public ShopModel(ShopDataContainer shopDataContainer, ShopFactory shopFactory, PlayerSavedData playerSavedData, MoneyCounter moneyCounter, IAPManager iapManager)
        {
            _shopDataContainer = shopDataContainer;
            _shopFactory = shopFactory;
            _playerSavedData = playerSavedData;
            _moneyCounter = moneyCounter;
            _iapManager = iapManager;
        }

        public void UpdateInfo()
        {
            foreach (var location in _locations)
            {
                if(_playerSavedData.Data.CompletedLevels.Contains(location.Value.LevelNeed))
                    location.Key.Unlock();
            }
            
            foreach (var skin in _skins)
            {
                if(_playerSavedData.Data.CompletedLevels.Contains(skin.Value.LevelNeed))
                    skin.Key.Unlock();
            }
        }

        public void CreateSkins(Transform container)
        {
            _skins = new Dictionary<ShopObject, SkinData>();
            foreach (SkinData skinData in _shopDataContainer.SkinDatas)
            {
                ShopObject shopObject = _shopFactory.Get(skinData, container);
                _skins.Add(shopObject,skinData);
                shopObject.OnClick += OnSkinClick;
                
                if(_playerSavedData.Data.CompletedLevels.Contains(skinData.LevelNeed))
                    shopObject.Unlock();
                else
                    shopObject.Lock();
                
                if(_playerSavedData.Data.BuyedSkins.Contains(skinData.Skin))
                    shopObject.Buy();
            }
        }

        public void CreateLocations(Transform container)
        {
            _locations = new Dictionary<ShopObject, LocationData>();

            foreach (var locationData in _shopDataContainer.LocationDatas)
            {
                ShopObject shopObject = _shopFactory.Get(locationData, container);
                _locations.Add(shopObject, locationData);
                shopObject.OnClick += OnLocationClick;
                
                if(_playerSavedData.Data.CompletedLevels.Contains(locationData.LevelNeed))
                    shopObject.Unlock();
                else
                    shopObject.Lock();
                
                if(_playerSavedData.Data.BuyedLocations.Contains(locationData.Location))
                    shopObject.Buy();
            }
        }

        public void CreateTickets(Transform container)
        {
            _tickets = new Dictionary<ShopTicketObject, ShopTicketData>();
            
            foreach (var shopTicketData in _shopDataContainer.ShopTicketDatas)
            {
                ShopTicketObject shopTicketObject =
                    _shopFactory.Get(shopTicketData, container);
                
                _tickets.Add(shopTicketObject, shopTicketData);

                shopTicketObject.OnClick += OnTicketClick;
            }
        }

        private void OnLocationClick(ShopObject shopObject)
        {
            LocationData locationData = _locations[shopObject];
            
            if(locationData.Price > _moneyCounter.Money)
                return;
            
            _moneyCounter.TakeMoney(locationData.Price);
            shopObject.Buy();
            _playerSavedData.OpenLocation(locationData.Location);
        }

        private void OnSkinClick(ShopObject shopObject)
        {
            SkinData skinData = _skins[shopObject];
            
            if(skinData.Price > _moneyCounter.Money)
                return;
            
            _moneyCounter.TakeMoney(skinData.Price);
            shopObject.Buy();
            _playerSavedData.OpenSkin(skinData.Skin);
        }

        private void OnTicketClick(ShopTicketObject ticketObject)
        {
            ShopTicketData ticketData = _tickets[ticketObject];
            
            _iapManager.BuyProduct(ticketData.Id);
        }
    }
}