using System;
using UnityEngine;

namespace Code
{
    public sealed class Paddle : MonoBehaviour
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

        }

        private void GetPositionBorder()
        {
            Transform left = FindAnyObjectByType<LeftZone>().transform;
            Transform right = FindAnyObjectByType<RightZone>().transform;
            _indent = left.localScale.x / 2;
            _left = left.position.x + transform.localScale.x / 2 + _indent;
            _right = right.position.x - transform.localScale.x / 2 - _indent;
        }
    }
}

