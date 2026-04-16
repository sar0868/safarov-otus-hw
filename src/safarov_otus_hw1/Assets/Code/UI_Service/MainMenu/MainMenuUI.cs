using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Code
{
    public class MainMenuUI : MonoBehaviour
    {

        [SerializeField] private Button _startGameBtn;
        [SerializeField] private Button _settingsBtn;
        [SerializeField] private Button _exitBtn;
        [SerializeField] private Button _backBtn;
        [SerializeField] private ViewMainMenu _viewMainMenu;
        [SerializeField] private ViewSettings _viewSettings;

        private void Awake()
        {
            BackMainMenu();
        }

        private void OnEnable()
        {
            _startGameBtn.onClick.AddListener(StartGame);
            _settingsBtn.onClick.AddListener(Settings);
            _exitBtn.onClick.AddListener(Exit);
            _backBtn.onClick.AddListener(BackMainMenu);
        }


        private void OnDisable()
        {
            _startGameBtn.onClick.RemoveListener(StartGame);
            _settingsBtn.onClick.RemoveListener(Settings);
            _exitBtn.onClick.RemoveListener(Exit);
            _backBtn.onClick.RemoveListener(BackMainMenu);
        }

        private void StartGame()
        {
            SceneManager.LoadScene("Gameplay");
        }
        private void Settings()
        {
            _viewMainMenu.gameObject.SetActive(false);
            _viewSettings.gameObject.SetActive(true);
        }

        private void BackMainMenu()
        {
            _viewMainMenu.gameObject.SetActive(true);
            _viewSettings.gameObject.SetActive(false);
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
    }
}
