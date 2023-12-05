using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Money
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyText;
        
        private IMoneyBalanceHandler _moneyBalance;

        [Inject]
        public void Constructor(IMoneyBalanceHandler moneyBalanceHandler)
        {
            _moneyBalance = moneyBalanceHandler;
            _moneyBalance.OnMoneyChanged += OnMoneyChanged;
        }

        private void OnDestroy()
        {
            _moneyBalance.OnMoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(int money) => _moneyText.text = $"{money}";
    }
}