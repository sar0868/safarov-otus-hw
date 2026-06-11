using System;
using UnityEngine;

namespace Code.Cargo
{
    public sealed class CargoBahavior : MonoBehaviour
    {
        public event Action<int> OnChangedHp;
        [SerializeField] private int _hp = 100;

        private void Awake()
        {
            OnChangedHp?.Invoke(_hp);
        }

        public void TakeDamage(int damage)
        {
            _hp -= damage;
            _hp = _hp >= 0 ? 0 : _hp;

            OnChangedHp?.Invoke(_hp);

            if (_hp == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.LogError($"destroyed"); ;
        }
    }
}

