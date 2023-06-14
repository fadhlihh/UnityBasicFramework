using UnityEngine;
using UnityEngine.UI;
using Framework.Boot;

namespace Example.Gameplay
{
    public class MainMenuUIController : MonoBehaviour
    {
        [SerializeField]
        private Button _playGameButton;
        [SerializeField]
        private Button _exitGameButton;

        private void Awake()
        {
            _playGameButton.onClick.RemoveAllListeners();
            _playGameButton.onClick.AddListener(OnPlayGame);
            _exitGameButton.onClick.RemoveAllListeners();
            _exitGameButton.onClick.AddListener(OnExit);
        }

        private void OnPlayGame()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }

        private void OnExit()
        {
            Application.Quit();
        }
    }
}
