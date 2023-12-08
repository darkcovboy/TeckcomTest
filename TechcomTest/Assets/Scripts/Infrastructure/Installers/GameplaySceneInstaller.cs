using System.Collections.Generic;
using Configs;
using DailyGifts;
using Levels;
using MainMenu;
using UnityEngine;
using Zenject;
using Money;
using PlayerData;
using Settings;
using Shop;

namespace Infrastructure.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private GameConfig _gameConfig;
        [Header("Views")] 
        [SerializeField] private SettingsView _settingsView;
        [SerializeField] private DailyBonusView _dailyBonusView;
        [SerializeField] private LevelsView _levelsView;
        [SerializeField] private ShopView _shopView;
        [Header("Datas")] 
        [SerializeField] private DailyBonusInfoContainer _dailyBonusInfoContainer;
        [SerializeField] private DailyBonusFabric _dailyBonusFabric;
        [SerializeField] private ShopFactory _shopFactory;
        [SerializeField] private ShopDataContainer _shopDataContainer;

        [Header("Other Objects")] 
        [SerializeField] private MusicHandler _musicHandler;

        [SerializeField] private SoundsHandler _soundsHandler;
        
        public override void InstallBindings()
        {
            BindPlayerData();
            BindMoneyCounter();
            BindIAPManager();
            BindShop();
            BindLevels();
            BindDailyGift();
            BindSettingsScreen();
            BindMenu();
        }

        private void BindIAPManager()
        {
            Container.Bind<IAPManager>()
                .AsSingle();
        }

        private void BindShop()
        {
            Container.Bind<ShopModel>()
                .AsSingle()
                .WithArguments(_shopFactory, _shopDataContainer);
            Container.Bind<ShopView>()
                .FromInstance(_shopView)
                .AsSingle();
            Container.BindInterfacesAndSelfTo<ShopPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindLevels()
        {
            Container.Bind<LevelsView>().FromInstance(_levelsView).AsSingle();
            Container.BindInterfacesAndSelfTo<LevelsPresenter>().AsSingle();
        }

        private void BindPlayerData()
        {
            Container.Bind<PlayerSavedData>().AsSingle();
        }

        private void BindDailyGift()
        {
            Container.Bind<DailyBonusModel>()
                .AsSingle()
                .WithArguments(_dailyBonusInfoContainer, _dailyBonusFabric);
            Container.Bind<DailyBonusView>()
                .FromInstance(_dailyBonusView)
                .AsSingle();
            Container.BindInterfacesAndSelfTo<DailyBonusPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindMenu()
        {
            List<ICloseble> closeablePanels = Container.ResolveAll<ICloseble>();
            Debug.Log(closeablePanels.Count);
            Container.Bind<MenuPresenter>()
                .AsSingle()
                .WithArguments(closeablePanels);
        }

        private void BindMoneyCounter()
        {
            Container.BindInterfacesAndSelfTo<MoneyCounter>()
                .AsSingle();
        }

        private void BindSettingsScreen()
        {
            Container.Bind<SoundsHandler>()
                .FromInstance(_soundsHandler)
                .AsSingle();
            Container.BindInterfacesAndSelfTo<MusicHandler>()
                .FromInstance(_musicHandler)
                .AsSingle();
            Container.Bind<SettingsModel>()
                .AsSingle();
            Container.Bind<SettingsView>()
                .FromInstance(_settingsView)
                .AsSingle();
            Container.BindInterfacesAndSelfTo<SettingsPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}