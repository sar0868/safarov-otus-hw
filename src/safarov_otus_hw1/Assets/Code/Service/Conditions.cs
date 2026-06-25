using UnityEngine;

namespace Code
{
    public class Conditions : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private WinLoseService _winLoseService;

        private int _killedEnemies = 0;
        // private int _winCondition = 2;
        private static int _countCoins = 0;


        public int CountCoins { get => _countCoins; }
        public int CountKilledEnemies { get => _killedEnemies; }

        private void OnEnable()
        {
            _playerMovement.FallDeath += IsLoss;
            EndGame.OnEnd += IsWin;
        }

        private void OnDisable()
        {
            _playerMovement.FallDeath -= IsLoss;
            EndGame.OnEnd -= IsWin;
        }

        private void IsWin()
        {
            _winLoseService.ShowWinWindow();
        }

        public void KilledEnemy()
        {
            _killedEnemies++;

        }

        public static void AddCoun()
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
