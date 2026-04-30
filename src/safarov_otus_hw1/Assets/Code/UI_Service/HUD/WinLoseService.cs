using UnityEngine;

namespace Code
{
    public sealed class WinLoseService : MonoBehaviour
    {
        public static WinLoseService Instance;
        [SerializeField] private WinWindow _winWindow;
        [SerializeField] private LoseWindow _loseWindow;

        public void ShowWinWindow()
        {
            _winWindow.Show();
        }
        public void ShowLoseWindow()
        {
            _loseWindow.Show();
        }
    }
}
