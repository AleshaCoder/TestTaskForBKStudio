using UnityEngine;

namespace Calculator.UI
{
    public class CalculationPresenter : MonoBehaviour
    {
        [SerializeField] private CalculationView _calculationView;
        private RPNCalculator _calculator;

        private void Awake()
        {
            _calculator = new RPNCalculator();
            _calculationView.Init();
        }

        private void OnEnable()
        {
            _calculationView.OnConvertButtonClick += SetPostfixNotation;
            _calculationView.OnResultButtonClick += SetResult;
        }

        private void SetResult(string str)
        {
            bool correctly = _calculator.TryCalculate(str, out double result);
            str = result.ToString();
            str = Validate(correctly, str);
            _calculationView.RefreshResultField(str);
        }

        private void SetPostfixNotation(string str)
        {
            bool correctly = _calculator.TryConvertToPostfixNotation(str, out string result);
            str = Validate(correctly, result);
            _calculationView.RefreshPostfixField(str);
        }

        private string Validate(bool correctly, string result)
        {
            string str;
            if (correctly)
            {
                str = result;
                _calculationView.HideError();
            }
            else
            {
                str = string.Empty;
                _calculationView.ShowError();
                _calculationView.RefreshNormalField("");
                _calculationView.RefreshPostfixField("");
                _calculationView.RefreshResultField("");
            }

            return str;
        }
    }
}
