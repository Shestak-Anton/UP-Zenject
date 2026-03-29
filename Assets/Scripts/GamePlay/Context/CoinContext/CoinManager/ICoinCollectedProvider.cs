using System;

namespace GamePlay.CoinContext
{
    public interface ICoinCollectedProvider
    {
        int CoinsCount { get; }
        event Action OnAllCoinsCollected;
    }
}