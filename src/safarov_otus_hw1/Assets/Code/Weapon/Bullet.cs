using System.Collections;
using UnityEngine;

namespace Code.Weapon
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody _rigidbody;
        private float _lifeBullet = 1f;
        private Collider _collider;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }


        public void Run(Vector3 path, Vector3 position)
        {
            transform.position = position;
            transform.parent = null;

            _rigidbody.AddForce(path * _speed, ForceMode.Impulse);
            StartCoroutine(LifeBullet());
        }
        private IEnumerator LifeBullet()
        {
            yield return new WaitForSeconds(_lifeBullet);
            Destroy(gameObject);
        }
    }
}

