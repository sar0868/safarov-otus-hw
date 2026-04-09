using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public sealed class WeaponsSelector
    {

        public static event Action<int> OnBulletsChanged;
        private readonly List<Weapon> _weapons;
        private int _currentIndex;
        private Weapon _currentWeapon;

        public WeaponsSelector(Weapon[] weapons)
        {
            _weapons = new List<Weapon>();

            for (int i = 0; i < weapons.Length; i++)
            {
                AddWeapon(weapons[i]);
            }
        }

        public void AddWeapon(Weapon weapon)
        {
            weapon.GetComponent<Collider>().enabled = false;
            weapon.SetActive(false);
            _weapons.Add(weapon);
        }

        public void Fire()
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.Fire();
                OnBulletsChanged?.Invoke(_currentWeapon.CountBullets);
            }
        }

        public void Recharge()
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.Recharge();
                OnBulletsChanged?.Invoke(_currentWeapon.CountBullets);
            }
        }

        public void Next()
        {
            _currentIndex++;
            SelectWeapon();
        }

        public void Preview()
        {
            _currentIndex--;
            SelectWeapon();
        }

        private void SelectWeapon()
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.SetActive(false);
            }

            int index = Mathf.Abs(_currentIndex % _weapons.Count);
            _currentWeapon = _weapons[index];
            _currentWeapon.SetActive(true);
            OnBulletsChanged?.Invoke(_currentWeapon.CountBullets);
        }
    }
}