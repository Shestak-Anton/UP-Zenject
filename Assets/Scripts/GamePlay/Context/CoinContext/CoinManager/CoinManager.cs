using System;
using System.Collections.Generic;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace GamePlay.CoinContext
{
    public sealed class CoinManager : ICoinManager, IInitializable
    {
        public event Action OnAllCoinsCollected;

        public int CoinsCount { get; private set;}

        private readonly IWorldBounds _bounds;
        private readonly IMemoryPool<Vector2Int, Coin> _coinPool;
        private readonly Dictionary<Vector2Int, Coin> _activeCoins = new();

        [Inject]
        public CoinManager(IWorldBounds bounds, IMemoryPool<Vector2Int, Coin> coinPool)
        {
            _bounds = bounds;
            _coinPool = coinPool;
        }

        void ICoinManager.SpawnRandomPosition() => SpawnRandomPositionInternal();

        bool ICoinManager.TryGetCoin(out Coin coin, Vector2Int position) =>
            _activeCoins.TryGetValue(position, out coin);

        void ICoinManager.RemoveCoin(Vector2Int position)
        {
            if (!_activeCoins.TryGetValue(position, out var coin)) return;
            _coinPool.Despawn(coin);
            _activeCoins.Remove(position);
            CoinsCount = _activeCoins.Count;
            if (CoinsCount == 0)
            {
                OnAllCoinsCollected?.Invoke();
            }
        }

        void IInitializable.Initialize() => SpawnRandomPositionInternal();


        private void SpawnRandomPositionInternal()
        {
            var randomPosition = _bounds.GetRandomPosition();
            while (_activeCoins.ContainsKey(randomPosition))
            {
                randomPosition = _bounds.GetRandomPosition();
            }
            
            var coin = _coinPool.Spawn(randomPosition);
            _activeCoins.Add(randomPosition, coin);
            CoinsCount = _activeCoins.Count;
        }
    }
}