using UnityEngine;

namespace Code
{
    public class Conditions : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private WinLoseService _winLoseService;

        private int _killedEnemies = 0;
        private static int _countCoins = 0;


        public int CountCoins { get => _countCoins; }
        public int CountKilledEnemies { get => _killedEnemies; }

        private void OnEnable()
        {
            _player.PlayerMovement.FallDeath += IsLoss;
            _player.PlayerBehaviour.OnDeath += IsLoss;
            EndGame.OnEnd += IsWin;
        }

        private void OnDisable()
        {
            _player.PlayerMovement.FallDeath -= IsLoss;
            _player.PlayerBehaviour.OnDeath += IsLoss;
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
