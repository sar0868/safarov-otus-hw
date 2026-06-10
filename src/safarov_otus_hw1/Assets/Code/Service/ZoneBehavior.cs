using System.Collections.Generic;
using Code.Enemy;
using UnityEngine;

namespace Code.Service
{
    public sealed class ZoneBehavior : MonoBehaviour
    {
        [SerializeField] private int _countEnemy;
        [SerializeField] private SpawnEnemies _spawnEnemies;
        [SerializeField] private Transform _patrolRoute;
        private Transform _pointSpawn1;
        private Transform _pointSpawn2;

        private void Awake()
        {
            _pointSpawn1 = transform.Find("PointSpawn1");
            _pointSpawn2 = transform.Find("PointSpawn2");
        }

        public void SpawnEnemy()
        {
            _spawnEnemies.SpawnEnemy(_pointSpawn1, _countEnemy, _patrolRoute);
            _spawnEnemies.SpawnEnemy(_pointSpawn2, _countEnemy, _patrolRoute);
        }

        public void DestroyEnemy()
        {
            Enemy.Enemy[] enemies = FindObjectsByType<Enemy.Enemy>(FindObjectsSortMode.None);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].ReactToHit();
            }
        }
    }
}

