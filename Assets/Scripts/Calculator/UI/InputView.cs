using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Calculator.StaticData;

namespace Calculator.UI
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class InputView : MonoBehaviour
    {
        [SerializeField] private Button _prefab;
        [SerializeField] private TMP_InputField _normalField;

        private List<Button> _numberButtons;
        private List<Button> _operatorButtons;
        private Button _clearButton;

        private const string _clearButtonName = "C";

        private void Awake()
        {
            InitNumbersButtons();
            InitOperatorButtons();
            InitClearButton();
        }

        private void InitClearButton()
        {
            _clearButton = GenerateButton(_clearButtonName);
            SetClearActionOnClick(_clearButton);
        }

        private void InitOperatorButtons()
        {
            _operatorButtons = new List<Button>();
            foreach (var Operator in Operators.AllOperators)
            {
                Button newButton = GenerateButton(Operator.Name.ToString());
                SetPrintActionOnClick(Operator.Name.ToString(), newButton);
                _operatorButtons.Add(newButton);
            }
        }

        private void InitNumbersButtons()
        {
            _numberButtons = new List<Button>(10);
            for (int i = 0; i < 10; i++)
            {
                Button newButton = GenerateButton(i.ToString());
                SetPrintActionOnClick(i.ToString(), newButton);
                _numberButtons.Add(newButton);
            }
        }

        private Button GenerateButton(string label)
        {
            Button newButton = Instantiate(_prefab, transform);
            TMP_Text text = newButton.GetComponentInChildren<TMP_Text>();
            text.text = label;
            return newButton;
        }

        private void SetPrintActionOnClick(string label, Button newButton) => 
            newButton.onClick.AddListener(() => _normalField.text += label);
        private void SetClearActionOnClick(Button newButton) =>
            newButton.onClick.AddListener(() => _normalField.text = string.Empty);
    }
}
