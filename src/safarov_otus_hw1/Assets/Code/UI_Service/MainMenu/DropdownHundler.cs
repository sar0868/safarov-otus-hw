using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Code
{
    public sealed class DropdownHundler : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown;
        public static int level;

        private void Start()
        {
            List<string> options = new List<string> {
                "level 1",
                "level 2",
                "level 3",
                "level 4"
                };
            _dropdown.ClearOptions();
            _dropdown.AddOptions(options);
            _dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(_dropdown); });
        }

        void OnDropdownValueChanged(TMP_Dropdown change)
        {
            Debug.Log("Выбрано: " + change.value + " - " + change.options[change.value].text);
            string data = change.options[change.value].text;
            switch (data)
            {
                case "level 1":
                    level = 1;
                    return;
                case "level 2":
                    level = 2;
                    return;
                case "level 3":
                    level = 3;
                    return;
                case "level 4":
                    level = 4;
                    return;
                default:
                    level = 0;
                    return;
            }
        }
    }
}

