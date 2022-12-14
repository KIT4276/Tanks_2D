using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(MoveComponent))]
    public class Projectile : MonoBehaviour
    {
        private DirectionType _direction;
        private SideType _side;
        private MoveComponent _moveComponent;

        [SerializeField]
        private int _damage = 1;
        [SerializeField]
        private float _lifeTime = 3f;

        private void Start()
        {
            _moveComponent = GetComponent<MoveComponent>();
            Destroy(gameObject, _lifeTime);
        }

        private void Update()
            => _moveComponent.OnMove(_direction);

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var bot = collision.GetComponent<Bot>();
            var fire = collision.GetComponent<FireComponent>();
            if(fire != null)
            {
                if (fire.GetSide() == _side) return;

                var condition = fire.GetComponent<HealthComponent>();
                condition.SetDamage(_damage);
                if (bot != null) bot.GetComponent<BotMoveComponent>().RestartCoroutine();
                Destroy(gameObject);
                return;
            }

            var cell = collision.GetComponent<CellComponent>();
            if (cell != null)
            {
                if (cell.DestroyProjectile) Destroy(gameObject);
                if (cell.DestroyCell) Destroy(cell.gameObject);
                return;
            }
        }

        public void SetParams(DirectionType direction, SideType side)
            => (_direction, _side) = (direction, side);
    }
}
