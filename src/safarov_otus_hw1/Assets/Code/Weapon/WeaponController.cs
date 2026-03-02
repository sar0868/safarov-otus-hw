using UnityEngine;

namespace Code
{
    public class WeaponController : MonoBehaviour
    {
        private WeaponsSelector _weaponSelector;
        
        private void Start() {
            Weapon[] weapons = GetComponentsInChildren<Weapon>(true);
            _weaponSelector = new WeaponsSelector(weapons);
        }

        private void Update()
        {
            SelectWeapon();
            
            if (Input.GetMouseButton(0))
            {
                _weaponSelector.Fire();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                _weaponSelector.Recharge();
            }
        }

        private void SelectWeapon()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                _weaponSelector.Next();
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                _weaponSelector.Preview();
            }
        }

        public void AddWeapon(Weapon weapon)
        {
            _weaponSelector.AddWeapon(weapon);
        }
    }
}

