using System;
using GameContext.Config;
using GameContext.Level;
using SnakeGame;
using Zenject;

namespace GameContext
{
    public sealed class UiGameWinController : IInitializable, IDisposable
    {
        private readonly ILevelChangedProvider _levelChangedProvider;
        private readonly IGameUI _gameUI;
        private readonly GameConfig _gameConfig;

        [Inject]
        public UiGameWinController(ILevelChangedProvider levelChangedProvider, IGameUI gameUI, GameConfig gameConfig)
        {
            _levelChangedProvider = levelChangedProvider;
            _gameUI = gameUI;
            _gameConfig = gameConfig;
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
            if (level <= _gameConfig.MaxLevelCount) return;
            _gameUI.GameOver(true);
        }
    }
}