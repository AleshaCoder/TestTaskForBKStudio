using UnityEngine;
using UnityEngine.UI;

namespace UIPanel.UI
{
    public class ButtonWithToggles : MonoBehaviour
    {
        [SerializeField] private Toggle _left, _right;
        public Toggle Left => _left;
        public Toggle Right => _right;
    }
}
