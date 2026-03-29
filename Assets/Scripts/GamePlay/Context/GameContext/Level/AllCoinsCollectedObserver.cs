using System;
using GamePlay.CoinContext;
using Zenject;

namespace GameContext.Level
{
    public sealed class AllCoinsCollectedObserver : IInitializable, IDisposable
    {
        private readonly ICoinCollectedProvider _coinCollectedProvider;
        private readonly ILevelManager _levelManager;

        [Inject]
        public AllCoinsCollectedObserver(ICoinCollectedProvider coinCollectedProvider, ILevelManager levelManager)
        {
            _coinCollectedProvider = coinCollectedProvider;
            _levelManager = levelManager;
        }

        void IInitializable.Initialize()
        {
            _coinCollectedProvider.OnAllCoinsCollected += AllCoinsCollected;
        }

        void IDisposable.Dispose()
        {
            _coinCollectedProvider.OnAllCoinsCollected -= AllCoinsCollected;
        }

        private void AllCoinsCollected() => _levelManager.IncreateLevel();
    }
}