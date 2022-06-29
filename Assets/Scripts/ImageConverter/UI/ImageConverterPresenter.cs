using UnityEngine;
using ImageConverter.Logic;

namespace ImageConverter.UI
{
    public class ImageConverterPresenter : MonoBehaviour
    {
        [SerializeField] private ImageConverterView _imageConverterView;
        private ImageToGrayConverter _imageConverter;

        private void Awake()
        {
            _imageConverterView.Init();
            _imageConverterView.OnConvertButtonClick += Redraw;
        }

        private void Redraw(Texture texture)
        {
            _imageConverter = new ImageToGrayConverter(texture);
            _imageConverter.ConvertSimply();
            _imageConverterView.RedrawImage(_imageConverter.GetTexture());
        }
    }
}