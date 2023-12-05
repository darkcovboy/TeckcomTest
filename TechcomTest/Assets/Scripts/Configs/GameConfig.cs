using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Config", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [SerializeField, Min(1)] private int _startMoney;

        public int StartMoney => _startMoney;
    }
}