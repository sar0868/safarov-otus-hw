using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public sealed class StartSpawn : MonoBehaviour
    {
        [SerializeField] private Transform _positionSpawnEnemy;
        [SerializeField] private int _countEnemy;
        [SerializeField] private PatrolRoute _patrolRoute;
        [SerializeField] private SpawnEnemies _spawnEnemies;
        [SerializeField] private EndZone _endZone;

        private Collider _collider;
        private string _tagPlayer = "Player";
        private bool _isEnter = false;
        private List<Enemy> _enemies;

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isEnter == false && other.CompareTag(_tagPlayer))
            {
                _isEnter = true;
                _spawnEnemies.Spawn(_positionSpawnEnemy, _countEnemy, _patrolRoute, out _enemies);
                if (_enemies != null)
                {
                    _endZone.CreateListEnemy(_enemies);
                }
            }
        }
    }
}
