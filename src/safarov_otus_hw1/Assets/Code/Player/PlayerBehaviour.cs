using System;
using UnityEngine;

namespace Code
{
    public sealed class PlayerBehaviour : MonoBehaviour
    {
        public event Action OnDeath;
        public static event Action<int> OnChangeHp;

        [SerializeField] private int _hp = 100;

        private int _maxHP;

        public int Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                OnChangeHp?.Invoke(_hp);
            }
        }

        private void Start()
        {
            Hp = _hp;
            _maxHP = _hp;
        }

        public void GetDamage(int damage)
        {
            if (_hp <= damage)
            {
                Hp = 0;
                PlayerDeath();
            }
            else
            {
                Hp -= damage;
            }
        }

        public void PlayerDeath()
        {
            OnDeath?.Invoke();
        }

        public void AddHp(int health)
        {
            int buff = _hp + health;
            Hp = buff >= _maxHP ? _maxHP : buff;
        }
    }
}
