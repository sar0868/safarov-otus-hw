using UnityEngine;

namespace Code
{
    public sealed class Rocket : Projectile
    {

        private Collider[] _collidedObjects;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
            _collidedObjects = new Collider[128];
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