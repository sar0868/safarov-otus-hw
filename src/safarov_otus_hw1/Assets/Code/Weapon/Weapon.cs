using UnityEngine;

namespace Code.Weapon
{
    public class Weapon : MonoBehaviour
    {
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        public void Shoot()
        {

        }

        public void Recharge()
        {

        }

    }
}


