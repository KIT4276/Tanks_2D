using UnityEngine;
using UnityEngine.UI;

namespace Tanks
{
    public class Settings : MonoBehaviour
    {
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

        private float _volume;
        private float _playerLifes;
        private float _botLifes;
        private float _botsCount;

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
    }
}
