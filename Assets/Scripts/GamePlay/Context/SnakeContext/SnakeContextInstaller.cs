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
                .BindInterfacesAndSelfTo<InputProvider>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<UiGameOverController>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<UiGameWinController>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<InputObserver>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<CollideBoundDetector>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<CoinCollectionController>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<SnakeGainerController>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<SpeedController>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<UiLevelController>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<UiScoreController>()
                .AsSingle();
        }
    }
}