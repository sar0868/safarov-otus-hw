using System;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "GameUpgradeData", menuName = "Data/Game/Upgrade")]
    public sealed class GameUpgradeData : ScriptableObject
    {
        [Serializable]
        private class GameDataByLevel
        {
            public int Level;
            public GameData GameData;
        }

        [SerializeField] private GameDataByLevel[] _gameDataByLevels;
        [SerializeField] private GameData _gameDataDefault;

        public bool TryGetGameDataLevel(int level, out GameData gameData)
        {
            for (int i = 0; i < _gameDataByLevels.Length; i++)
            {
                GameDataByLevel gameDataByLevel = _gameDataByLevels[i];
                if (gameDataByLevel.Level == level)
                {
                    gameData = gameDataByLevel.GameData;
                    return true;
                }
            }
            gameData = _gameDataDefault;
            return false;
        }
    }
}
