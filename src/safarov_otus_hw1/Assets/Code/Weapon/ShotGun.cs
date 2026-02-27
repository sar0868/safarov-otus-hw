using UnityEngine;

namespace Code
{
    public sealed class ShotGun : Weapon
    {
        [SerializeField] private Pellet _pelletPrefab;
        [SerializeField] private int COUNT_PELLETS = 5;

        private bool _isInstantiatePellets = false;

        protected override void Start()
        {
            base.Start();
            Recharge();
        }

        public override void Fire()
        {
            if (_isInstantiatePellets)
            {
                for (int i = 0; i < COUNT_PELLETS; i++)
                {
                    Pellet pellet = Instantiate(_pelletPrefab, _barrel.position, Quaternion.identity);
                    pellet.Run(_barrel.forward * Force, _barrel.position);
                }
                _isInstantiatePellets = false;
                LastShootTime = 0.0f;
            }
        }

        public override void Recharge()
        {
            if (_isInstantiatePellets)
            {
                return;
            }
            _isInstantiatePellets = true;
        }
    }
}