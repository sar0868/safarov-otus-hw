using UnityEngine;

namespace Code
{
    public sealed class WinLoseService : MonoBehaviour
    {
        public static WinLoseService Instance;
        [SerializeField] private WinLossWindow _winLossWindow;

        public void ShowWinWindow()
        {
            _winLossWindow.Show(true);
        }
        public void ShowLoseWindow()
        {
            _winLossWindow.Show(false);
        }
    }
}
