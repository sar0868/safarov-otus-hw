using UnityEngine;

namespace Code
{
    public sealed class FpsSettings : MonoBehaviour
    {
        private void Awake()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }
    }

}
