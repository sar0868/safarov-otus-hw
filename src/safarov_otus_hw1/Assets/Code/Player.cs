using UnityEngine;

namespace Code
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float Speed;
        [SerializeField] private float SpeedRotation;

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }


        private void Update()
        {
           MovingPlayerTransform();
        }

        private void MovingPlayerTransform()
        {
            float move = Input.GetAxis("Vertical");
            if (move > 0.0f)
            {
                _animator.SetBool("IsRunBack", false);
                _animator.SetBool("isRunForward", true);
            }
            else if (move < 0.0f)
            {
                _animator.SetBool("isRunForward", false);
                _animator.SetBool("IsRunBack", true);
            } else
            {
                _animator.SetBool("isRunForward", false);
                _animator.SetBool("IsRunBack", false);
            }
                float rotation = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * rotation * SpeedRotation * Time.deltaTime);
            transform.Translate(Vector3.forward * Speed * move * Time.deltaTime);
        }

    }
}
