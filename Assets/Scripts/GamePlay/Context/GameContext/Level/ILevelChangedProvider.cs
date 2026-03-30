using System;

namespace GameContext.Level
{
    public interface ILevelChangedProvider
    {
        event Action<int> OnLevelChanged;
    }
}