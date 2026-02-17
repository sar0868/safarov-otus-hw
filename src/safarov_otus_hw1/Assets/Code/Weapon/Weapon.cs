using NUnit.Framework.Interfaces;
using UnityEngine;

namespace Code
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _barrel;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _countBullets;
        [SerializeField] private float _force;
        [SerializeField] private float _shotDelay;

        private Bullet[] _bullets;
        private Transform _bulletsRoot;
        private bool _canShot;
        private float _lastShootTime;

        private void Start()
        {
            _bulletsRoot = new GameObject("Bullets root").transform;
            Recharge();
        }

        private void Update()
        {
            _canShot = _shotDelay <= _lastShootTime;

            if (_canShot)
            {
                return;
            }
            _lastShootTime += Time.deltaTime;
        }

        public void Fire()
        {
            if (_canShot == false)
            {
                return;
            }

            if (TryGetBullet(out Bullet bullet))
            {
                bullet.Run(_barrel.forward * _force, _barrel.position);
                _lastShootTime = 0.0f;
            }

        }

        private bool TryGetBullet(out Bullet result)
        {
            int candidate = -1;
            result = default;

            if (_bullets == null)
            {
                return false;
            }

            for (int i = 0; i < _countBullets; i++)
            {
                Bullet bullet = _bullets[i];
                if (bullet == null)
                {
                    continue;
                }
                if (bullet.IsActive)
                {
                    continue;
                }
                candidate = i;
                break;
            }

            if (candidate == -1)
            {
                return false;
            }

            result = _bullets[candidate];
            return true;
        }

        public void Recharge()
        {
            if (TryGetBullet(out _))
            {
                return;
            }
            _bullets = new Bullet[_countBullets];
            for (int i = 0; i < _countBullets; i++)
            {
                Bullet bullet = Instantiate(_bulletPrefab, _bulletsRoot);
                bullet.Sleep();
                _bullets[i] = bullet;
            }
        }
    }
}
