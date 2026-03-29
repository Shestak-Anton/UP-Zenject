using System;
using UnityEngine;

namespace Game.Systems
{
    public interface IInputProvider
    {
        event Action<Vector2Int> OnMove;
    }
}