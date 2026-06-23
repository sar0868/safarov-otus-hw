using TMPro;
using UnityEngine;

namespace Code
{
    public sealed class InfoCharges : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _chargesBar;
        [SerializeField] private TextMeshProUGUI _hpBar;

        private void OnEnable()
        {
            Attack.OnChargesChanged += UpdateUICharges;
            PlayerBehaviour.OnChangeHp += UpdateUIHp;
        }

        private void OnDisable()
        {
            Attack.OnChargesChanged -= UpdateUICharges;
            PlayerBehaviour.OnChangeHp -= UpdateUIHp;
        }

        private void UpdateUICharges(int countCharges)
        {
            _chargesBar.text = $"Charges: {countCharges}";
        }

        private void UpdateUIHp(int hp)
        {
            _hpBar.text = $"Health: {hp}";
        }
    }
}
