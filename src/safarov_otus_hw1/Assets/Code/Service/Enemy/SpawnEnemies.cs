using UnityEngine;

namespace Code
{
    public sealed class SpawnEnemies : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Conditions _conditions;
        private Vector3 _positionSpawn;


        public void Spawn(Transform point, int countEnemy, PatrolRoute patrolRoute)
        {
            for (int i = 0; i < countEnemy; i++)
            {
                _positionSpawn = point.position;
                _positionSpawn = new Vector3(
                    _positionSpawn.x + Random.Range(0f, 4f),
                    _positionSpawn.y,
                    _positionSpawn.z + Random.Range(0f, 4f)
                );
                Enemy enemy = Instantiate(_enemyPrefab, _positionSpawn, Quaternion.identity);
                enemy.Init(patrolRoute, _conditions);
            }
        }

    }
}

