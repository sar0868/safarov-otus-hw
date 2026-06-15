using System;
using Code.Cargo;
using Code.Character;
using TMPro;
using UnityEngine;

namespace Code.UI_Service
{
    public sealed class UpdateDataHPCharges : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _hp;
        [SerializeField] private TextMeshProUGUI _charges;
        [SerializeField] private CargoBahavior _cargo;
        [SerializeField] private CharacterAttack _character;

        private void OnEnable()
        {
            _cargo.OnChangedHp += UpdateHpUI;
            _character.OnChangedCharges += UpdateChargesUI;
        }

        private void UpdateChargesUI(int newCharges)
        {
            _charges.text = $"charges: {newCharges}";
        }

        private void UpdateHpUI(int newHp)
        {
            _hp.text = $"hp: {newHp}";
        }

        private void OnDisable()
        {
            _cargo.OnChangedHp -= UpdateHpUI;
            _character.OnChangedCharges -= UpdateChargesUI;
        }

    }
}
