using Game.Systems;
using GameContext;
using GamePlay.Context.SnakeContext;
using Modules;
using UnityEngine;
using Zenject;

namespace GamePlay.SnakeContext
{
    public sealed class SnakeContextInstaller : MonoInstaller
    {
        [SerializeField] private Snake _snake;

        public override void InstallBindings()
        {
            Container
                .Bind<ISnake>()
                .FromInstance(_snake)
                .AsSingle();
            Container
                .BindInterfacesTo<InputProvider>()
                .AsSingle();
            Container
                .BindInterfacesTo<UiGameOverController>()
                .AsSingle();
            Container
                .BindInterfacesTo<UiGameWinController>()
                .AsSingle();
            Container
                .BindInterfacesTo<InputObserver>()
                .AsSingle();
            Container
                .BindInterfacesTo<CollideBoundDetector>()
                .AsSingle();
            Container
                .BindInterfacesTo<CoinCollectionController>()
                .AsSingle();
            Container
                .BindInterfacesTo<SnakeGainerController>()
                .AsSingle();
            Container
                .BindInterfacesTo<SpeedController>()
                .AsSingle();
            Container
                .BindInterfacesTo<UiLevelController>()
                .AsSingle();
            Container
                .BindInterfacesTo<UiScoreController>()
                .AsSingle();
        }
    }
}