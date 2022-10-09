using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Tanks
{
    public class Menu : MonoBehaviour
    {
        [SerializeField]
        private InputAction _startGame;
        [SerializeField]
        private InputAction _onSettings;
        [SerializeField]
        private InputAction _exitGame;

        [Space,  SerializeField]
        private GameObject _mainMenu;
        [SerializeField]
        private GameObject _settingsMenu;

        [Space, SerializeField]
        private AudioSource _click;

        private void Awake()
        {
            _mainMenu.SetActive(true);
            _settingsMenu.SetActive(false);

            _startGame.Enable();
            _onSettings.Enable();
            _exitGame.Enable();
        }

        private void Update()
        {
            var startGame = _startGame.ReadValue<float>();
            var onSettings = _onSettings.ReadValue<float>();
            var exitGame = _exitGame.ReadValue<float>();
            if (startGame >= 1) StartGame();
            if (onSettings >= 1) OnSettings();
            if (exitGame >= 1) ExitGame();
        }

        public void StartGame()
        {
            _click.Play();
            SceneManager.LoadScene(1);
        }

        public void OnSettings()
        {
            _click.Play();
            _mainMenu.SetActive(false);
            _settingsMenu.SetActive(true);
        }

        public void ExitGame()
        {
            _click.Play();
            Application.Quit();
        }

        public void ReturnMenu()
        {
            _click.Play();
            _mainMenu.SetActive(true);
            _settingsMenu.SetActive(false);
        }

        private void OnDestroy()
        {
            _startGame.Dispose();
            _onSettings.Dispose();
            _exitGame.Dispose();
        }
    }
}
