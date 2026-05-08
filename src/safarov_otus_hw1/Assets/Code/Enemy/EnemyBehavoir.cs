using Code.Service;
using UnityEngine;

namespace Code.Enemy
{
    public sealed class EnemyBehavoir : MonoBehaviour
    {
        private EnemySpawn _enemySpawn;

        private void Start()
        {
            _enemySpawn = Object.FindFirstObjectByType<EnemySpawn>();
        }

        public void Died()
        {
            _enemySpawn.SpawnedEnemies--;
            gameObject.SetActive(false);
        }
    }
}

