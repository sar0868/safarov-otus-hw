using UnityEngine;

namespace Code.Service
{
    public sealed class EndZone : MonoBehaviour
    {
        private ZoneBehavior _zone;
        private void Awake()
        {
            _zone = transform.parent.GetComponent<ZoneBehavior>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Cargo"))
            {
                _zone.DestroyEnemy();
            }
        }
    }
}
