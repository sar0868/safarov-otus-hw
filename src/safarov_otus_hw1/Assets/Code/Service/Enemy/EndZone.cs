using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public sealed class EndZone : MonoBehaviour
    {
        private List<Enemy> _enemies;
        private Collider _collider;
        private string _tagPlayer = "Player";
        private bool _isEnter = false;


        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        public void CreateListEnemy(List<Enemy> enemies)
        {
            _enemies = enemies;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isEnter == false && other.CompareTag(_tagPlayer))
            {
                _isEnter = true;
                RemoveEnemies();
            }
        }

        private void RemoveEnemies()
        {
            if (_enemies != null)
            {
                foreach (Enemy enemy in _enemies)
                {
                    enemy.DeactivateEnemy();
                }
            }
        }
    }
}

