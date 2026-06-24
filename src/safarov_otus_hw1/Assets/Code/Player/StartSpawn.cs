using System;
using UnityEngine;

namespace Code
{
    public sealed class StartSpawn : MonoBehaviour
    {
        public event Action<Transform, int, PatrolRoute> OnEnterTag;
        private Collider _collider;
        private string _tagSpawnEnemy = "SpawnEnemy";
        private bool _isEnter = false;

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isEnter == false && other.CompareTag(_tagSpawnEnemy))
            {
                _isEnter = true;
                GameObject pointSpawn = other.transform.gameObject;
                SpawnParameters parameters = pointSpawn.GetComponent<SpawnParameters>();
                Transform position = parameters.positionSpawnEnemy;
                int count = parameters.count;
                PatrolRoute patrolRoute = parameters.patrolRoute;

                OnEnterTag?.Invoke(position, count, patrolRoute);
            }
        }
    }

}
