using System.Collections;
using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(Bot))]
    public class BotMoveComponent : MoveComponent
    {
        private Bot _bot;
        private float _moveTime;
        private DirectionType _direction = DirectionType.Down;

        [SerializeField, Tooltip("Время движения бота в одном направлении")]
        private float _minMoveTime = 1;
        [SerializeField]
        private float _maxMoveTime = 5;

        private void Awake()
            => RandomDirectione();

        private void Start()
            => _bot = GetComponent<Bot>();

        private void Update()
        {
            OnMove(_direction);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var cell = collision.rigidbody.GetComponent<CellComponent>();
            var collisionFire = collision.rigidbody.GetComponent<FireComponent>();
            var thisBot = _bot.GetComponent<FireComponent>();

            if ((cell != null && !cell.DestroyCell) || 
                (thisBot != null && collisionFire != null && thisBot.GetSide() == collisionFire.GetSide()))
                RestartCoroutine();
        }

        private IEnumerator RandomDirectione()
        {
            while (true)
            {
                _direction = (DirectionType)Random.Range(1, 5);
                _moveTime = Random.Range(_minMoveTime, _maxMoveTime);
                yield return new WaitForSeconds(_moveTime);
            }
        }

        public void RestartCoroutine()
        {
            StopCoroutine(RandomDirectione());
            StartCoroutine(RandomDirectione());
        }
    }
}
