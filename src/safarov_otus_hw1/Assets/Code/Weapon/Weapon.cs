using Code.Service;
using UnityEngine;

namespace Code.Weapon
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private InputService _inputService;

        private Transform _bulletsRoot;

        private void Awake()
        {
            _bulletsRoot = transform.Find("Bullets_Root");
            _inputService.attackEvent.AddListener(Fire);
        }

        public void Fire()
        {
            Bullet bullet = Instantiate(_bulletPrefab, _bulletsRoot);
            bullet.Run(_bulletsRoot.forward, _bulletsRoot.position);
        }

    }
}


