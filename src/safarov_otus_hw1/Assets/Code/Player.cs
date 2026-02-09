using UnityEngine;

namespace Code
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float Speed;
        [SerializeField] private float SpeedRotation;

        private void Update()
        {
           MovingPlayerTransform();
        }

        private void MovingPlayerTransform()
        {
            float vel = Input.GetAxis("Vertical");
            float rotation = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * rotation * SpeedRotation * Time.deltaTime);
            transform.Translate(Vector3.forward * Speed * vel * Time.deltaTime);
        }

    }
}
