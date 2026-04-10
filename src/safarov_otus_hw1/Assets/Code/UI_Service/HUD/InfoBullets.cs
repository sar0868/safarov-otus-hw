using TMPro;
using UnityEngine;

namespace Code
{
    public sealed class InfoBullets : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _bulletBar;

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

