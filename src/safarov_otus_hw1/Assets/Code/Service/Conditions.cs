using UnityEngine;

namespace Code
{
    public class Conditions : MonoBehaviour
    {
        private WinLoseService _winLoseService;

        private int _killedEnemies = 0;
        private int _winCondition = 2;
        private int _countCoins = 0;


        public int CountCoins { get => _countCoins; }
        public int CountKilledEnemies { get => _killedEnemies; }

        private void Awake()
        {
            _winLoseService = GetComponent<WinLoseService>();
        }

        private bool IsWin()
        {
            if (CountKilledEnemies >= _winCondition)
            {
                return true;
            }
            return false;
        }

        public void KilledEnemy()
        {
            _killedEnemies++;
            if (IsWin())
            {
                _winLoseService.ShowWinWindow();
            }
        }

        public void AddCoun()
        {
            _countCoins++;
        }

        public void KillNPC()
        {
            _winLoseService.ShowLoseWindow();
        }
    }
}

