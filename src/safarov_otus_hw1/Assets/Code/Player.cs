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
            Vector2 _getInput = GetInput();
            

            transform.Rotate( _getInput.y * SpeedRotation * Time.deltaTime * Vector3.up);
            transform.Translate( Speed * _getInput.x * Time.deltaTime * Vector3.forward);
        }

        private void FixedUpdate()
        {
            MovementPlayer();
        }

        private void MovementPlayer()
        {
            Vector2 _getInput = GetInput();


            Vector3 rotation = _getInput.y *SpeedRotation * Vector3.up;
            Quaternion angleRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);

            _rigidbody.MovePosition(transform.position +  _getInput.x * Speed * Time.fixedDeltaTime * transform.forward);
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

        private Vector2 GetInput()
        {
            float vel = Input.GetAxis("Vertical");
            float rotation = Input.GetAxis("Horizontal");
            return new Vector2(vel, rotation);
        }
    }
}

