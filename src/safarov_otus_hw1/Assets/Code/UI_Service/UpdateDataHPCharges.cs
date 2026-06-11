using Code.Cargo;
using TMPro;
using UnityEngine;

namespace Code.UI_Service
{
    public sealed class UpdateDataHPCharges : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _hp;
        [SerializeField] private TextMeshProUGUI _charges;
        [SerializeField] private CargoBahavior _cargo;

        private void OnEnable()
        {
            _cargo.OnChangedHp += UpdateHpUI;
        }

        private void UpdateHpUI(int newHp)
        {
            _hp.text = $"hp: {newHp}";
        }

        private void OnDisable()
        {
            _cargo.OnChangedHp -= UpdateHpUI;
        }

    }
}
