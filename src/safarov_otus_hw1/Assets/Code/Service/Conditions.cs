using Code.Cargo;
using UnityEngine;

namespace Code.Service
{
    public class Conditions : MonoBehaviour
    {
        [SerializeField] private WinLossSystem _winLossSystem;
        [SerializeField] private CargoBahavior _cargo;
        [SerializeField] private EndGame _endGame;

        private void OnEnable()
        {
            _cargo.OnIsDead += IsLoss;
            _endGame.OnIsWin += IsWin;
        }



        private void OnDisable()
        {
            _cargo.OnIsDead -= IsLoss;
            _endGame.OnIsWin -= IsWin;
        }

        public void IsWin()
        {
            _winLossSystem.ShowWinWindow();
        }

        public void IsLoss(bool condition)
        {
            if (condition == true)
            {
                _winLossSystem.ShowLossWindow();
            }
        }

    }
}

