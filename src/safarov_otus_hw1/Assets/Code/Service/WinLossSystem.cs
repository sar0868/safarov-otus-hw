using Code.UI_Service;
using UnityEngine;

namespace Code.Service
{
    public sealed class WinLossSystem : MonoBehaviour
    {
        public static WinLossSystem Instance;
        [SerializeField] private WinWindow _winWindow;
        [SerializeField] private LossWindow _lossWindow;

        public void ShowWinWindow()
        {
            _winWindow.Show();
        }
        public void ShowLossWindow()
        {
            _lossWindow.Show();
        }
    }
}

