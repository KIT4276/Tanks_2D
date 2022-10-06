using System.Collections;
using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(BotMoveComponent), typeof(FireComponent), typeof(HealthComponent))]
    public class Bot : MonoBehaviour
    {
        private FireComponent _fire;
        private SpriteRenderer _renderer;

        [SerializeField]
        private Sprite[] _sprites;
        [SerializeField]
        private float _reloadTime = 1f;


        private void Awake()
        {
            _fire = GetComponent<FireComponent>();
            _renderer = GetComponent<SpriteRenderer>();
        }
        private void Start()
        {
            GetRandomSprite();
            StartCoroutine(OnFireBot());
        }

        private void GetRandomSprite()
        {
            var sprite = Random.Range(0, _sprites.Length);
            _renderer.sprite = _sprites[sprite];
        }

        private IEnumerator OnFireBot()
        {
            while (true)
            {
                yield return new WaitForSeconds(_reloadTime);
                _fire.OnFire();
            }
        }
    }
}
