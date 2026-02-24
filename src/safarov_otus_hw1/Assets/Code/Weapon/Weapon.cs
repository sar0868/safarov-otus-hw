using NUnit.Framework.Interfaces;
using UnityEngine;

namespace Code
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform _barrel;
        // [SerializeField] private int _countBullets;
        [SerializeField] protected float _force;
        [SerializeField] private float _shotDelay;

        public bool CanShot { get; private set ; }
        public float LastShootTime { get; protected set; }

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
