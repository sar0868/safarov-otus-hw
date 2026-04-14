using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public sealed class Gun : Weapon
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _countBullets;

        private Queue<Bullet> _bullets;
        private Transform _bulletsRoot;

        protected override void Start()
        {
            base.Start();
            _bulletsRoot = new GameObject("Bullets root").transform;
            _bullets = new Queue<Bullet>(_countBullets);
            Recharge();
        }

        public override void Fire()
        {
            if (CanShot == false)
            {
                return;
            }

            if (_bullets.TryDequeue(out Bullet bullet))
            {
                bullet.Run(_barrel.forward * Force, _barrel.position);
                LastShootTime = 0.0f;
                _audioSource.PlayOneShot(_audioShot);
                CountBullets--;
            }

        }

        public override void Recharge()
        {
            if (_bullets.Count > 0)
            {
                return;
            }

            for (int i = 0; i < _countBullets; i++)
            {
                Bullet bullet = Instantiate(_bulletPrefab, _bulletsRoot);
                bullet.Sleep();
                _bullets.Enqueue(bullet);
                CountBullets++;
            }
        }
    }
}