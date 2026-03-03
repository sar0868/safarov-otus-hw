using UnityEngine;

namespace Code
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected int _level = 1;
        [SerializeField] protected Transform _barrel;
        [SerializeField] protected WeaponUpgradeData _weaponUpgradeData;

        private float _shotDelay;

        public bool CanShot { get; private set ; }
        public float LastShootTime { get; protected set; }
        protected float Force { get; private set; }

        protected virtual void Start()
        {
            _weaponUpgradeData.TryGetDataLevel(_level, out WeaponData data);
            
            _shotDelay = data.ShotDelay;
            Force = data.Force;
            
        }
        private void Update()
        {
            CanShot = _shotDelay <= LastShootTime;

            if (CanShot)
            {
                return;
            }
            LastShootTime += Time.deltaTime;
        }

        public abstract void Fire();
        public abstract void Recharge();

    }
}
