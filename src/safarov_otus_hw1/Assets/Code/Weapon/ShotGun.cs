using System.Collections;
using UnityEngine;

namespace Code
{
    public sealed class ShotGun : Weapon
    {
        [SerializeField] private Pellet _pelletPrefab;
        [SerializeField] private int CountPelletsOUNT_PELLETS = 5;

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
                for (int i = 0; i < CountPelletsOUNT_PELLETS; i++)
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
            StartCoroutine(IsRecharge());
        }

        private IEnumerator IsRecharge()
        {
            _isInstantiatePellets = _isInstantiatePellets == false ? true : true;
            yield return _isInstantiatePellets;
        }
    }
}