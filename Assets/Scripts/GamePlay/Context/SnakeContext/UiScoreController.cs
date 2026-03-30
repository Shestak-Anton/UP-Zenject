using System;
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

        private int _score;

        [Inject]
        public UiScoreController(ICoinCollectionProvider coinCollectionProvider, IGameUI gameUI)
        {
            _coinCollectionProvider = coinCollectionProvider;
            _gameUI = gameUI;
        }

        void IInitializable.Initialize()
        {
            UpdateUi(_score);
            _coinCollectionProvider.OnCoinCollected += OnCoinCollected;
        }

        void IDisposable.Dispose()
        {
            _coinCollectionProvider.OnCoinCollected -= OnCoinCollected;
        }

        private void OnCoinCollected(ICoin coin)
        {
            _score += coin.Score;
            UpdateUi(_score);
        }

        private void UpdateUi(int score)
        {
            _gameUI.SetScore(score.ToString());
        }
    }
}