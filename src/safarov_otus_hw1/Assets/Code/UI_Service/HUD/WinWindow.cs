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
        [SerializeField] private Button _collect_Btn;
        [SerializeField] private Button _advertisement_Btn;
        [SerializeField] private CanvasGroup _background;
        [SerializeField] private CanvasGroup _buttonGroup;
        [SerializeField] private CanvasGroup _textWin;
        [SerializeField] private CoinsWinWindow _coins;
        [SerializeField] private CoinsWinWindow _enemies;
        [SerializeField] private Conditions _conditions;

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
            gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            AudioListener.pause = true;
            _playerInput.SwitchCurrentActionMap("UI");

            _sequence?.Kill();
            _sequence = null;
            _sequence = DOTween.Sequence();
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
            _collect_Btn.onClick.AddListener(Collect);
            _advertisement_Btn.onClick.AddListener(Advertising);
        }

        private void OnDisable()
        {
            _collect_Btn.onClick.RemoveListener(Collect);
            _advertisement_Btn.onClick.RemoveListener(Advertising);
        }

        private void Advertising()
        {
            Debug.Log("Реклама");
        }

        private void Collect()
        {
            _sequence?.Kill();
            _sequence = null;
            _sequence = DOTween.Sequence();
            _sequence.SetLink(gameObject)
            .OnComplete(() => ExitGame());
        }

        private void ExitGame()
        {
            gameObject.SetActive(false);
            AudioListener.pause = false;
            SceneManager.LoadScene("MainMenu");
        }

    }
}
