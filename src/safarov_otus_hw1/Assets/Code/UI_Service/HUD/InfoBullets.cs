using TMPro;
using UnityEngine;

namespace Code.UI_Service.HUD
{
    public sealed class InfoBullets : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _bulletBar;

        private int _bullets;

        public int Bullets { get => _bullets; set => _bullets = value; }

        private void OnEnable()
        {
            WeaponsSelector.OnBulletsChanged += UpdateUI;
        }

        private void OnDisable()
        {
            WeaponsSelector.OnBulletsChanged -= UpdateUI;
        }

        private void UpdateUI(int countBullets)
        {
            _bulletBar.text = $"Bullets: {countBullets}";
        }


    }
}

