using System;
using GamePlay.CoinContext;
using GamePlay.Context.SnakeContext;
using Modules;
using Zenject;

namespace GamePlay.Context.SnakeContext
{
    public sealed class SnakeGainerController : IInitializable, IDisposable
    {
        private readonly ICoinCollectionProvider _coinCollectionProvider;
        private readonly ISnake _snake;

        [Inject]
        public SnakeGainerController(ICoinCollectionProvider coinCollectionProvider, ISnake snake)
        {
            _coinCollectionProvider = coinCollectionProvider;
            _snake = snake;
        }

        void IInitializable.Initialize()
        {
            _coinCollectionProvider.OnCoinCollected += OnCoinCollected;
        }

        void IDisposable.Dispose()
        {
            _coinCollectionProvider.OnCoinCollected -= OnCoinCollected;
        }

        private void OnCoinCollected(Coin coin)
        {
            _snake.Expand(coin.Bones);
        }
    }
}