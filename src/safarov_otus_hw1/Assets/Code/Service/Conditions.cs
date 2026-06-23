using UnityEngine;

namespace Code
{
    public class Conditions : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private WinLoseService _winLoseService;
        private int _killedEnemies = 0;
        private int _winCondition = 1;
        private int _countCoins = 0;


        public int CountCoins { get => _countCoins; }
        public int CountKilledEnemies { get => _killedEnemies; }

        // private void Awake()
        // {
        //     _winLoseService = GetComponent<WinLoseService>();
        // }

        private void OnEnable()
        {
            _playerMovement.FallDeath += IsLoss;
        }

        private void OnDisable()
        {
            _playerMovement.FallDeath -= IsLoss;
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

        public void IsLoss()
        {
            _winLoseService.ShowLoseWindow();
        }

        public void KillNPC()
        {
            _winLoseService.ShowLoseWindow();
        }
    }
}
