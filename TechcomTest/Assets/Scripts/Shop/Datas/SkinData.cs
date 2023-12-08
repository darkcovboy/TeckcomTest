using PlayerData;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "SkinData", menuName = "Data/Skins")]
    public class SkinData : ShopData
    {
        [SerializeField] private Skins _skin;

        public Skins Skin => _skin;
    }
}