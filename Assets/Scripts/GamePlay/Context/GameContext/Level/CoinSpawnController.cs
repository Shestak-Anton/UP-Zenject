using System;
using GamePlay.CoinContext;
using Zenject;

namespace GameContext.Level
{
    public sealed class CoinSpawnController : IInitializable, IDisposable
    {
        private readonly ILevelChangedProvider _levelChangedProvider;
        private readonly ICoinManager _coinManager;

        [Inject]
        public CoinSpawnController(ILevelManager levelChangedProvider, ICoinManager coinManager)
        {
            _levelChangedProvider = levelChangedProvider;
            _coinManager = coinManager;
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
            for (var i = 0; i < level; i++)
            {
                _coinManager.SpawnRandomPosition();
            }
        }
    }
}