using UnityEngine;

namespace Code.Service
{
    public sealed class StartZone : MonoBehaviour
    {
        private ZoneBehavior _zone;
        private bool _hasTrigger = false;
        private void Awake()
        {
            _zone = transform.parent.GetComponent<ZoneBehavior>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Cargo") && _hasTrigger == false)
            {
                _zone.SpawnEnemy();
                _hasTrigger = true;
            }
        }

    }
}

