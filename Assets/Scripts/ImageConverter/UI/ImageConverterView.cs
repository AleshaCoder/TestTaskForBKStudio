using System;
using UnityEngine;
using UnityEngine.UI;

namespace ImageConverter.UI
{
    [Serializable]
    public class ImageConverterView
    {
        [SerializeField] private Button _convertButton;
        [SerializeField] private RawImage _rawImage;

        public event Action<Texture> OnConvertButtonClick;

        public void Init()
        {
            _convertButton.onClick.AddListener(() => OnConvertButtonClick?.Invoke(_rawImage.texture));
        }

        public void RedrawImage(Texture2D texture)
        {
            _rawImage.texture = texture;
        }
    }
}
