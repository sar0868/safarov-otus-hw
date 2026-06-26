using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace Code
{
    public class WinWindow : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Button _exitMainMenu_Btn;
        [SerializeField] private Button _nextLevel_Btn;
        [SerializeField] private Button _restartLevel_Btn;
        [SerializeField] private CanvasGroup _background;
        [SerializeField] private CanvasGroup _buttonGroup;
        [SerializeField] private CanvasGroup _textWin;
        [SerializeField] private CoinsWinWindow _coins;
        [SerializeField] private CoinsWinWindow _enemies;
        [SerializeField] private Conditions _conditions;

        private string _mainMenu = "MainMenu";
        private string _level1 = "Level1";
        private string _tower = "Tower";
        private Sequence _sequence;

        private void Awake()
        {
            gameObject.SetActive(false);

            _background.alpha = 0f;
            _buttonGroup.alpha = 0f;
            _textWin.alpha = 0f;
        }

        public void Show()
        {
            Time.timeScale = 0;
            gameObject.SetActive(true);

            Cursor.lockState = CursorLockMode.Confined;
            AudioListener.pause = true;
            _playerInput.SwitchCurrentActionMap("UI");

            _sequence?.Kill();
            _sequence = null;
            _sequence = DOTween.Sequence().SetUpdate(UpdateType.Normal, true);
            _sequence.Append(_background.DOFade(1f, 2f))
            .AppendInterval(1f)
            .Join(_textWin.DOFade(1f, 0.5f))
            .AppendInterval(0.5f)
            .Join(_buttonGroup.DOFade(1f, 0.5f))
            .OnComplete(() =>
            {
                _coins.FallResult(_conditions.CountCoins);
                _enemies.FallResult(_conditions.CountKilledEnemies);
            });
        }

        private void OnEnable()
        {
            _exitMainMenu_Btn.onClick.AddListener(ExitMainMenu);
            _nextLevel_Btn.onClick.AddListener(NextLevel);
            _restartLevel_Btn.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            gameObject.SetActive(false);
            AudioListener.pause = false;
            string currentScene = SceneManager.GetActiveScene().name;
            Time.timeScale = 1;
            SceneManager.LoadScene(currentScene);
        }

        private void OnDisable()
        {
            _exitMainMenu_Btn.onClick.RemoveListener(ExitMainMenu);
            _nextLevel_Btn.onClick.RemoveListener(NextLevel);
            _restartLevel_Btn.onClick.AddListener(Restart);
        }

        private void NextLevel()
        {
            if (SceneManager.GetActiveScene().name != _level1)
            {
                ExitMainMenu();
            }
            else
            {
                _sequence?.Kill();
                _sequence = null;
                _sequence = DOTween.Sequence().SetUpdate(UpdateType.Normal, true);
                _sequence.SetLink(gameObject)
                .OnComplete(() =>
                {
                    gameObject.SetActive(false);
                    AudioListener.pause = false;
                    SceneManager.LoadScene(_tower);
                });
            }

        }

        private void ExitMainMenu()
        {
            _sequence?.Kill();
            _sequence = null;
            _sequence = DOTween.Sequence().SetUpdate(UpdateType.Normal, true);
            _sequence.SetLink(gameObject)
            .OnComplete(() => ExitGame());
        }

        private void ExitGame()
        {
            gameObject.SetActive(false);
            AudioListener.pause = false;
            SceneManager.LoadScene(_mainMenu);
        }
    }
}
