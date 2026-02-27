using System;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName =nameof(WeaponUpgradeData), 
    menuName = "Data/Weapon/Upgrade")]
    public sealed class WeaponUpgradeData : ScriptableObject
    {
        [Serializable]
        private class WeaponDataByLevel
        {
            public int Level;
            public WeaponData Data;
        }

        [SerializeField] private WeaponDataByLevel[] _weaponDataByLevels;
        [SerializeField] private WeaponData _weaponDataDefault;

        public bool TryGetDataLevel(int level, out WeaponData weaponData)
        {
            for (int i = 0; i < _weaponDataByLevels.Length; i++)
            {
                WeaponDataByLevel weaponDataByLevel = _weaponDataByLevels[i];
                if (weaponDataByLevel.Level == level)
                {
                    weaponData = weaponDataByLevel.Data;
                    return true;
                }
            }

            weaponData = _weaponDataDefault;
            return false;
        }
    }
}