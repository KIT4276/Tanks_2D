using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks
{
    [RequireComponent (typeof(SpriteRenderer), typeof(KilledManager))]
    public class PlayerHealthComponent : HealthComponent
    {
        private bool _immortal;
        private Vector3 _startPoint;
        private SpriteRenderer _renderer;

        [SerializeField]
        private float _immortalTime = 3f;
        [SerializeField]
        private float _immortalFlashing = 0.2f;
        [SerializeField]
        private AudioSource _eexplosion;
        [SerializeField]
        private AudioSource _tbonushit;
        [SerializeField]
        private Sprite _explosion;
        [Space, SerializeField]
        private Text _lifesCountText;

        private void Start()
        {
            _startPoint = transform.position;
            _renderer = GetComponent<SpriteRenderer>();
            _health = (int)TransferSettings.PlayerLifes;
            _killedManager = GetComponent<KilledManager>();
            _lifesCountText.text = _health.ToString();
        }

        private IEnumerator OnImmortal()
        {
                _immortal = true;
                var time = _immortalTime;
                _tbonushit.Play();

                while (time > 0)
                {
                    _renderer.enabled = !_renderer.enabled;
                    time -= Time.deltaTime * 10;
                    yield return new WaitForSeconds(_immortalFlashing);
                }
                _renderer.enabled = true;
                _immortal = false;
                _tbonushit.Play();
        }

        public override void SetDamage(int damage)
        {
            if (_immortal) return;
            _health -= damage;
            _lifesCountText.text = _health.ToString();
            transform.position = _startPoint;
            StartCoroutine(OnImmortal());
            if (_health == 1) _lifesCountText.color = Color.red;
            if (_health <= 0)
            {
                _eexplosion.Play();
                var r = GetComponent<SpriteRenderer>();
                r.sprite = _explosion;
            }
        }

        public int GetPlayerHealth() => _health;
    }
}
