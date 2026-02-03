using UnityEngine;

namespace Code
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float Speed;

        private Rigidbody _rigidbody;
        private int CountFirstAidKit = 0;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        //private void Update()
        //{
        //    float vel = Input.GetAxis("Vertical");
        //    transform.position += Vector3.forward * Speed * vel * Time.deltaTime;
        //    float rotation = Input.GetAxis("Horizontal");
        //    transform.position += Vector3.right * Speed * rotation * Time.deltaTime;
        //}

        private void FixedUpdate()
        {
            MovementPlayer();
        }

        private void MovementPlayer()
        {
            float moveV = Input.GetAxis("Vertical");
            float moveH = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(moveH, 0.0f, moveV);
            _rigidbody.AddForce(movement * Speed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("FirstAidKit"))
            {
                CountFirstAidKit++;
                Debug.Log($"Count first aid kit = {CountFirstAidKit}");

                Destroy(collision.gameObject);
            }
        }
    }
}

