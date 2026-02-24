using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Data/Weapon/WeaponData")]
    public sealed class WeaponData : ScriptableObject
    {
        [SerializeField] private float _force;
        [SerializeField] private float _shotDelay;

        public float Force 
        { 
            get 
            {
                return _force;
            } 
        }
        public float ShotDelay 
        { 
            get
            {
                return _shotDelay;
            } 
        }
    }
}
