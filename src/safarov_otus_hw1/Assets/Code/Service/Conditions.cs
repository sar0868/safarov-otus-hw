using UnityEngine;

namespace Code
{
    public class Conditions : MonoBehaviour
    {
        private WinLoseService _winLoseService;

        private int _killedEnemies;
        private int _winCondition = 1;

        private void Awake()
        {
            _winLoseService = GetComponent<WinLoseService>();
        }

        private bool IsWin()
        {
            if (_killedEnemies >= _winCondition)
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
    }
}

