using UnityEngine;

namespace Code
{
    public sealed class Gun : Weapon
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _countBullets;

        private Bullet[] _bullets;
        private Transform _bulletsRoot;

        private void Start()
        {
            _bulletsRoot = new GameObject("Bullets root").transform;
            Recharge();
        }

        public override void Fire()
        {
            if (CanShot == false)
            {
                return;
            }

            if (TryGetBullet(out Bullet bullet))
            {
                bullet.Run(_barrel.forward * _force, _barrel.position);
                LastShootTime = 0.0f;
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

        public override void Recharge()
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