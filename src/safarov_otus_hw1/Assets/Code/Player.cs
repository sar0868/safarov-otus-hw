using UnityEngine;

namespace Code
{
    public class Player : MonoBehaviour
    {
        public float speedV;
        public float speedH;

        void Update()
        {
            transform.position += Vector3.forward * speedV * Time.deltaTime;
            float rotation = Input.GetAxis("Horizontal");
            transform.position += Vector3.right * speedH * rotation * Time.deltaTime;

        }
    }
}

