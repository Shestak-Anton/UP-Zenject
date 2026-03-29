using System;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace GamePlay.CoinContext
{
    [Serializable]
    public sealed class CoinContextInstaller : Installer
    {
        [SerializeField] private Coin _prefab;
        [SerializeField] private WorldBounds _worldBounds;
        
        public override void InstallBindings()
        {
            Container
                .BindMemoryPoolCustomInterface<Coin, CoinPool, IMemoryPool<Vector2Int, Coin>>()
                .WithInitialSize(2)
                .WithMaxSize(9)
                .ExpandByOneAtATime()
                .FromComponentInNewPrefab(_prefab)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<CoinManager>()
                .AsSingle();
        }
    }
}