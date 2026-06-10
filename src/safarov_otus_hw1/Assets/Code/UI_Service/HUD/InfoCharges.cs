using TMPro;
using UnityEngine;

namespace Code
{
    public sealed class InfoCharges : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _chargesBar;

        private void OnEnable()
        {
            Attack.OnChargesChanged += UpdateUI;
        }

        private void OnDisable()
        {
            Attack.OnChargesChanged -= UpdateUI;
        }

        private void UpdateUI(int countCharges)
        {
            _chargesBar.text = $"Charges: {countCharges}";
        }
    }
}
