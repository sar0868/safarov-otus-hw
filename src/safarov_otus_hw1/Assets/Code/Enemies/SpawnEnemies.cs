using System.Collections.Generic;
using UnityEngine;

namespace Code.Enemies
{
    public sealed class SpawnEnemies : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        private Vector3 _positionSpawn;

        public void SpawnEnemy(Transform point, int count, Transform patrolRoute)
        {
            for (int i = 0; i < count; i++)
            {
                _positionSpawn = point.position;
                _positionSpawn = new Vector3(
                    _positionSpawn.x + Random.Range(0f, 3f),
                    _positionSpawn.y,
                    _positionSpawn.z + Random.Range(0f, 3f)
                );
                Enemy enemy = Instantiate(_enemyPrefab,
                _positionSpawn,
                Quaternion.identity);
                enemy.Init(patrolRoute);
            }
        }

    }
}


