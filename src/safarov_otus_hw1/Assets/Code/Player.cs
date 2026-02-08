using UnityEngine;

namespace Code
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float Speed;
        [SerializeField] private float SpeedRotation;

        private Rigidbody _rigidbody;
        private int CountFirstAidKit = 0;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        //private void Update()
        //{
        //    MovingPlayerTransform();
        //}

        private void MovingPlayerTransform()
        {
            float vel = Input.GetAxis("Vertical");
            float rotation = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * rotation * SpeedRotation * Time.deltaTime);
            transform.Translate(Vector3.forward * Speed * vel * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            MovementPlayer();
        }

        private void MovementPlayer()
        {
            float moveV = Input.GetAxis("Vertical") * Speed;
            float moveH = Input.GetAxis("Horizontal") * SpeedRotation;

            Vector3 rotation = Vector3.up * moveH;
            Quaternion angleRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);

            _rigidbody.MovePosition(transform.position + transform.forward * moveV * Time.fixedDeltaTime);
            _rigidbody.MoveRotation(_rigidbody.rotation * angleRotation);
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

