using UnityEngine;

namespace Code
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed;
        // [SerializeField] private float speedH;
        [SerializeField] private Rigidbody _rigidbody;

        private void Update()
        {
            float vel = Input.GetAxis("Vertical");
            transform.position += Vector3.forward * speed * vel * Time.deltaTime;
            float rotation = Input.GetAxis("Horizontal");
            transform.position += Vector3.right * speed * rotation * Time.deltaTime;
  
            
        }

        private void FixedUpdate()
        {
            // float vel = Input.GetAxis("Vertical");
            // _rigidbody.linearVelocity = Vector3.forward * speed;
            // float rotation = Input.GetAxis("Horizontal");
            // _rigidbody.linearVelocity = Vector3.right * speed * rotation;
        }
    }
}

