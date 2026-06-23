using System;
using UnityEngine;

namespace Code
{
    public sealed class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private int _hp = 100;
        public event Action<int> OnChangeHp;
        private int _countEnemy;

        public int CountEnemy { get => _countEnemy; set => _countEnemy = value; }
        public int Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                OnChangeHp?.Invoke(_hp);
            }
        }

        private void Awake()
        {
            Hp = _hp;
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

        private void PlayerDeath()
        {
            Debug.LogError($"Player death");
        }
    }
}
