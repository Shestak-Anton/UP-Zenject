using System;
using Game.Systems;
using Modules;
using UnityEngine;
using Zenject;

namespace GameContext
{
    public sealed class InputObserver : IInitializable, IDisposable
    {
        private readonly InputProvider _inputProvider;
        private readonly ISnake _snake;

        [Inject]
        public InputObserver(InputProvider inputProvider, ISnake snake)
        {
            _inputProvider = inputProvider;
            _snake = snake;
        }

        void IInitializable.Initialize()
        {
            _inputProvider.OnMove += OnDirectionChanged;
        }

        void IDisposable.Dispose()
        {
            _inputProvider.OnMove -= OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector2Int direction)
        {
            _snake.Turn(GetCurrentDirection(direction));
        }

        private static SnakeDirection GetCurrentDirection(Vector2Int input) => input switch
        {
            { x: 0, y: 1 } => SnakeDirection.UP,
            { x: 0, y: -1 } => SnakeDirection.DOWN,
            { x: -1, y: 0 } => SnakeDirection.LEFT,
            { x: 1, y: 0 } => SnakeDirection.RIGHT,
            _ => SnakeDirection.NONE
        };
    }
}