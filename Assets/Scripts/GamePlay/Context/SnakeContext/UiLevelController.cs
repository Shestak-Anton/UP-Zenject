using System;
using GameContext.Config;
using GameContext.Level;
using SnakeGame;
using Zenject;

namespace GameContext
{
    public sealed class UiLevelController : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly ILevelChangedProvider _levelChangedProvider;
        private readonly GameConfig _gameConfig;

        [Inject]
        public UiLevelController(
            IGameUI gameUI,
            ILevelChangedProvider levelChangedProvider, 
            GameConfig gameConfig)
        {
            _gameUI = gameUI;
            _levelChangedProvider = levelChangedProvider;
            _gameConfig = gameConfig;
        }

        void IInitializable.Initialize()
        {
            OnLevelChanged(1);
            _levelChangedProvider.OnLevelChanged += OnLevelChanged;
        }

        void IDisposable.Dispose()
        {
            _levelChangedProvider.OnLevelChanged -= OnLevelChanged;
        }

        private void OnLevelChanged(int level)
        {
            _gameUI.SetDifficulty(current: level, max: _gameConfig.MaxLevelCount);
        }
    }
}