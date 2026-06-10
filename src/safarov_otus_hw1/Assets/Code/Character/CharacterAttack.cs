using Code.Service;
using UnityEngine;

namespace Code.Character
{
    public sealed class CharacterAttack : MonoBehaviour
    {
        [SerializeField] private InputService _inputService;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private float _speed;
        [SerializeField] private Transform _bulletsRoot;
        [SerializeField] private int _countBullets = 20;
        private float _throwDelay = 0.2f;
        private float _lastThrow;

        public int CountBullets { get => _countBullets; set => _countBullets = value; }

        private void Update()
        {
            if (_throwDelay <= _lastThrow)
            {
                return;
            }
            _lastThrow += Time.deltaTime;
        }

        [ContextMenu("Fire")]
        private void Fire()
        {
            Bullet bullet = Instantiate(
                _bulletPrefab,
                _bulletsRoot.position,
                Quaternion.identity);
            bullet.Sleep();
            _lastThrow = 0.0f;
            bullet.Run(
                _bulletsRoot.forward * _speed,
                _bulletsRoot.position
            );
            CountBullets--;
        }
    }
}

