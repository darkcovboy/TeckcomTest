using System;

namespace Money
{
    public interface IMoneyBalanceHandler
    {
        event Action<int> OnMoneyChanged;
    }
}