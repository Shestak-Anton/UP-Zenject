using System;

namespace GameContext.Level
{
    public sealed class LevelManager : ILevelManager
    {
        public event Action<int> OnLevelChanged;

        public int CurrentLevel { get; private set; } = 1;

        public void IncreateLevel()
        {
            CurrentLevel++;
            OnLevelChanged?.Invoke(CurrentLevel);
        }
    }
}