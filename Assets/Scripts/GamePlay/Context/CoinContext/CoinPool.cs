using Modules;
using UnityEngine;
using Zenject;

namespace GamePlay.CoinContext
{
    public sealed class CoinPool : MonoMemoryPool<Vector2Int, Coin>
    {
        protected override void Reinitialize(Vector2Int position, Coin coin)
        {
            coin.Generate();
            coin.Position = position;
        }
    }
}