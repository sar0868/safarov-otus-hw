using UnityEngine;

namespace Code
{
    public class Paddle : MonoBehaviour
    {
        private float _left;
        private float _right;
        private float _indent;

        public float Speed { get; set; }

        private void Start()
        {
            GetPositionBorder();
        }

        private void Update()
        {
            MovementPaddle();
        }

        private void GetPositionBorder()
        {
            Transform left = FindAnyObjectByType<LeftZone>().transform;
            Transform right = FindAnyObjectByType<RightZone>().transform;
            _indent = left.localScale.x / 2;
            _left = left.position.x + transform.localScale.x / 2 + _indent;
            _right = right.position.x - transform.localScale.x / 2 - _indent;
        }

        private void MovementPaddle()
        {

            float axis = Input.GetAxis("Horizontal");
            float newX = axis * Speed * Time.deltaTime;
            float position = transform.position.x + newX;
            if (IsBounds(position))
            {
                return;
            }
            transform.position += new Vector3(newX, 0, 0);
        }


        private bool IsBounds(float position)
        {
            return position >= _right || position <= _left;
        }
    }
}
