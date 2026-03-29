using System;

namespace GameContext
{
    public interface ICollideBoundDetector
    {
        event Action OnCollideBound;
    }
}