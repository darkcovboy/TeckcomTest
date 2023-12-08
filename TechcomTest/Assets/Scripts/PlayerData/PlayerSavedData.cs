using System.Collections.Generic;
using System.IO;
using ModestTree;
using UnityEngine;

namespace PlayerData
{
    public class PlayerSavedData
    {
        private const string DataPath = "Assets/Resources/Data/Data.json";
        private const int StartMoney = 50;

        public PlayerSavedData()
        {
            string json = File.ReadAllText(DataPath);
            
            if (string.IsNullOrEmpty(json) || json == "{}")
            {
                Data = CreateNewData();
                json = JsonUtility.ToJson(Data);
                File.WriteAllText(DataPath, json);
            }
            else
            {
                Data = JsonUtility.FromJson<Data>(json);
            }
            
            Debug.Log(Data.Money);
        }

        private Data CreateNewData()
        {
            Data data = new Data();
            data.Money = StartMoney;
            data.BuyedLocations = new List<Locations>();
            data.BuyedLocations.Add(Locations.Location1);
            data.CompletedLevels = new List<int>();
            data.CompletedLevels.Add(0);
            data.BuyedSkins = new List<Skins>();
            data.BuyedSkins.Add(Skins.FirstSkin);
            data.TakedGifts = new List<int>();
            return data;
        }

        public Data Data { get; private set; }

        public void LevelComplete(int levelIndex) => Data.CompletedLevels.Add(levelIndex);
        public void OpenLocation(Locations location) => Data.BuyedLocations.Add(location);
        public void OpenSkin(Skins skin) => Data.BuyedSkins.Add(skin);
        public void UpdateMoney(int money) => Data.Money = money;

        private void Save()
        {
            string json = JsonUtility.ToJson(Data);
            File.WriteAllText(DataPath, json);
        }
    }
}