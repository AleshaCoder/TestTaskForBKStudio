using UnityEngine;

namespace UIPanel.UI
{
    public class PanelVisibility : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        public void ReverseVisibility() => _panel.SetActive(!_panel.activeSelf);

        public void SwitchOn() => _panel.SetActive(true);
        public void SwitchOff() => _panel.SetActive(false);
    }
}
