using System;

namespace DailyGifts
{
    public interface IGiftDayHandler
    {
        event Action<int, int> OnGiftTaked;
    }
}