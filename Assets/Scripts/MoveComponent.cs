using UnityEngine;

namespace Tanks
{
    public class MoveComponent : MonoBehaviour
    {
        private bool _balk;

        [SerializeField]
        private float _moveSpeed = 1f;
        [SerializeField]
        private AudioSource _nmoving;
        
        private static bool _canMove = true;

        public bool CanMove { get => _canMove; }

        public static void ChangeCanMove(bool value)
            => _canMove = value;

        public void OnMove(DirectionType type)
        {
            if (!_canMove) return;

            transform.position += type.ConvertTypeFromDirection() * (Time.deltaTime * _moveSpeed);
            transform.eulerAngles = type.ConvertTypeFromRotation();
            var player = GetComponent<PlayerHealthComponent>();
            if (player != null && _balk)
            {
                _nmoving.Play();
                _nmoving.volume = TransferSettings.Volume * 0.6f;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
            => _balk = true;

        private void OnCollisionExit2D(Collision2D collision)
            => _balk = false;
    }
}
