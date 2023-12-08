using UnityEngine;

namespace Shop
{
    public class ShopData : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _price;
        [SerializeField] private string _name;
        [SerializeField] private int _levelNeed;

        public Sprite Icon => _icon;
        public int Price => _price;
        public string Name => _name;

        public int LevelNeed => _levelNeed;
    }
}