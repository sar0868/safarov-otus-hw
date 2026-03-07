using UnityEngine;

namespace Code
{
    public sealed class Rocket : Projectile
    {
        [SerializeField] private float _powerExplosion;
        [SerializeField] private float _scale;

        private Collider[] _collidedObjects;
        private const int CountCollidedObj = 128;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collidedObjects = new Collider[CountCollidedObj];
        }

        private void OnCollisionEnter(Collision collision)
        {
            var explosion = new GameObject().AddComponent<Explosion>();
            explosion.transform.position = transform.position;

            Destroy(gameObject);

            float radius = _scale * 0.5f;
            Vector3 center = collision.contacts[0].point;
            int countCollied = Physics.OverlapSphereNonAlloc(center, radius, _collidedObjects);

            for (int i = 0; i < countCollied; i++)
            {
                Collider colliderObject = _collidedObjects[i];
                if (colliderObject.TryGetComponent<HealthController>(out HealthController healthController))
                {
                    if (healthController.CanTakeDamage(healthController.MaxHp))
                    {
                        return;
                    }
                    if (healthController.TryGetComponent<Rigidbody>(out Rigidbody rigidbody) == false)
                    {
                        rigidbody = healthController.gameObject.AddComponent<Rigidbody>();
                    }
                    rigidbody.AddExplosionForce(_powerExplosion, center, radius);
                }
            }
        }

        public override void Run(Vector3 path, Vector3 position)
        {
            transform.position = position;
            transform.SetParent(null);
            gameObject.SetActive(true);
            _rigidbody.WakeUp();
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(path, ForceMode.Impulse);
            StartCoroutine(LifeBullet());
        }

        public override void Sleep()
        {
            _rigidbody.Sleep();
            _rigidbody.isKinematic = true;
            gameObject.SetActive(false);
        }
    }

}