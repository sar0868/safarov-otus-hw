using UnityEngine;

namespace Code
{
    public class Conditions : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private WinLoseService _winLoseService;

        private void OnEnable()
        {
            _player.PlayerBehaviour.OnDeath += IsLoss;
            EndGame.OnEnd += IsWin;
        }

        private void OnDisable()
        {
            _player.PlayerBehaviour.OnDeath -= IsLoss;
            EndGame.OnEnd -= IsWin;
        }

        private void IsWin()
        {
            _winLoseService.ShowWinWindow();
        }


        public void IsLoss()
        {
            _winLoseService.ShowLoseWindow();
        }
    }
}
