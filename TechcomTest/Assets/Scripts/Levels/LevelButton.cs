using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Levels
{
    public class LevelButton : MonoBehaviour, IPointerClickHandler
    {
        public event Action<LevelButton> OnClick;
        
        [SerializeField] private TMP_Text _levelNumber;
        [SerializeField] private Image _lockImage;

        public bool IsLocked { get; private set; }
        public bool IsPassed { get; private set; }

        public void UpdateLevelNumber(int number)
        {
            _levelNumber.text = number.ToString();
        }

        public void Lock()
        {
            IsLocked = true;
            SetImage(IsLocked);
        }

        public void Unlock()
        {
            IsLocked = false;
            SetImage(IsLocked);
        }

        public void Passed(bool isPassed)
        {
            IsPassed = isPassed;
        }

        public void OnPointerClick(PointerEventData eventData) => OnClick?.Invoke(this);

        private void SetImage(bool isLocked)
        {
            _lockImage.gameObject.SetActive(isLocked);
            _levelNumber.gameObject.SetActive(!isLocked);
        }
    }
}