using System.Collections.Generic;
using UnityEngine;

namespace DailyGifts
{
    [CreateAssetMenu(fileName = "container", menuName = "DailyBonus/Container", order = 0)]
    public class DailyBonusInfoContainer : ScriptableObject
    {
        [SerializeField] private List<DailyBonusInfo> _dailyBonusInfos;
        [SerializeField] private DailyBonusInfo _dailyBonusLastDay;

        public IReadOnlyCollection<DailyBonusInfo> DailyBonusInfos => _dailyBonusInfos;
        public DailyBonusInfo DailyBonusInfoLast => _dailyBonusLastDay;
    }
}