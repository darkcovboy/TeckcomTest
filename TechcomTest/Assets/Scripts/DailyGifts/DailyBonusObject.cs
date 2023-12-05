using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DailyGifts
{
    public class DailyBonusObject : MonoBehaviour, IPointerClickHandler
    {
        public event Action<DailyBonusObject> OnCLick; 
        
        [SerializeField] private TMP_Text _moneyText;
        [SerializeField] private TMP_Text _dayNumberText;
        [SerializeField] private Image _lockImage;
        [SerializeField] private Image _takedImage;

        public bool IsTaked { get; private set; }
        public bool CanTaked { get; private set; }
        public DailyBonusInfo DailyBonusInfo { get; private set; }
        public int Day { get; private set; }

        public void Render(DailyBonusInfo info, int day)
        {
            DailyBonusInfo = info;
            IsTaked = false;
            CanTaked = false;
            Day = day;
            _moneyText.text = $"X{DailyBonusInfo.Money}";
            _dayNumberText.text = $"Day{DailyBonusInfo.DayNumber}";
            _lockImage.gameObject.SetActive(!CanTaked);
            _takedImage.gameObject.SetActive(IsTaked);
        }

        public void CanTake()
        {
            CanTaked = true;
            _lockImage.gameObject.SetActive(!CanTaked);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Клик");
            OnCLick?.Invoke(this);
        }

        public void Take()
        {
            if (CanTaked)
            {
                IsTaked = true;
                CanTaked = false;
                _lockImage.gameObject.SetActive(CanTaked);
                _takedImage.gameObject.SetActive(IsTaked);
            }
        }
    }

    [System.Serializable]
    public class DailyBonusInfo
    {
        public int DayNumber;
        public int Money;
    }
}