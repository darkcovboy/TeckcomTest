using System;
using Zenject;

namespace Money
{
    public class MoneyCounter : IMoneyBalanceHandler, IInitializable
    {
        public event Action<int> OnMoneyChanged;
        
        private int _money;  
        
        public MoneyCounter(int startMoney)
        {
            Money = startMoney;
        }
    
        public int Money
        {
            get => _money;
            set
            {
                if(value < 0)
                    throw new ArgumentException(nameof(value));
                _money = value;
            }
        }

        public void AddMoney(int add)
        {
            if(add < 0)
                throw  new ArgumentException(nameof(add));

            Money += add;
            OnMoneyChanged?.Invoke(Money);
        }

        public void TakeMoney(int moneyToRemove)
        {
            if(moneyToRemove < 0)
                throw  new ArgumentException(nameof(moneyToRemove));

            Money -= moneyToRemove;
            OnMoneyChanged?.Invoke(Money);
        }

        public void Initialize()
        {
            OnMoneyChanged?.Invoke(Money);
        }
    }
}
