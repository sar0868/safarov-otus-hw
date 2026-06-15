using System;
using UnityEngine;

namespace Code.Cargo
{
    public sealed class CargoBahavior : MonoBehaviour
    {
        public event Action<int> OnChangedHp;
        public event Action<bool> OnIsDead;
        [SerializeField] private int _hp = 1000;

        public int Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                OnChangedHp?.Invoke(_hp);
            }
        }

        private void Start()
        {
            Hp = _hp;
            OnIsDead?.Invoke(false);
        }

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            Hp = Hp >= 0 ? Hp : 0;

            if (Hp == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            OnIsDead?.Invoke(true);
        }
    }
}

