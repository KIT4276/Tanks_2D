﻿using UnityEngine;

namespace Tanks
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField]
        protected int _health = 3;

        public virtual void SetDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0) Destroy(gameObject);
        }
    }
}
