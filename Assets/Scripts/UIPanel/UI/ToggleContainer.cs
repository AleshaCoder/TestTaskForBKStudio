using System.Collections.Generic;
using UnityEngine;

namespace UIPanel.UI
{
    public class ToggleContainer : MonoBehaviour
    {
        [SerializeField] protected List<ButtonWithToggles> _toggles;

        private bool _selectedLeft = false;
        private bool _selectedRight = false;

        public bool SelectedLeft => _selectedLeft;
        public bool SelectedRight => _selectedRight;

        public void ActivateLeftToggles()
        {
            foreach (var item in _toggles)
                item.Left.isOn = true;
            _selectedLeft = true;
        }

        public void DeactivateLeftToggles()
        {
            foreach (var item in _toggles)
                item.Left.isOn = false;
            _selectedLeft = false;
        }

        public void ActivateRightToggles()
        {
            foreach (var item in _toggles)
                item.Right.isOn = true;
            _selectedRight = true;
        }

        public void DeactivateRightToggles()
        {
            foreach (var item in _toggles)
                item.Right.isOn = false;
            _selectedRight = false;
        }
    }
}
