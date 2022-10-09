using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(KilledManager))]
    public class HealthComponent : MonoBehaviour
    {
        protected int _health;
        protected KilledManager _killedManager;

        [SerializeField]
        private AudioSource _fexplosion;

        private void Awake()
           => _health = (int)TransferSettings.BotLifes;

        private void Start()
            => _killedManager = GetComponent<KilledManager>();

        public virtual void SetDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                var bot = GetComponent<BotMoveComponent>();
                _fexplosion.Play();
                _fexplosion.volume = TransferSettings.Volume;
                if (bot != null) _killedManager.EnemiesKilledCounter();
                Destroy(gameObject);
            }
        }
    }
}
