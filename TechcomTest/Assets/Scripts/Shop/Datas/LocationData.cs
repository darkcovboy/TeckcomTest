using PlayerData;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "LocationData", menuName = "Data/Locations")]
    public class LocationData : ShopData
    {
        [SerializeField] private Locations _location;

        public Locations Location => _location;
    }
}