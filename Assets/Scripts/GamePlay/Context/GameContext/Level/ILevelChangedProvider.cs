using System;

namespace GameContext.Level
{
    public interface ILevelChangedProvider
    {
        int CurrentLevel { get; }
        event Action<int> OnLevelChanged;
    }
}