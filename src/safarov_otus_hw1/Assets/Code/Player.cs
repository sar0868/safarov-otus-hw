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
            float moveV = Input.GetAxis("Vertical") * Speed;
            float moveH = Input.GetAxis("Horizontal") * SpeedRotation;

            Vector3 rotation = Vector3.up * moveH;
            Quaternion angleRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);

            Vector3 movement = new Vector3(0.0f, 0.0f, moveV);

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

