using System;
using Modules;
using SnakeGame;
using Zenject;

namespace GameContext
{
    public sealed class UiGameOverController : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly ISnake _snake;
        private readonly ICollideBoundDetector _boundDetector;

        [Inject]
        public UiGameOverController(IGameUI gameUI, ISnake snake, ICollideBoundDetector boundDetector)
        {
            _gameUI = gameUI;
            _snake = snake;
            _boundDetector = boundDetector;
        }

        void IInitializable.Initialize()
        {
            _snake.OnSelfCollided += ShowGameOverScreen;
            _boundDetector.OnCollideBound += ShowGameOverScreen;
        }

        void IDisposable.Dispose()
        {
            _snake.OnSelfCollided -= ShowGameOverScreen;
            _boundDetector.OnCollideBound -= ShowGameOverScreen;
        }

        private void ShowGameOverScreen()
        {
            _gameUI.GameOver(false);
        }
    }
}