using System;
using GameContext.Level;
using GamePlay.Context.SnakeContext;
using Modules;
using SnakeGame;
using Zenject;

namespace GameContext
{
    public sealed class UiScoreController : IInitializable, IDisposable
    {
        private readonly ICoinCollectionProvider _coinCollectionProvider;
        private readonly IGameUI _gameUI;

        private int Score;

        public UiScoreController(ICoinCollectionProvider coinCollectionProvider, IGameUI gameUI)
        {
            _coinCollectionProvider = coinCollectionProvider;
            _gameUI = gameUI;
        }

        void IInitializable.Initialize()
        {
            UpdateUi(Score);
            _coinCollectionProvider.OnCoinCollected += OnCoinCollected;
        }

        void IDisposable.Dispose()
        {
            _coinCollectionProvider.OnCoinCollected -= OnCoinCollected;
        }

        private void OnCoinCollected(ICoin coin)
        {
            Score += coin.Score;
            UpdateUi(Score);
        }

        private void UpdateUi(int score)
        {
            _gameUI.SetScore(score.ToString());
        }
    }

    public sealed class UiLevelController : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly ILevelChangedProvider _levelChangedProvider;

        [Inject]
        public UiLevelController(
            IGameUI gameUI,
            ILevelChangedProvider levelChangedProvider)
        {
            _gameUI = gameUI;
            _levelChangedProvider = levelChangedProvider;
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
            _gameUI.SetDifficulty(current: level, max: 9);
        }
    }
}