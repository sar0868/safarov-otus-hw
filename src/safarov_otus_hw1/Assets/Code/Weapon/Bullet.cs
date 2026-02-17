using System.Collections;
using UnityEngine;

namespace Code
{
    [RequireComponent(typeof(Rigidbody))]
    internal class Bullet: MonoBehaviour
    {
        [SerializeField] private float _damage = 0.5f;
        [SerializeField] private float _force = 1.5f;
        [SerializeField] private float _liveBullet = 0.25f;

        public bool IsActive { get; private set; }

        private Rigidbody _rigidbody;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        public void Run(Vector3 path, Vector3 position)
        {
            transform.position = position;
            transform.parent = null;
            gameObject.SetActive(true);
            _rigidbody.WakeUp();
            _rigidbody.AddForce(path);
            IsActive = true;
            StartCoroutine(LiveBullet());

        }

        private IEnumerator LiveBullet()
        {
            yield return new WaitForSeconds(_liveBullet);
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