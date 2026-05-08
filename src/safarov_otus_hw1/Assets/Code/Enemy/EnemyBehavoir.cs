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
            _enemySpawn.ReturnEnemy(this.gameObject);
            // gameObject.SetActive(false);
        }
    }
}

