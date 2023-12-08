using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "Container", menuName = "Data/ShopContainer", order = 0)]
    public class ShopDataContainer : ScriptableObject
    {
        [SerializeField] private List<LocationData> _locationDatas;
        [SerializeField] private List<SkinData> _skinDatas;
        [SerializeField] private List<ShopTicketData> _shopTicketDatas;

        public List<LocationData> LocationDatas => _locationDatas;
        public List<SkinData> SkinDatas => _skinDatas;
        public List<ShopTicketData> ShopTicketDatas => _shopTicketDatas;
    }
}