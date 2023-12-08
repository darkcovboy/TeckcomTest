using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Levels
{
    public class LevelsView : MonoBehaviour
    {
        [SerializeField] private List<LevelButton> _levelButtons;
        [SerializeField] private Button _exitButton;
        
        private LevelsPresenter _levelsPresenter;

        public void Constructor(LevelsPresenter levelsPresenter)
        {
            _levelsPresenter = levelsPresenter;
        }

        private void Start()
        {
            _levelsPresenter.SetupButtons(_levelButtons);
        }

        private void OnEnable() => _exitButton.onClick.AddListener(_levelsPresenter.ClosePanel);

        private void OnDisable() => _exitButton.onClick.RemoveListener(_levelsPresenter.ClosePanel);
    }
}