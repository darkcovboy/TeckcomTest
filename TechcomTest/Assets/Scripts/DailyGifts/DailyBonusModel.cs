using System;
using System.Collections.Generic;
using UnityEngine;

namespace DailyGifts
{
    public class DailyBonusModel
    {
        private DailyBonusFabric _dailyBonusFabric;
        private DailyBonusInfoContainer _dailyBonusInfoContainer;
        
        public DailyBonusModel(DailyBonusFabric fabric, DailyBonusInfoContainer dailyBonusInfoContainer)
        {
            _dailyBonusFabric = fabric;
            _dailyBonusInfoContainer = dailyBonusInfoContainer;
        }

        public List<DailyBonusObject> CreateGifts(Transform container)
        {
            List<DailyBonusObject> dailyBonusInfos = new List<DailyBonusObject>();

            int currentDay = DateTime.Now.Day;
            
            foreach (var dailyBonusInfo in _dailyBonusInfoContainer.DailyBonusInfos)
            {
                DailyBonusObject dailyBonusObject = _dailyBonusFabric.Get(container, dailyBonusInfo, currentDay);
                dailyBonusInfos.Add(dailyBonusObject);
                currentDay++;
            }

            return dailyBonusInfos;
        }
    }
}