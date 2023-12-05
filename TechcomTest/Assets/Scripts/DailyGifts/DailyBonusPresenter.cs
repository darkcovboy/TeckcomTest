using System;
using System.Collections.Generic;
using MainMenu;
using Money;
using UnityEngine;
using Zenject;

namespace DailyGifts
{
    public class DailyBonusPresenter : ICloseble, ITickable
    {
        private DailyBonusModel _dailyBonusModel;
        private DailyBonusView _dailyBonusView;
        private List<DailyBonusObject> _dailyBonusObjects;
        private MoneyCounter _moneyCounter;
        private Panels _panel;
        private int _lastDay;

        public DailyBonusPresenter(DailyBonusModel dailyBonusModel, DailyBonusView dailyBonusView, MoneyCounter moneyCounter)
        {
            _dailyBonusModel = dailyBonusModel;
            _dailyBonusView = dailyBonusView;
            _dailyBonusView.Constructor(this);
            _panel = Panels.Gift;
            _moneyCounter = moneyCounter;
        }
        
        public void CreateGifts(Transform container)
        {
            _dailyBonusObjects = _dailyBonusModel.CreateGifts(container);

            foreach (var dailyBonusObject in _dailyBonusObjects)
            {
                dailyBonusObject.OnCLick += OnClick;
            }
        }
        
        public Panels GetPanelType() => _panel;

        public void OpenPanel() => _dailyBonusView.gameObject.SetActive(true);

        public void ClosePanel() => _dailyBonusView.gameObject.SetActive(false);
        
        public void Tick()
        {
            if ((_lastDay + 1) == DateTime.Now.Day)
            {
                _lastDay = DateTime.Now.Day;
                UpdateGifts(_lastDay);
            }
        }

        private void UpdateGifts(int day)
        {
            DailyBonusObject dailyBonusObject = _dailyBonusObjects.Find(x => x.Day == day);
            dailyBonusObject.CanTake();
            //Update data in loading data because now it's works only in Editor, need to update last tacked day and see in that case
            // and at last day update info about reset and start week period again
        }

        private void OnClick(DailyBonusObject dailyBonusObject)
        {
            if(!dailyBonusObject.CanTaked)
                return;
            
            _moneyCounter.AddMoney(dailyBonusObject.DailyBonusInfo.Money);
            dailyBonusObject.Take();
        }
    }
}