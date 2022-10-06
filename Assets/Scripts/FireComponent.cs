using System.Collections;
using UnityEngine;

namespace Tanks
{
    public class FireComponent : MonoBehaviour
    {
        private bool _canFire = true;

        [SerializeField, Range(0.1f, 1f)]
        private float _delayFire = 0.25f;
        [SerializeField]
        private Projectile _prefabProjectile;
        [SerializeField]
        private SideType _side;

        public SideType GetSide() => _side;

        private IEnumerator OnFireDelay()
        {
            _canFire = false;
            yield return new WaitForSeconds(_delayFire);
            _canFire = true;
        }

        public void OnFire()
        {
            if (!_canFire) return;

            var bullet = Instantiate(_prefabProjectile, transform.position, transform.rotation);
            bullet.SetParams(transform.eulerAngles.ConvertRotationFromType(), _side);

            StartCoroutine(OnFireDelay());
        }
    }
}
