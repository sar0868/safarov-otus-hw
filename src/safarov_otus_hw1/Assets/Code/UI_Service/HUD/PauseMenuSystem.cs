using UnityEngine;

namespace Code
{
    public sealed class PauseMenuSystem : MonoBehaviour
    {
        [SerializeField] private PauseMenu _pauseMenuWindow;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pauseMenuWindow.Show();
            }
        }
    }
}

