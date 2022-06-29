using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIPanel.UI
{
    public partial class PanelSwitcher
    {
        [Serializable]
        private class ObjectWithSwitch
        {
            [SerializeField] private Button _button;
            [SerializeField] private ToggleContainer _toggleContainer;
            [SerializeField] private bool _active = false;

            public ToggleContainer ToggleContainer => _toggleContainer;

            public bool Active => _active;

            public event Action<ObjectWithSwitch> OnClick;

            public void Init()
            {
                _button.onClick.AddListener(() => _active = !_active);
                _button.onClick.AddListener(() => OnClick?.Invoke(this));
                Refresh();
            }

            public void Refresh()
            {
                if (Active)
                    Enable();
                else
                    Disable();
            }

            public void Enable() => _toggleContainer.gameObject.SetActive(true);

            public void Disable() => _toggleContainer.gameObject.SetActive(false);
        }
    }
}
