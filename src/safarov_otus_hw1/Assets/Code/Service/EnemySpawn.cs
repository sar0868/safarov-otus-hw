using System.Collections;

using Code.Enemy;
using UnityEngine;
using UnityEngine.Pool;

namespace Code.Service
{
    public sealed class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private int _countEnemies = 100;
        [SerializeField] private int _limitEnemies = 10;
        [SerializeField] private EnemiesPoint _enemiesPoint;
        [SerializeField] private float _minTime = 1f;
        [SerializeField] private float _maxTime = 3f;

        private IObjectPool<GameObject> _pool;

        private int _spawnedEnemies = 0;

        public int SpawnedEnemies { get => _spawnedEnemies; set => _spawnedEnemies = value; }

        private void Awake()
        {
            _pool = new ObjectPool<GameObject>(
                createFunc: () => Instantiate(_enemyPrefab),
                actionOnGet: (obj) => obj.SetActive(true),
                actionOnRelease: (obj) => obj.SetActive(false),
                actionOnDestroy: (obj) => Destroy(obj),
                collectionCheck: false,
                defaultCapacity: _limitEnemies,
                maxSize: _countEnemies
            );
        }

        private void Start()
        {
            StartCoroutine(StartWave());
        }

        private void SpawnEenemy(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Vector3 position = new Vector3(
                    _enemiesPoint.transform.position.x + Random.Range(0f, 10f),
                    _enemyPrefab.transform.position.y,
                    _enemiesPoint.transform.position.z + Random.Range(0f, 10f)
                );
                GameObject enemy = _pool.Get();
                enemy.transform.position = position;
                // Instantiate(_enemyPrefab, position, Quaternion.identity);
                SpawnedEnemies++;
            }
        }

        public void ReturnEnemy(GameObject enemy)
        {
            _pool.Release(enemy);
        }

        private bool TryCheckCountEnemy(out int count)
        {
            count = SpawnedEnemies;
            return count <= _limitEnemies;
        }

        private IEnumerator StartWave()
        {
            while (_countEnemies > 0)
            {
                float waitTime = Random.Range(_minTime, _maxTime);
                yield return new WaitForSeconds(waitTime);
                if (TryCheckCountEnemy(out int enemies))
                {
                    int count = _limitEnemies - enemies;
                    _countEnemies -= count;
                    SpawnEenemy(count);
                }
            }
        }
    }

}

