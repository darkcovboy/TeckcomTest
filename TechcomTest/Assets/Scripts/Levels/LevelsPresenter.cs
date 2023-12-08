using System.Collections.Generic;
using MainMenu;
using PlayerData;

namespace Levels
{
    public class LevelsPresenter : ICloseble
    {
        private LevelsView _levelsView;
        private PlayerSavedData _playerSaveData;
        private List<LevelButton> _levelButtons;
        private Panels _panel;

        public LevelsPresenter(LevelsView levelsView, PlayerSavedData playerSavedData)
        {
            _levelsView = levelsView;
            _playerSaveData = playerSavedData;
            _levelsView.Constructor(this);
            _panel = Panels.Play;
        }

        public void SetupButtons(List<LevelButton> levelButtons)
        {
            int index = 0;
            _levelButtons = levelButtons;
            
            foreach (var level in _levelButtons)
            {
                index++;
                level.OnClick += OnClick;
                level.UpdateLevelNumber(index);
                level.Lock();
                level.Passed(false);
            }

            for (int i = 0; i < _playerSaveData.Data.CompletedLevels.Count; i++)
            {
                _levelButtons[i].Unlock();
            }
        }

        private void OnClick(LevelButton levelButton)
        {
            if(levelButton.IsLocked || (_playerSaveData.Data.CompletedLevels.Count + 1) > _levelButtons.Count || levelButton.IsPassed)
                return;
            
            _levelButtons[_playerSaveData.Data.CompletedLevels.Count].Unlock();
            levelButton.Passed(true);
            _playerSaveData.LevelComplete((_playerSaveData.Data.CompletedLevels.Count+ 1));
        }

        public Panels GetPanelType() => _panel;

        public void OpenPanel() => _levelsView.gameObject.SetActive(true);

        public void ClosePanel() => _levelsView.gameObject.SetActive(false);
    }
}