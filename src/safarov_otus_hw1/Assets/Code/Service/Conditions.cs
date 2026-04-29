using UnityEngine;

namespace Code
{
    public class Conditions : MonoBehaviour
    {
        private WinLoseService _winLoseService;

        private int _killedEnemies;
        private int _winCondition = 1;
        [SerializeField] private int _countCoins = 0;

        public int CountCoins { get => _countCoins; }

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

        public void AddCoun()
        {
            _countCoins++;
        }
    }
}

