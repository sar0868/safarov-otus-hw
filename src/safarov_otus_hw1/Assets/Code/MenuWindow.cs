using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code
{
    public sealed class MenuWindow : MonoBehaviour
    {
        [SerializeField] private Button _startButton;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartGame);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(StartGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(2);
        }
    }
}
