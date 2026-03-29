using System;
using UnityEngine;
using Zenject;

namespace Game.Systems
{
    public sealed class InputProvider : IInputProvider, ITickable
    {
        public event Action<Vector2Int> OnMove;

        void ITickable.Tick()
        {
            var dx = Input.GetAxisRaw("Horizontal");
            var dy = Input.GetAxisRaw("Vertical");
            OnMove?.Invoke(new Vector2Int(Mathf.RoundToInt(dx), Mathf.RoundToInt(dy)));
        }
    }
}