using UnityEngine;

namespace Code.Character
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }


        public void Run(Vector3 path, Vector3 position)
        {
            transform.position = position;
            transform.parent = null;
            gameObject.SetActive(true);
            _rb.WakeUp();
            _rb.AddForce(path, ForceMode.Impulse);
        }

        public void Sleep()
        {
            _rb.Sleep();
            gameObject.SetActive(false);
        }
    }
}
