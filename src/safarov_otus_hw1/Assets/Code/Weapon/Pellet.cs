using UnityEngine;

namespace Code
{
    public sealed class Pellet : Projectile
    {
        [SerializeField] private float _damage = 0.5f;
        [SerializeField] private float _force = 1.5f;
        [SerializeField] private int _level = 1;
        [SerializeField] private PelletUpgradeData _pelletUpgradeData;

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
        }

        public float Scatter { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _pelletUpgradeData.TryGetDataLevel(_level, out PelletData data);
            Scatter = data.Scatter;
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

        public override void Run(Vector3 path, Vector3 position)
        {
            transform.position = position;
            transform.SetParent(null);
            Quaternion direction = GetDirection();
            _rigidbody.AddForce(direction * path, ForceMode.Impulse);
            StartCoroutine(LifeBullet());
        }

        private Quaternion GetDirection()
        {
            float spreadX = Random.Range(-Scatter, Scatter);
            float spreadY = Random.Range(-Scatter, Scatter);

            return Quaternion.Euler(spreadX, spreadY, 0);
        }

        public override void Sleep() { }
    }
}