using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "factory", menuName = "Shop/Factory", order = 0)]
    public class ShopFactory : ScriptableObject
    {
        [SerializeField] private ShopObject _shopObjectPrefab;
        [SerializeField] private ShopTicketObject _shopTicketObjectPrefab;

        public ShopObject Get(ShopData shopData, Transform container)
        {
            ShopObject shopObject = Instantiate(_shopObjectPrefab, container);
            shopObject.Render(shopData);
            return shopObject;
        }

        public ShopTicketObject Get(ShopTicketData data, Transform container)
        {
            ShopTicketObject shopTickedObject = Instantiate(_shopTicketObjectPrefab, container);
            _shopTicketObjectPrefab.Render(data);
            return shopTickedObject;
        }
    }
}