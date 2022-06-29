using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace UIPanel.UI
{
    public partial class PanelSwitcher : MonoBehaviour
    {
        [SerializeField] private List<ObjectWithSwitch> _switches;

        public ToggleContainer ActivePanel { get; private set; }

        private void OnEnable()
        {
            foreach (var item in _switches)
                item.OnClick += Refresh;
        }

        private void Start()
        {
            foreach (var item in _switches)
                item.Init();
            ActivePanel = _switches.First(sw1 => sw1.Active == true).ToggleContainer;
        }

        private void OnDisable()
        {
            foreach (var item in _switches)
                item.OnClick -= Refresh;
        }

        private void Refresh(ObjectWithSwitch _clicked)
        {
            foreach (var item in _switches)
                item.Disable();

            _clicked.Enable();
            ActivePanel = _clicked.ToggleContainer;
        }
    }
}
