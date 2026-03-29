using System;
using GameContext.Level;
using Modules;
using Zenject;

namespace GamePlay.Context.SnakeContext
{
    public sealed class SpeedController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly ILevelChangedProvider _levelChangedProvider;

        [Inject]
        public SpeedController(ISnake snake, ILevelChangedProvider levelChangedProvider)
        {
            _snake = snake;
            _levelChangedProvider = levelChangedProvider;
        }

        void IInitializable.Initialize()
        {
            _levelChangedProvider.OnLevelChanged += OnLevelChanged;
        }

        void IDisposable.Dispose()
        {
            _levelChangedProvider.OnLevelChanged -= OnLevelChanged;
        }

        private void OnLevelChanged(int level)
        {
            _snake.SetSpeed(level);
        }
    }
}