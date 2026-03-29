using System;
using Modules;

namespace GamePlay.Context.SnakeContext
{
    public interface ICoinCollectionProvider
    {
        event Action<Coin> OnCoinCollected;
    }
}