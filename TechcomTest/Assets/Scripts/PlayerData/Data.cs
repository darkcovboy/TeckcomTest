using System.Collections.Generic;

namespace PlayerData
{
    [System.Serializable]
    public class Data
    {
        public List<int> CompletedLevels;
        public List<int> TakedGifts;
        public int Money;
        public List<Skins> BuyedSkins;
        public List<Locations> BuyedLocations;
    }
}