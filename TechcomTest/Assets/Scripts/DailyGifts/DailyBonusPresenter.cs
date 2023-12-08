using System;
using System.Collections.Generic;
using MainMenu;
using Money;
using UnityEngine;
using Zenject;

namespace DailyGifts
{
    public class DailyBonusPresenter : ICloseble, ITickable, IGiftDayHandler
    {
        public event Action<int, int> OnGiftTaked;
        
        private const int DaysInWeek = 7;
        private const int StartValue = 0;
        
        private DailyBonusModel _dailyBonusModel;
        private DailyBonusView _dailyBonusView;
        private List<DailyBonusObject> _dailyBonusObjects;
        private MoneyCounter _moneyCounter;
        private Panels _panel;
        private int _lastDay;
        private int _currentDay;
        

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
            _currentDay = StartValue;
            OnGiftTaked?.Invoke(_currentDay, DaysInWeek);

            foreach (var dailyBonusObject in _dailyBonusObjects)
            {
                dailyBonusObject.OnCLick += OnClick;
            }

            _lastDay = DateTime.Now.Day;
            
            //We need here to see what gifts we already take and see what we should update but now see only first
            
            UpdateGifts(DateTime.Now.Day);
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
            _currentDay++;
            OnGiftTaked?.Invoke(_currentDay, DaysInWeek);
        }
    }
}