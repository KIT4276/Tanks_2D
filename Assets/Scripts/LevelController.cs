using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(KilledManager))]
    public class LevelController : MonoBehaviour
    {
        private KilledManager _killedManager;

        [SerializeField]
        private GameObject _victoryImage;
        [SerializeField]
        private GameObject _gameOverImage;
        [SerializeField]
        private PlayerHealthComponent _player1;

        private void Start()
            => _killedManager = GetComponent<KilledManager>();

        private void Update()
        {
            var botsCount = TransferSettings.BotsCount;
            var enemiesKilled = _killedManager.EnemiesKilled;
            if (enemiesKilled >= botsCount) Victory();
            if (_player1.GetPlayerHealth() <= 0) GameOver();
        }

        private void Victory()
            => _victoryImage.SetActive(true);

        private void GameOver()
        {
            _gameOverImage.SetActive(true);
            MoveComponent.ChangeCanMove(false);
        }
    }
}
