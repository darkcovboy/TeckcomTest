using System.Collections.Generic;
using Configs;
using DailyGifts;
using MainMenu;
using UnityEngine;
using Zenject;
using Money;
using Settings;

namespace Infrastructure.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private GameConfig _gameConfig;
        [Header("Views")] 
        [SerializeField] private SettingsView _settingsView;
        [SerializeField] private DailyBonusView _dailyBonusView;
        [Header("Datas")] 
        [SerializeField] private DailyBonusInfoContainer _dailyBonusInfoContainer;
        [SerializeField] private DailyBonusFabric _dailyBonusFabric;

        [Header("Other Objects")] 
        [SerializeField] private MusicHandler _musicHandler;
        
        public override void InstallBindings()
        {
            BindMoneyCounter();
            BindDailyGift();
            BindSettingsScreen();
            BindMenu();
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
                .AsSingle()
                .WithArguments(_gameConfig.StartMoney);
        }

        private void BindSettingsScreen()
        {
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