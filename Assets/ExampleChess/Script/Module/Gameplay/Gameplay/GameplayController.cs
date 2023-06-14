using UnityEngine;
using UnityEngine.UI;
using Framework.Boot;

namespace Example.Module.Gameplay
{
    public class GameplayController : Framework.Entity.Controller
    {
        [SerializeField]
        private GameObject _gameOverPanel;
        [SerializeField]
        private Button _retryButton;
        [SerializeField]
        private Button _hudMainMenuButton;
        [SerializeField]
        private Button _mainMenuButton;

        protected override void OnControllerStart()
        {
            base.OnControllerStart();
            Time.timeScale = 1;
            _retryButton.onClick.RemoveAllListeners();
            _retryButton.onClick.AddListener(OnRetry);
            _mainMenuButton.onClick.RemoveAllListeners();
            _mainMenuButton.onClick.AddListener(OnMainMenu);
            _hudMainMenuButton.onClick.RemoveAllListeners();
            _hudMainMenuButton.onClick.AddListener(OnMainMenu);
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            StartListening("GameOver", GameOver);
        }

        public void GameOver()
        {
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);
        }

        public void OnMainMenu()
        {
            SceneLoader.Instance.LoadScene("MainMenu");
        }

        public void OnRetry()
        {
            SceneLoader.Instance.ReloadScene();
        }

        private void OnDestroy()
        {
            StopListening("GameOver", GameOver);
        }
    }
}
