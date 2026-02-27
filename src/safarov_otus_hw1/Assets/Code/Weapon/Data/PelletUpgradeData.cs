using System;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = nameof(PelletUpgradeData),
    menuName = "Data/Pellet/Upgrade")]
    public sealed class PelletUpgradeData : ScriptableObject
    {
        [Serializable]
        private class PelletDataByLevel
        {
            public int Level;
            public PelletData Data;
        }
        
        [SerializeField] private PelletDataByLevel[] _pelletDataByLevels;
        [SerializeField] private PelletData _pelletDataDefault;
        
        public bool TryGetDataLevel(int level, out PelletData pelletData)
        {
            for (int i = 0; i < _pelletDataByLevels.Length; i++)
            {
                PelletDataByLevel pelletDataByLevel = _pelletDataByLevels[i];
                if (pelletDataByLevel.Level == level)
                {
                    pelletData = pelletDataByLevel.Data;
                    return true;
                }
            }
            pelletData = _pelletDataDefault;
            return false;
        }
    }
}
