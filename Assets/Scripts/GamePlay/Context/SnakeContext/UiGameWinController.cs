using System;
using GameContext.Level;
using SnakeGame;
using Zenject;

namespace GameContext
{
    public sealed class UiGameWinController : IInitializable, IDisposable
    {
        private readonly ILevelChangedProvider _levelChangedProvider;
        private readonly IGameUI _gameUI;

        [Inject]
        public UiGameWinController(ILevelChangedProvider levelChangedProvider, IGameUI gameUI)
        {
            _levelChangedProvider = levelChangedProvider;
            _gameUI = gameUI;
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
            if (level <= 9) return;
            _gameUI.GameOver(true);
        }
    }
}