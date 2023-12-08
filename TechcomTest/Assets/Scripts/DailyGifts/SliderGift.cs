using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DailyGifts
{
    public class SliderGift : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _text;

        private IGiftDayHandler _giftDayHandler;

        [Inject]
        public void Constructor(IGiftDayHandler giftDayHandler)
        {
            _giftDayHandler = giftDayHandler;
        }

        private void OnEnable()
        {
            _giftDayHandler.OnGiftTaked += OnGiftTaked;
        }
        
        private void OnDisable()
        {
            _giftDayHandler.OnGiftTaked -= OnGiftTaked;
        }

        private void OnGiftTaked(int day, int maxDay)
        {
            _slider.value = day;
            _slider.maxValue = maxDay;
            _text.text = $"{day}/{maxDay}";
        }
    }
}