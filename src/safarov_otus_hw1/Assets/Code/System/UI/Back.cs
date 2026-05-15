using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.System.UI
{
    public sealed class Back : MonoBehaviour
    {
        [SerializeField] private Button _backBtn;

        private void OnEnable()
        {
            _backBtn.onClick.AddListener(BackMainMenu);
        }

        private void BackMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        private void OnDisable()
        {
            _backBtn.onClick.RemoveListener(BackMainMenu);
        }
    }
}

