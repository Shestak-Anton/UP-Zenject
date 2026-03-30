using System;

namespace GameContext.Level
{
    public sealed class LevelManager : ILevelManager
    {
        public event Action<int> OnLevelChanged;

        private int _currentLevel = 1;

        public void IncreateLevel()
        {
            _currentLevel++;
            OnLevelChanged?.Invoke(_currentLevel);
        }
    }
}