using UnityEngine;

namespace DailyGifts
{
    [CreateAssetMenu(fileName = "DailyBonusFabric", menuName = "DailyBonus/Fabric", order = 0)]
    public class DailyBonusFabric : ScriptableObject
    {
        [SerializeField] private DailyBonusObject _prefab;

        public DailyBonusObject Get(Transform container, DailyBonusInfo dailyBonusInfo, int day)
        {
            DailyBonusObject dailyBonusObject = Instantiate(_prefab, container);
            dailyBonusObject.Render(dailyBonusInfo, day);
            return dailyBonusObject;
        }
    }
}