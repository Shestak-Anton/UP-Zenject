using System;
using Modules;
using SnakeGame;
using Zenject;

namespace GameContext
{
    public sealed class CollideBoundDetector : IFixedTickable, ICollideBoundDetector
    {
        public event Action OnCollideBound;

        private readonly ISnake _snake;
        private readonly IWorldBounds _worldBounds;

        [Inject]
        public CollideBoundDetector(ISnake snake, IWorldBounds worldBounds)
        {
            _snake = snake;
            _worldBounds = worldBounds;
        }

        void IFixedTickable.FixedTick()
        {
            if (_worldBounds.IsInBounds(_snake.HeadPosition)) return;
            OnCollideBound?.Invoke();
        }
    }
}