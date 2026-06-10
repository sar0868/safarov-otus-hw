using Code.Service;
using UnityEngine;

namespace Code.UI_Service
{
    public sealed class PauseMenuSystem : MonoBehaviour
    {
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private InputService _inputService;

        private void Awake()
        {
            _inputService.pauseEvent.AddListener(PauseMenuShow);
        }

        private void PauseMenuShow()
        {
            _pauseMenu.Show();
        }
    }

}
