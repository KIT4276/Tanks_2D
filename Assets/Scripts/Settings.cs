using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Tanks
{
    public class Settings : MonoBehaviour
    {
        private Slider _activeSlider;
        private float _volume;
        private float _playerLifes;
        private float _botLifes;
        private float _botsCount;

        [SerializeField]
        private Slider _volumeSlider;
        [SerializeField]
        private Slider _playerLifesSlider;
        [SerializeField]
        private Slider _botLifesSlider;
        [SerializeField]
        private Slider _botsCountSlider;

        [Space, SerializeField]
        private Text _volumeText;
        [SerializeField]
        private Text _playerLifesText;
        [SerializeField]
        private Text _botLifesText;
        [SerializeField]
        private Text _botsCountText;
        [SerializeField]
        private Menu _menu;

        [Space, SerializeField]
        private InputAction _comeBack;
        [SerializeField]
        private InputAction _activeVolumeSlider;
        [ SerializeField]
        private InputAction _activePlayerLifesSlider;
        [SerializeField]
        private InputAction _activeBotLifesSlider;
        [SerializeField]
        private InputAction _activeBotsCountSlider;

        [Space, SerializeField]
        private InputAction _add;
        [SerializeField]
        private InputAction _down;

        private void Start()
        {
            _comeBack.Enable();

            _activeVolumeSlider.Enable();
            _activePlayerLifesSlider.Enable();
            _activeBotLifesSlider.Enable();
            _activeBotsCountSlider.Enable();

            _add.Enable();
            _down.Enable();
        }

        private void Update()
        {
            if (_comeBack.ReadValue<float>() >= 1) _menu.ReturnMenu();

            if (_activeVolumeSlider.ReadValue<float>() >= 1) _activeSlider = _volumeSlider;
            if (_activePlayerLifesSlider.ReadValue<float>() >= 1) _activeSlider = _playerLifesSlider;
            if (_activeBotLifesSlider.ReadValue<float>() >= 1) _activeSlider = _botLifesSlider;
            if (_activeBotsCountSlider.ReadValue<float>() >= 1) _activeSlider = _botsCountSlider;

            if (_add.ReadValue<float>() >= 1) AddVariable();
            if (_down.ReadValue<float>() >= 1) DownVariable();
        }

        private void AddVariable()
            => _activeSlider.value++;

        private void DownVariable()
            => _activeSlider.value--;

        public void SetVolume()
        {
            _volume = _volumeSlider.value;
            TransferSettings.Volume = _volume;
            _volumeText.text = _volume.ToString();
        }

        public void SetPlayerLifes()
        {
            _playerLifes = _playerLifesSlider.value;
            TransferSettings.PlayerLifes = _playerLifes;
            _playerLifesText.text = _playerLifes.ToString();
        }

        public void SetBotLifes()
        {
            _botLifes = _botLifesSlider.value;
            TransferSettings.BotLifes = _botLifes;
            _botLifesText.text = _botLifes.ToString();
        }

        public void SetBotsCount()
        {
            _botsCount = _botsCountSlider.value;
            TransferSettings.BotsCount = _botsCount;
            _botsCountText.text = _botsCount.ToString();
        }

        private void OnDestroy()
        {
            _comeBack.Dispose();

            _activeVolumeSlider.Dispose();
            _activePlayerLifesSlider.Dispose();
            _activeBotLifesSlider.Dispose();
            _activeBotsCountSlider.Dispose();

            _add.Dispose();
            _down.Dispose();
        }
    }
}
