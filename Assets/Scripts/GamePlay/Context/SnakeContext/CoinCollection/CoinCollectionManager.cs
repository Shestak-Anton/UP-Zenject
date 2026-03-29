using System;
using GamePlay.CoinContext;
using Modules;
using UnityEngine;
using Zenject;

namespace GamePlay.Context.SnakeContext
{
    public sealed class CoinCollectionController : IInitializable, IDisposable, ICoinCollectionProvider
    {
        public event Action<Coin> OnCoinCollected;

        private readonly ISnake _snake;
        private readonly ICoinManager _coinManager;

        [Inject]
        public CoinCollectionController(ISnake snake, ICoinManager coinManager)
        {
            _snake = snake;
            _coinManager = coinManager;
        }

        void IInitializable.Initialize()
        {
            _snake.OnMoved += OnHeadPositionChanged;
        }

        void IDisposable.Dispose()
        {
            _snake.OnMoved -= OnHeadPositionChanged;
        }

        private void OnHeadPositionChanged(Vector2Int headPosition)
        {
            if (!_coinManager.TryGetCoin(out var coin, headPosition)) return;
            OnCoinCollected?.Invoke(coin);
            _coinManager.RemoveCoin(headPosition);
        }
    }
}