using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "TicketData", menuName = "Data/Tickets")]
    public class ShopTicketData : ScriptableObject
    {
        public string Id;
        public string Name;
        public string Price;
        public Sprite Sprite;
        public int Money;
    }
}