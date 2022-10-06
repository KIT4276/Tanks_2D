using UnityEngine;


namespace Tanks
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed = 1f;

        public void OnMove(DirectionType type)
        {
            transform.position += type.ConvertTypeFromDirection() * (Time.deltaTime * _moveSpeed);
            transform.eulerAngles = type.ConvertTypeFromRotation();
        }
    }
}
