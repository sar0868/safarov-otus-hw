using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Code
{
    public class MainMenuUI : MonoBehaviour
    {

        [SerializeField] private Button _startGameBtn;
        [SerializeField] private Button _exitBtn;
        [SerializeField] private ViewMainMenu _viewMainMenu;

        private string _level1 = "Level1";
        private string _tower = "Tower";

        private void OnEnable()
        {
            _startGameBtn.onClick.AddListener(StartGame);
            _exitBtn.onClick.AddListener(Exit);
        }

        private void OnDisable()
        {
            _startGameBtn.onClick.RemoveListener(StartGame);
            _exitBtn.onClick.RemoveListener(Exit);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(_level1);
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
