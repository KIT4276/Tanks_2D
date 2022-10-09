using UnityEngine;
using UnityEngine.InputSystem;

namespace Tanks
{
    [RequireComponent(typeof(MoveComponent), typeof(FireComponent))]
    public class InputComponent : MonoBehaviour
    {
        private MoveComponent _moveComponent;
        private FireComponent _fireComponent;
        private DirectionType _lastType;

        [SerializeField]
        private InputAction _move;
        [SerializeField]
        private InputAction _fire;
        [SerializeField]
        private AudioSource _movingSound;

        private void Start()
        {
            _moveComponent = GetComponent<MoveComponent>();
            _fireComponent = GetComponent<FireComponent>();

            _move.Enable();
            _fire.Enable();
        }

        private void Update()
        {
            var fire = _fire.ReadValue<float>();
            if (fire == 1f) _fireComponent.OnFire();

            var direction = _move.ReadValue<Vector2>();
            DirectionType type;
            if (direction.x != 0f && direction.y != 0f)
            {
                type = _lastType;
            }
            else if (direction.x == 0f && direction.y == 0f) return;
            else type = _lastType = direction.ConvertDirectionFromType();

            _movingSound.Play();
            _movingSound.volume = TransferSettings.Volume/2;
            _moveComponent.OnMove(type);
        }

        private void OnDestroy()
        {
            _move.Dispose();
            _fire.Dispose();
        }
    }
}
