using UnityEngine;

namespace Tanks
{
    public class KilledManager : MonoBehaviour
    {
        private static int _enemiesKilled;

        public int EnemiesKilled { get => _enemiesKilled; }

        public void EnemiesKilledCounter()
        {
            _enemiesKilled++;
        }
    }
}
