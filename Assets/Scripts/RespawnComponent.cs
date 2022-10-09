using System.Collections;
using UnityEngine;

namespace Tanks
{
    public class RespawnComponent : MonoBehaviour
    {
        private int _botsCount;
        private int _maxNumberOfBots;

        [SerializeField]
        private float _delayRespawn = 7;
        [SerializeField]
        private Bot _botPrefab;
        [SerializeField]
        private Transform[] _respawnPoinrs;


        private void Start()
        {
            _maxNumberOfBots = (int)TransferSettings.BotsCount;
            StartCoroutine(Respawn());
        }

        private IEnumerator Respawn()
        {
            while (_botsCount <= (_maxNumberOfBots - 1))
            {
                var randomPointNumber = Random.Range(0, _respawnPoinrs.Length);
                var randomPoint = _respawnPoinrs[randomPointNumber];

                Instantiate(_botPrefab, randomPoint.position, randomPoint.rotation, this.transform);

                _botsCount++;
                yield return new WaitForSeconds(_delayRespawn);
            }
        }
    }
}
