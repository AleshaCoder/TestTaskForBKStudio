using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class CalculationView
{
    [SerializeField] private TMP_InputField _normalField;
    [SerializeField] private TMP_InputField _postfixField;
    [SerializeField] private TMP_InputField _resultField;

    [SerializeField] private Button ConvertToPostfixButton;
    [SerializeField] private Button ResultButton;

    private Image _normalImage;

    public event Action<string> OnConvertButtonClick;
    public event Action<string> OnResultButtonClick;

    public void Init()
    {
        _normalImage = _normalField.GetComponent<Image>();
        ConvertToPostfixButton.onClick.AddListener(() => OnConvertButtonClick?.Invoke(_normalField.text));
        ResultButton.onClick.AddListener(() => OnResultButtonClick?.Invoke(_normalField.text));
    }

    public void RefreshPostfixField(string text) => _postfixField.text = text;
    public void RefreshResultField(string text) => _resultField.text = text;
    public void RefreshNormalField(string text) => _normalField.text = text;
    public void ShowError() => _normalImage.color = new Color32(255, 200, 200, 255);
    public void HideError() => _normalImage.color = new Color32(255, 255, 255, 255);
}
