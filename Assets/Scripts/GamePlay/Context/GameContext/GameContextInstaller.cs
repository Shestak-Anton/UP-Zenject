using GameContext.Level;
using GamePlay.CoinContext;
using SampleGame;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace GameContext
{
    public sealed class GameContextInstaller : MonoInstaller
    {
        [SerializeField] private CoinContextInstaller _coinContextInstaller;
        [SerializeField] private GameUI _gameUi;
        [SerializeField] private WorldBounds _worldBounds;

        public override void InstallBindings()
        {
            Container
                .Install(_coinContextInstaller);
            
            Container
                .Bind<IGameUI>()
                .FromInstance(_gameUi)
                .AsSingle();
            Container
                .BindInterfacesTo<AllCoinsCollectedObserver>()
                .AsSingle();
            Container
                .Bind<IWorldBounds>()
                .FromInstance(_worldBounds)
                .AsSingle();
            Container
                .BindInterfacesTo<LevelManager>()
                .AsSingle();
            Container
                .BindInterfacesTo<CoinSpawnController>()
                .AsSingle();
        }
    }
}