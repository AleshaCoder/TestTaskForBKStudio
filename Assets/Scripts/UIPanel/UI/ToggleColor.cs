using UnityEngine;
using UnityEngine.UI;

namespace UIPanel.UI
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleColor : MonoBehaviour
    {
        [SerializeField] private Color _onColor, _offColor;

        private Toggle _toggle;
        private Image _background;

        private void OnEnable()
        {
            _toggle = GetComponent<Toggle>();
            _background = _toggle.GetComponentInChildren<Image>();
            _toggle.onValueChanged.AddListener(ChangeColor);
        }

        private void OnDisable() => _toggle.onValueChanged.RemoveListener(ChangeColor);

        private void ChangeColor(bool on)
        {
            if (on)
                _background.color = _onColor;
            else
                _background.color = _offColor;
        }
    }
}