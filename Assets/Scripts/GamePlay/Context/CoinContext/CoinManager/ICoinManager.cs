using Modules;
using UnityEngine;

namespace GamePlay.CoinContext
{
    public interface ICoinManager : ICoinCollectedProvider
    {
        void SpawnRandomPosition();
        bool TryGetCoin(out Coin coin, Vector2Int position);
        void RemoveCoin(Vector2Int position);
    }
}