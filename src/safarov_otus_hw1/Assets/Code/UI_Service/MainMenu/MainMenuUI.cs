using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Code.UI_Service.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {

        [SerializeField] private Button _startGameBtn;
        [SerializeField] private Button _settingsBtn;
        [SerializeField] private Button _exitBtn;

        private void OnEnable()
        {
            _startGameBtn.onClick.AddListener(StartGame);
            // _settingsBtn.onClick.AddListener(Settings);
            _exitBtn.onClick.AddListener(Exit);
        }


        private void OnDisable()
        {
            _startGameBtn.onClick.RemoveListener(StartGame);
            // _settingsBtn.onClick.RemoveListener(Settings);
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
            SceneManager.LoadScene("Gameplay");
        }
    }
}
