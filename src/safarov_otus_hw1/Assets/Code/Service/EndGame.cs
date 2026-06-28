using System;
using UnityEngine;

namespace Code
{
    public sealed class EndGame : MonoBehaviour
    {
        public static event Action OnEnd;
        private Collider _collider;
        private string _tagPlayer = "Player";
        private bool _isEnter = false;


        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isEnter == false && other.CompareTag(_tagPlayer))
            {
                OnEnd?.Invoke();
            }
        }
    }
}

