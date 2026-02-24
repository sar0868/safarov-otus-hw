using System.Collections;
using UnityEngine;

namespace Code
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] protected float _lifeBullet = 0.25f;
        protected Rigidbody _rigidbody;

        protected IEnumerator LifeBullet()
        {
            yield return new WaitForSeconds(_lifeBullet);
            Destroy(gameObject);
        }

        public abstract void Sleep();
        public abstract void Run(Vector3 path, Vector3 position);
    }
}