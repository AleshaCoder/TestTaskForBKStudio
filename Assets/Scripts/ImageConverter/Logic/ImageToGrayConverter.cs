using UnityEngine;
using System.Threading.Tasks;
using ImageConverter.Utilities;

namespace ImageConverter.Logic
{
    public class ImageToGrayConverter
    {
        private Color[] _pixels;
        private Texture2D _texture2D;
        private Texture _texture;

        public ImageToGrayConverter(Texture texture)
        {
            Texture2D texture2d = texture.To2D();
            _texture2D = texture2d;
            _pixels = texture2d.GetPixels();
        }

        public ImageToGrayConverter(Texture2D texture2d)
        {
            _texture2D = texture2d;
            _pixels = texture2d.GetPixels();
        }

        public void ConvertSimply()
        {
            for (int i = 0; i < _pixels.Length; i++)
            {
                float gray = (_pixels[i].r + _pixels[i].g + _pixels[i].b) / 3;
                _pixels[i] = new Color(gray, gray, gray);
            }
        }

        public void ConvertParallel()
        {
            Parallel.For(0, _pixels.Length, (i) =>
            {
                float gray = (_pixels[i].r + _pixels[i].g + _pixels[i].b) / 3;
                _pixels[i] = new Color(gray, gray, gray);
            });
        }

        public Texture2D GetTexture()
        {
            _texture2D = new Texture2D(_texture2D.width, _texture2D.height);
            _texture2D.SetPixels(_pixels);
            _texture2D.Apply();
            return _texture2D;
        }
    }
}
