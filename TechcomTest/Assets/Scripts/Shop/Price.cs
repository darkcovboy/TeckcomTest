using TMPro;
using UnityEngine;

namespace Shop
{
    public class Price : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void UpdateText(int money)
        {
            _text.text = money.ToString();
        }
    }
}