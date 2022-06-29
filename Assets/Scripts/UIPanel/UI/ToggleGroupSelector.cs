using UnityEngine;

namespace UIPanel.UI
{
    public class ToggleGroupSelector : MonoBehaviour
    {
        [SerializeField] private PanelSwitcher _panelSwitcher;

        private ToggleContainer _toggleContainer => _panelSwitcher.ActivePanel;

        public void ReverseLeftToggleSelection()
        {
            if (_toggleContainer.SelectedLeft == true)
                _toggleContainer.DeactivateLeftToggles();
            else
                _toggleContainer.ActivateLeftToggles();
        }

        public void ReverseRightToggleSelection()
        {
            if (_toggleContainer.SelectedRight == true)
                _toggleContainer.DeactivateRightToggles();
            else
                _toggleContainer.ActivateRightToggles();
        }
    }
}
