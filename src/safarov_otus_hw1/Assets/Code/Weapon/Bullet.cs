using System.Collections;
using UnityEngine;

namespace Code
{
    [RequireComponent(typeof(Rigidbody))]
    internal class Bullet: MonoBehaviour
    {
        [SerializeField] private float _damage = 0.5f;
        [SerializeField] private float _force = 1.5f;
        [SerializeField] private float _lifeBullet = 0.25f;

        public bool IsActive { get; private set; }
        public float Force
        {
            get
            {
                if (_force <= 0)
                {
                    return 0.0f;
                }
                return _force;
            }

            set
            {
                if (IsActive == false)
                {
                    _force = 0.0f;
                    return;
                }
                _force = value;
            }
        }

        private Rigidbody _rigidbody;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent<HealthController>(out HealthController health))
            {
                Destroy(gameObject);
                if (health.CanTakeDamage(_damage))
                {
                    return;
                }

                if (collision.collider.TryGetComponent<Rigidbody>(out Rigidbody rigidbody) == false)
                {
                    rigidbody = collision.gameObject.AddComponent<Rigidbody>();
                }

                rigidbody.AddForce(_rigidbody.linearVelocity * Force, ForceMode.Impulse);
            }
        }

        public void Run(Vector3 path, Vector3 position)
        {
            transform.position = position;
            transform.parent = null;
            gameObject.SetActive(true);
            _rigidbody.WakeUp();
            _rigidbody.AddForce(path);
            IsActive = true;
            StartCoroutine(LifeBullet());

        }

        private IEnumerator LifeBullet()
        {
            yield return new WaitForSeconds(_lifeBullet);
            Destroy(gameObject);
        }

        public void Sleep()
        {
            _rigidbody.Sleep();
            gameObject.SetActive(false);
            IsActive = false;
        }
    }
}