using System;
using UnityEngine;

namespace Code
{
    public sealed class StartSpawn : MonoBehaviour
    {
        public event Action<Transform, int> OnEnterTag;
        private Collider _collider;
        private string _tagSpawnEnemy = "SpawnEnemy";
        // private bool _isEnter = false;

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_tagSpawnEnemy))
            {
                // GameObject pointSpawn = other.transform.gameObject;
                // SpawnParameters parameters = pointSpawn.GetComponent<SpawnParameters>();
                // Params @params = parameters.GetParams();

                // // int count = other.transform.gameObject.GetComponent
                // OnEnterTag?.Invoke(@params.positionSpawnEnemy, @params.count);
            }
        }
    }

}
