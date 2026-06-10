using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.UI_Service
{
    public sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _newGameBtn;
        [SerializeField] private Button _exitBtn;

        private void OnEnable()
        {
            _newGameBtn.onClick.AddListener(StartGame);
            _exitBtn.onClick.AddListener(Exit);
        }

        private void OnDisable()
        {
            _newGameBtn.onClick.RemoveListener(StartGame);
            _exitBtn.onClick.RemoveListener(Exit);
        }

        private void Exit()
        {
            if (Application.isEditor == false)
            {
                Application.Quit();
            }
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#endif
        }

        private void StartGame()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
